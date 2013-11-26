/*
//  $Id: RagdollCodeGenerator $
//
//  Copyright 2011 SCIO System-Consulting GmbH & Co. KG. All rights reserved.
//  Created by Kay Bothfeld 
//
//  MIT license, see http://www.opensource.org/licenses/mit-license.php
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
*/

using System.IO;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;


/// <summary>
/// Unity editor class to generate C# code for selected bones of an armature that has been modified by the ragdoll 
/// wizard. The selected bone and all its children will be traversed and methods for creating colliders, rigidbodies
/// and character joints are created.
/// </summary>
public static class RagdollCodeGenerator  
{
	/// <summary>
	/// Number of steps to use in GetPath when looking up the root bone.
	/// </summary>
	const int MaxModelDepth = 40;

	public static string resourcesDir = "Scripts";
	
	/// <summary>
	/// Default name for Save As dialog.
	/// </summary>
	public static string targetClassNameDefault = "RagdollFactoryGenerated";
	
	public static string targetCodeFile = targetClassNameDefault + ".cs";
	
	public static string targetClassName = targetClassNameDefault;
	
	/// <summary>
	/// Path to physic material relative to Assets/Resources. If the material can't be found at generation time
	/// no material will be assigned. To change this code must be regenerated.
	/// </summary>
	private static string physicMaterialPath = "Materials/Physic/PlayerPhysicMaterial";
	
	private static string physicMaterialLoadFragment = "null";
	
	private static string userSelection = null;
	
	private static string classPrefixCode;
	
	private static string classPostfixCode;
	
	private static string publicMembersCode;
	
	private static string publicInterfaceCode;
	
	private static string privateMethodsCode;
	
    [MenuItem("Tools/Generate Ragdoll Code")]
	/// <summary>
	/// Main entry point called by Unity editor when menu item is clicked
	/// </summary>
	public static void GenerateRagdollCode () {
		if (!CheckInputConsistency ()) {
			return;
		}
		PrepareCodeFragments ();
		List<GameObject> gameObjectList = new List<GameObject> (Selection.gameObjects);
		string rootBoneName = null;
		string warnings = "";
		foreach (GameObject gameObject in gameObjectList) {
			// should be exactly one object in list
			if (rootBoneName == null) {
				AddPublicMember ("string", "rootBoneName = \"" + GetPath (gameObject.transform) + "\"");
			}
			CharacterJoint[] jointsFromChildren = gameObject.GetComponents<CharacterJoint> ();
			if (jointsFromChildren.Length == 0) {
				// no joint between this bone and any other bone so this might be the root bone
				// treat this bone separately:
				Collider rootCollider = gameObject.GetComponent<Collider> ();
				Rigidbody rootRigidBody = gameObject.GetComponent<Rigidbody> ();
				string rootPath = null;
				if (rootRigidBody != null) {
					rootBoneName = rootRigidBody.name;
					rootBoneName.Replace (" (UnityEngine.Rigidbody)", "");
					rootPath = GetPath (rootCollider.transform);
					CreateRigidbodyMethod (gameObject, rootRigidBody, rootBoneName, rootPath);
				}
				if (rootCollider != null) {
					rootBoneName = rootCollider.name;
					rootBoneName.Replace (" (UnityEngine.Rigidbody)", "");
					rootPath = GetPath (rootCollider.transform);
					CreateColliderMethod (gameObject, rootCollider, rootBoneName, rootPath);
				}
			}
			// Iterate over all character joints because it is easy to get rigidbody and collider from a joint 
			// but not the other way around
			jointsFromChildren = gameObject.GetComponentsInChildren<CharacterJoint> ();
			foreach (CharacterJoint joint in jointsFromChildren) {
				string boneName = joint.name;
				boneName.Replace (" (UnityEngine.Rigidbody)", "");
				string path = GetPath (joint.transform);
				Rigidbody rigidbody = joint.transform.rigidbody;
				if (rigidbody == null) {
					warnings += ("Object " + path + " does not contain a rigidbody !");
					break;
				}
				Collider collider = rigidbody.collider;
				if (collider == null) {
					warnings += ("Object joint " + path + " does not contain a collider !");
					break;
				}
				CreateColliderMethod (gameObject, collider, boneName, path);
				CreateRigidbodyMethod (gameObject, rigidbody, boneName, path);
				CreateCharacterJointMethod (gameObject, joint, boneName, path);
			}
		}
		publicInterfaceCode += Line (1, "}", 2);
		ExportCode ();
		if (warnings.Length == 0) {
			Debug.Log ("Export terminated successfully.");
		} else {
			Debug.LogWarning (warnings);
		}
	}
	
	[MenuItem("Tools/Assign Ragdoll Components")]
	public static void AssignRagdollComponents () {
		RagdollFactoryGenerated factory = new RagdollFactoryGenerated ();
		if ((Selection.gameObjects == null) || (Selection.gameObjects.Length != 1)) {
			EditorUtility.DisplayDialog ("No selection", "Please select the model object i.e. the parent object containing " + factory.rootBoneName, "OK");
			return;
		}
		GameObject gameObject = Selection.activeGameObject;
		if (gameObject.transform.FindChild (factory.rootBoneName) == null) {
			EditorUtility.DisplayDialog ("Wrong selection", "The selected bone is not the appropriate for applying. Please select the model object i.e. the parent object containing " + factory.rootBoneName, "OK");
			return;
		}
		factory.CreateRagdollComponents (gameObject);
		Debug.Log ("ragdoll components for " + gameObject.name + " created successfully");
	}

	private static void PrepareCodeFragments () {
		classPrefixCode += Line (0, "/*");
		classPrefixCode += Line (0, "//  $Id: " + targetClassName + ".cs $");
		classPrefixCode += Line (0, "//");
		classPrefixCode += Line (0, "//  IMPORTANT: GENERATED CODE  ==>  DO NOT EDIT!");
		classPrefixCode += Line (0, "//  Generated at " + System.DateTime.Now + ". Selected bone for generation was " + userSelection);
		classPrefixCode += Line (0, "//");
		classPrefixCode += Line (0, "//  Permission is hereby granted, free of charge, to any person obtaining a copy");
		classPrefixCode += Line (0, "//  of this software and associated documentation files (the \"Software\"), to deal");
		classPrefixCode += Line (0, "//  in the Software without restriction, including without limitation the rights");
		classPrefixCode += Line (0, "//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell");
		classPrefixCode += Line (0, "//  copies of the Software, and to permit persons to whom the Software is");
		classPrefixCode += Line (0, "//  furnished to do so, subject to the following conditions:");
		classPrefixCode += Line (0, "//  ");
		classPrefixCode += Line (0, "//  The above copyright notice and this permission notice shall be included in");
		classPrefixCode += Line (0, "//  all copies or substantial portions of the Software.");
		classPrefixCode += Line (0, "//  ");
		classPrefixCode += Line (0, "//  THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
		classPrefixCode += Line (0, "//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
		classPrefixCode += Line (0, "//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
		classPrefixCode += Line (0, "//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
		classPrefixCode += Line (0, "//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
		classPrefixCode += Line (0, "//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN");
		classPrefixCode += Line (0, "//  THE SOFTWARE.");
		classPrefixCode += Line (0, "*/", 2);
		classPrefixCode += Code (0, "using UnityEngine");
		classPrefixCode += Code (0, "using System.Collections.Generic", 2);
		classPrefixCode += MakeComment (0, "Handles dynamic creation of ragdoll components for one specific model. As this is no dynamic " +
			"ragdoll calculation but rather a snapshot of the armature at one given point in time." + 
			"Because this code was generated automatically by Unity editor class RagdollCodeGenerator it should " +
			"not be edited directly. All changes will be lost on regeneration! Instead regenerate the code or edit " +
			"the generator's code itself if you need significant changes in structure."
			);
		classPrefixCode += Line (0, "public class " + targetClassName + " {", 2);
		classPostfixCode = Line (0, "}");
		publicMembersCode = Code (1, "internal PhysicMaterial physicMaterial = (PhysicMaterial)Resources.LoadAssetAtPath (\"" +
			physicMaterialPath + "\", typeof(PhysicMaterial))", 2);
		publicMembersCode += Code (1, "public List<Collider> allColliders = new List<Collider> ()", 2);
		publicMembersCode += Code (1, "public List<Rigidbody> allRigidbodies = new List<Rigidbody> ()", 2);
		publicMembersCode += Code (1, "public List<CharacterJoint> allCharacterJoints = new List<CharacterJoint> ()", 2);
		publicMembersCode += MakeComment (1, "Main entry point of this class to be called for generating all ragdoll components on the fly. " +
			"The supplied game object should be the armature's parent. Although all methods check for existing " +
			"objects, it is not recommended to call this method multiple times without doing explicit clean " +
			"up before.");
		// To-Do kay: 3 boolean for filtering types to create
		publicInterfaceCode = Line (1, "public virtual void CreateRagdollComponents(GameObject gameObject) {");
		privateMethodsCode = "";
	}
	
	private static bool CheckInputConsistency () {
		if ((Selection.gameObjects == null) || (Selection.gameObjects.Length != 1)) {
			EditorUtility.DisplayDialog ("No selection", "Please select at least one object to generate ragdoll code recursively.", "OK");
			return false;
		}
		userSelection = Selection.activeGameObject.name;
		physicMaterialLoadFragment = "null";
		PhysicMaterial physicMaterial = (PhysicMaterial)Resources.Load (physicMaterialPath, typeof(PhysicMaterial));
		if (physicMaterial != null) {
			physicMaterialLoadFragment = "(PhysicMaterial) Resources.Load (\"" + physicMaterialPath + "\", typeof(PhysicMaterial))";
			Debug.Log ("Using physic material " + physicMaterial);
		} else {
			Debug.Log ("No path to physic material using null instead");
		}
		targetCodeFile = EditorUtility.SaveFilePanel ("Generate C# Code for Ragdoll Setup", resourcesDir, targetCodeFile, "cs");
		if (targetCodeFile == null || targetCodeFile == "") {
			targetCodeFile = targetClassNameDefault;
			return false;
		}
		targetClassName = System.IO.Path.GetFileNameWithoutExtension (targetCodeFile);
		return true;
	}
	
	/// <summary>
	/// The generated code checks will only create a character joint if there is no existing one. A public member variable
	/// is generated for every dynamically created character joint. Further on a reference to it is added to allCharacterJoints.
	/// </summary>
	private static void CreateCharacterJointMethod (GameObject gameObject, CharacterJoint joint, string name, string path) {
		string code = Line (1, "internal virtual CharacterJoint CreateCharacterJoint_" + name + "(GameObject gameObject, string name, string path) {");
		code += Code (2, "Transform childTransform = gameObject.transform.FindChild (path)");
		code += Code (2, "GameObject childGameObject = childTransform.gameObject");
		code += Code (2, "CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ()");
		code += Line (2, "if (joint == null) {");
		code += Code (3, "joint = childGameObject.AddComponent <CharacterJoint> ()");
		code += Line (2, "}");
		string publicMemberVar = name + "_CharacterJoint";
		publicMemberVar = AddPublicMember ("CharacterJoint", publicMemberVar);
		code += Code (2, publicMemberVar + "= joint");
		code += Code (2, "joint.breakForce = " + MakeFloat (joint.breakForce));
		code += Code (2, "joint.breakTorque = " + MakeFloat (joint.breakTorque));
		code += Code (2, "joint.anchor = " + SetVector (joint.anchor));
		code += Code (2, "joint.axis = " + SetVector (joint.axis));
		code += Code (2, "joint.swingAxis = " + SetVector (joint.swingAxis));
		code += SetSoftJointLimit (2, "joint", "lowTwistLimit", joint.lowTwistLimit);
		code += SetSoftJointLimit (2, "joint", "highTwistLimit", joint.highTwistLimit);
		code += SetSoftJointLimit (2, "joint", "swing1Limit", joint.swing1Limit);
		code += SetSoftJointLimit (2, "joint", "swing2Limit", joint.swing2Limit);
		code += Code (2, " Transform parentTransform = gameObject.transform.FindChild (\"" + GetPath (joint.connectedBody.transform) + "\")");
		code += Line (2, "if (parentTransform == null) {");
		code += Code (3, "Debug.LogWarning (\"parentGameObject for \" + childGameObject.name + \" not found! Maybe initalisation is not yet done.\")");
		code += Code (3, "joint.connectedBody = null");
		code += Line (2, "} else {");
		code += Code (3, "joint.connectedBody = parentTransform.gameObject.rigidbody");
		code += Line (2, "}");
		code += Code (2, "allCharacterJoints.Add (joint)");
		code += Code (2, "return joint");
		code += Line (1, "}", 2);
		AddMethodCode (code);
		string call = "CreateCharacterJoint_" + name + "(gameObject, \"" + name + "\", \"" + path + "\")";
		AddMethodCallFromMain (call);
	}

	/// <summary>
	/// The generated code checks will only create a rigidbody if there is no existing one. A public member variable
	/// is generated for every dynamically created rigidbody. Further on a reference to it is added to allRigidbodies.
	/// </summary>
	private static void CreateRigidbodyMethod (GameObject gameObject, Rigidbody rigidbody, string name, string path) {
		string code = Line (1, "internal virtual Rigidbody CreateRigidbody_" + name + "(GameObject gameObject, string name, string path) {");
		code += Code (2, "Transform childTransform = gameObject.transform.FindChild (path)");
		code += Code (2, "GameObject childGameObject = childTransform.gameObject");
		code += Code (2, "Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ()");
		code += Line (2, "if (rigidbody == null) {");
		code += Code (3, "rigidbody = childGameObject.AddComponent <Rigidbody> ()");
		code += Line (2, "}");
		string publicMemberVar = name + "_Rigidbody";
		publicMemberVar = AddPublicMember ("Rigidbody", publicMemberVar);
		code += Code (2, publicMemberVar + "= rigidbody");
		code += Code (2, "rigidbody.isKinematic = " + MakeBool (rigidbody.isKinematic));
		code += Code (2, "rigidbody.useGravity = " + MakeBool (rigidbody.useGravity));
		code += Code (2, "rigidbody.mass = " + MakeFloat (rigidbody.mass));
//		code += Code (2, "rigidbody.velocity = Vector3.zero");
//		code += Code (2, "rigidbody.angularVelocity = Vector3.zero");
		code += Code (2, "rigidbody.drag = " + MakeFloat (rigidbody.drag));
		code += Code (2, "rigidbody.angularDrag = " + MakeFloat (rigidbody.angularDrag));
		code += Code (2, "rigidbody.interpolation = RigidbodyInterpolation." + rigidbody.interpolation);
		code += Code (2, "rigidbody.detectCollisions = " + MakeBool (rigidbody.detectCollisions));
		code += Code (2, "rigidbody.constraints = RigidbodyConstraints." + rigidbody.constraints);
		code += Code (2, "allRigidbodies.Add (rigidbody)");
		code += Code (2, "return rigidbody");
		code += Line (1, "}", 2);
		AddMethodCode (code);
		string call = "CreateRigidbody_" + name + "(gameObject, \"" + name + "\", \"" + path + "\")";
		AddMethodCallFromMain (call);
	}
	
	/// <summary>
	/// Decides which type of collider is processed and calls appropriate method for box, sphere or capsule collider. 
	/// The generated code checks will only create a collider if there is no existing one. A public member variable
	/// is generated for every dynamically created collider. Further on a reference to it is added to allColliders.
	/// </summary>
	private static void CreateColliderMethod (GameObject gameObject, Collider collider, string name, string path) {
		string code = Line (1, "internal virtual Collider CreateCollider_" + name + "(GameObject gameObject, string name, string path) {");
		code += Code (2, "Transform childTransform = gameObject.transform.FindChild (path)");
		code += Code (2, "GameObject childGameObject = childTransform.gameObject");
		code += Code (2, "Collider collider = childGameObject.GetComponent <Collider> ()");
		if (collider.GetType () == typeof(BoxCollider)) {
			code += CreateBoxColliderMethod (gameObject, (BoxCollider)collider, name, path);
		} else if (collider.GetType () == typeof(SphereCollider)) {
			code += CreateSphereColliderMethod (gameObject, (SphereCollider)collider, name, path);
		} else if (collider.GetType () == typeof(CapsuleCollider)) {
			code += CreateCapsuleColliderMethod (gameObject, (CapsuleCollider)collider, name, path);
		} else {
			Debug.LogWarning ("Unsupported collider " + collider.name + " of type " + collider.GetType ());
			return;
		}
		code += Code (2, "collider.isTrigger = " + MakeBool (collider.isTrigger));
		code += Code (2, "collider.material = " + physicMaterialLoadFragment);
		code += Code (2, "allColliders.Add (collider)");
		code += Code (2, "return collider");
		code += Line (1, "}", 2);
		AddMethodCode (code);
		string call = "CreateCollider_" + name + "(gameObject, \"" + name + "\", \"" + path + "\")";
		AddMethodCallFromMain (call);
	}
	
	private static string CreateBoxColliderMethod (GameObject gameObject, BoxCollider collider, string name, string path) {
		string publicMemberVar = name + "_BoxCollider";
		publicMemberVar = AddPublicMember ("BoxCollider", publicMemberVar);
		string code = Line (2, "if (collider == null) {");
		code += Code (3, "collider = childGameObject.AddComponent<BoxCollider> ()");
		code += Line (2, "}");
		code += Code (2, publicMemberVar + " = (BoxCollider)collider");
		code += Code (2, publicMemberVar + ".size = " + SetVector (collider.size));
		code += Code (2, publicMemberVar + ".center = " + SetVector (collider.center));
		return code;
	}
	
	private static string CreateSphereColliderMethod (GameObject gameObject, SphereCollider collider, string name, string path) {
		string publicMemberVar = name + "_SphereCollider";
		publicMemberVar = AddPublicMember ("SphereCollider", publicMemberVar);
		string code = Line (2, "if (collider == null) {");
		code += Code (3, "collider = childGameObject.AddComponent<SphereCollider> ()");
		code += Line (2, "}");
		code += Code (2, publicMemberVar + " = (SphereCollider)collider");
		code += Code (2, publicMemberVar + ".radius = " + MakeFloat (collider.radius));
		code += Code (2, publicMemberVar + ".center = " + SetVector (collider.center));
		return code;
	}
	
	private static string CreateCapsuleColliderMethod (GameObject gameObject, CapsuleCollider collider, string name, string path) {
		string publicMemberVar = name + "_CapsuleCollider";
		publicMemberVar = AddPublicMember ("CapsuleCollider", publicMemberVar);
		string code = Line (2, "if (collider == null) {");
		code += Code (3, "collider = childGameObject.AddComponent<CapsuleCollider> ()");
		code += Line (2, "}");
		code += Code (2, publicMemberVar + " = (CapsuleCollider)collider");
		code += Code (2, publicMemberVar + ".height = " + MakeFloat (collider.height));
		code += Code (2, publicMemberVar + ".center = " + SetVector (collider.center));
		code += Code (2, publicMemberVar + ".radius = " + MakeFloat (collider.radius));
		code += Code (2, publicMemberVar + ".direction = " + collider.direction);
		return code;
	}
	
	private static string Code (int tabs, string code, int noOfReturns) {
		return Line (tabs, code + ";", noOfReturns);
	}

	private static string Code (int tabs, string code) {
		return Code (tabs, code, 1);
	}

	private static string Line (int tabs, string code) {
		return Line (tabs, code, 1);
	}

	private static string Line (int tabs, string code, int noOfReturns) {
		string indent = "";
		for (int i = 0; i < tabs; i++) {
			indent += "\t";
		}
		string CRs = "";
		for (int i = 0; i < noOfReturns; i++) {
			CRs += "\n";
		}
		return indent + code + CRs;
	}
	
	private static string MakeBool (bool b) {
		return ("" + b).ToLower ();
	}
	
	private static string MakeFloat (float f) {
		if (f == Mathf.Infinity) {
			return "Mathf.Infinity";
		}
		return f + "f";
	}

	private static string SetVector (Vector3 v) {
		return "new Vector3 (" + MakeFloat (v.x) + ", " + MakeFloat (v.y) + ", " + MakeFloat (v.z) + ")";
	}
	
	private static string SetSoftJointLimit (int tabs, string varName, string limitMember, SoftJointLimit limit) {
		string newVar = limitMember + "New";
		string code = Code (tabs, "SoftJointLimit " + newVar + " = " + varName + "." + limitMember);
		code += Code (tabs, newVar + ".limit = " + MakeFloat (limit.limit));
		code += Code (tabs, newVar + ".spring = " + MakeFloat (limit.spring));
		code += Code (tabs, newVar + ".damper = " + MakeFloat (limit.damper));
		code += Code (tabs, newVar + ".bounciness = " + MakeFloat (limit.bounciness));
		code += Code (tabs, varName + "." + limitMember + " = " + newVar);
		
		return code;
	}
	
	private static string AddPublicMember (string typeName, string variableName) {
		string formattedVar = variableName.Substring (0, 1).ToLower () + variableName.Substring (1);
		publicMembersCode += Code (1, "public " + typeName + " " + formattedVar, 2);
		return formattedVar;
	}
	
	private static void AddMethodCallFromMain (string call) {
		publicInterfaceCode += Code (2, call);
	}
	
	private static void AddMethodCode (string code) {
		privateMethodsCode += code;
	}

	private static string MakeComment (int tabs, string comment) {
		string formatted = Line (tabs, "/// <summary>");
		List<string> lines = Wrap (comment, 120 - tabs * 4 - 4);
		foreach (string line in lines) {
			formatted += Line (tabs, "/// " + line);
		}
		return formatted + Line (tabs, "/// </summary>");
	}

	private static string ExportCode () {
		using (StreamWriter writer = new StreamWriter (targetCodeFile, false)) {
			try {
				writer.WriteLine ("{0}", classPrefixCode);
				writer.WriteLine ("{0}", publicMembersCode);
				writer.WriteLine ("{0}", publicInterfaceCode);
				writer.WriteLine ("{0}", privateMethodsCode);
				writer.WriteLine ("{0}", classPostfixCode);
			} catch (System.Exception ex) {
				string msg = " threw:\n" + ex.ToString ();
				Debug.LogError (msg);
				EditorUtility.DisplayDialog ("Error on export", msg, "OK");
			}
		}
		return targetCodeFile;
	}

	private static string GetPath (Transform childTransform) {
		string boneName = childTransform.name;
		boneName.Replace (" (UnityEngine.Rigidbody)", "");
		string path = boneName;
		for (int i = 0; childTransform.transform.parent != null && i < MaxModelDepth; i++) {
			string parentName = childTransform.transform.parent.name;
			parentName.Replace (" (UnityEngine.Rigidbody)", "");
			path = parentName + "/" + path;
			if (parentName.Equals ("Armature")) {
				return path;
			}
			childTransform = childTransform.transform.parent.transform;
		}
		throw new System.Exception("More than 20 steps in recursion!");
	}

	public static List<string> Wrap(string text, int maxLength) {              
		if (text.Length == 0) {
			return new List<string>();
		}
		char[] delimiters = new char[] {' ', '\n', '\t'};
		string[] words = text.Split(delimiters);
		List<string> lines = new List<string>();
		string currentLine = "";
		foreach (string currentWord in words)
		{
			if ((currentLine.Length > maxLength) ||
				((currentLine.Length + currentWord.Length) > maxLength))
			{
				lines.Add(currentLine);
				currentLine = "";
			}
			if (currentLine.Length > 0)
				currentLine += " " + currentWord;
			else
				currentLine += currentWord;
		}
		if (currentLine.Length > 0) {          
			lines.Add(currentLine);
		}
		return lines;
	}
 
}
