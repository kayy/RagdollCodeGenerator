/*
//  $Id: RagdollFactoryGenerated.cs $
//
//  IMPORTANT: GENERATED CODE  ==>  DO NOT EDIT!
//  Generated at 11/28/2011 16:30:02. Selected bone for generation was Hips
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

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles dynamic creation of ragdoll components for one specific model. As this is no dynamic ragdoll calculation but
/// rather a snapshot of the armature at one given point in time.Because this code was generated automatically by Unity
/// editor class RagdollCodeGenerator it should not be edited directly. All changes will be lost on regeneration! Instead
/// regenerate the code or edit the generator's code itself if you need significant changes in structure.
/// </summary>
public class RagdollFactoryGenerated {


	internal PhysicMaterial physicMaterial = (PhysicMaterial)Resources.LoadAssetAtPath ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));

	public List<Collider> allColliders = new List<Collider> ();

	public List<Rigidbody> allRigidbodies = new List<Rigidbody> ();

	public List<CharacterJoint> allCharacterJoints = new List<CharacterJoint> ();

	/// <summary>
	/// Main entry point of this class to be called for generating all ragdoll components on the fly. The supplied game
	/// object should be the armature's parent. Although all methods check for existing objects, it is not recommended to
	/// call this method multiple times without doing explicit clean up before.
	/// </summary>
	public string rootBoneName = "Armature/Hips";

	public Rigidbody hips_Rigidbody;

	public BoxCollider hips_BoxCollider;

	public BoxCollider ribs_BoxCollider;

	public Rigidbody ribs_Rigidbody;

	public CharacterJoint ribs_CharacterJoint;

	public SphereCollider head_SphereCollider;

	public Rigidbody head_Rigidbody;

	public CharacterJoint head_CharacterJoint;

	public CapsuleCollider upperArm_L_CapsuleCollider;

	public Rigidbody upperArm_L_Rigidbody;

	public CharacterJoint upperArm_L_CharacterJoint;

	public CapsuleCollider lowerArm_L_CapsuleCollider;

	public Rigidbody lowerArm_L_Rigidbody;

	public CharacterJoint lowerArm_L_CharacterJoint;

	public CapsuleCollider upperArm_R_CapsuleCollider;

	public Rigidbody upperArm_R_Rigidbody;

	public CharacterJoint upperArm_R_CharacterJoint;

	public CapsuleCollider lowerArm_R_CapsuleCollider;

	public Rigidbody lowerArm_R_Rigidbody;

	public CharacterJoint lowerArm_R_CharacterJoint;

	public CapsuleCollider thigh_L_CapsuleCollider;

	public Rigidbody thigh_L_Rigidbody;

	public CharacterJoint thigh_L_CharacterJoint;

	public CapsuleCollider shin_L_CapsuleCollider;

	public Rigidbody shin_L_Rigidbody;

	public CharacterJoint shin_L_CharacterJoint;

	public CapsuleCollider thigh_R_CapsuleCollider;

	public Rigidbody thigh_R_Rigidbody;

	public CharacterJoint thigh_R_CharacterJoint;

	public CapsuleCollider shin_R_CapsuleCollider;

	public Rigidbody shin_R_Rigidbody;

	public CharacterJoint shin_R_CharacterJoint;


	public virtual void CreateRagdollComponents(GameObject gameObject) {
		CreateRigidbody_Hips(gameObject, "Hips", "Armature/Hips");
		CreateCollider_Hips(gameObject, "Hips", "Armature/Hips");
		CreateCollider_Ribs(gameObject, "Ribs", "Armature/Hips/Spine/Ribs");
		CreateRigidbody_Ribs(gameObject, "Ribs", "Armature/Hips/Spine/Ribs");
		CreateCharacterJoint_Ribs(gameObject, "Ribs", "Armature/Hips/Spine/Ribs");
		CreateCollider_Head(gameObject, "Head", "Armature/Hips/Spine/Ribs/Neck/Head");
		CreateRigidbody_Head(gameObject, "Head", "Armature/Hips/Spine/Ribs/Neck/Head");
		CreateCharacterJoint_Head(gameObject, "Head", "Armature/Hips/Spine/Ribs/Neck/Head");
		CreateCollider_UpperArm_L(gameObject, "UpperArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L");
		CreateRigidbody_UpperArm_L(gameObject, "UpperArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L");
		CreateCharacterJoint_UpperArm_L(gameObject, "UpperArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L");
		CreateCollider_LowerArm_L(gameObject, "LowerArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L/LowerArm_L");
		CreateRigidbody_LowerArm_L(gameObject, "LowerArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L/LowerArm_L");
		CreateCharacterJoint_LowerArm_L(gameObject, "LowerArm_L", "Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L/LowerArm_L");
		CreateCollider_UpperArm_R(gameObject, "UpperArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R");
		CreateRigidbody_UpperArm_R(gameObject, "UpperArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R");
		CreateCharacterJoint_UpperArm_R(gameObject, "UpperArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R");
		CreateCollider_LowerArm_R(gameObject, "LowerArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R/LowerArm_R");
		CreateRigidbody_LowerArm_R(gameObject, "LowerArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R/LowerArm_R");
		CreateCharacterJoint_LowerArm_R(gameObject, "LowerArm_R", "Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R/LowerArm_R");
		CreateCollider_Thigh_L(gameObject, "Thigh_L", "Armature/Hips/Thigh_L");
		CreateRigidbody_Thigh_L(gameObject, "Thigh_L", "Armature/Hips/Thigh_L");
		CreateCharacterJoint_Thigh_L(gameObject, "Thigh_L", "Armature/Hips/Thigh_L");
		CreateCollider_Shin_L(gameObject, "Shin_L", "Armature/Hips/Thigh_L/Shin_L");
		CreateRigidbody_Shin_L(gameObject, "Shin_L", "Armature/Hips/Thigh_L/Shin_L");
		CreateCharacterJoint_Shin_L(gameObject, "Shin_L", "Armature/Hips/Thigh_L/Shin_L");
		CreateCollider_Thigh_R(gameObject, "Thigh_R", "Armature/Hips/Thigh_R");
		CreateRigidbody_Thigh_R(gameObject, "Thigh_R", "Armature/Hips/Thigh_R");
		CreateCharacterJoint_Thigh_R(gameObject, "Thigh_R", "Armature/Hips/Thigh_R");
		CreateCollider_Shin_R(gameObject, "Shin_R", "Armature/Hips/Thigh_R/Shin_R");
		CreateRigidbody_Shin_R(gameObject, "Shin_R", "Armature/Hips/Thigh_R/Shin_R");
		CreateCharacterJoint_Shin_R(gameObject, "Shin_R", "Armature/Hips/Thigh_R/Shin_R");
	}


	internal virtual Rigidbody CreateRigidbody_Hips(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		hips_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 3.125f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual Collider CreateCollider_Hips(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		hips_BoxCollider = childGameObject.AddComponent<BoxCollider> ();
		collider = hips_BoxCollider;
		hips_BoxCollider.size = new Vector3 (0.2708345f, 0.2262724f, 0.197055f);
		hips_BoxCollider.center = new Vector3 (0.0837656f, -6.705523E-08f, -0.004841924f);
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Collider CreateCollider_Ribs(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		ribs_BoxCollider = childGameObject.AddComponent<BoxCollider> ();
		collider = ribs_BoxCollider;
		ribs_BoxCollider.size = new Vector3 (0.12359f, 0.2262724f, 0.196419f);
		ribs_BoxCollider.center = new Vector3 (-0.06179501f, 2.980232E-08f, 0.035f);
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Ribs(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		ribs_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 3.125f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Ribs(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		ribs_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (-1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, 1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -20f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 20f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 10f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_Head(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		head_SphereCollider = childGameObject.AddComponent<SphereCollider> ();
		collider = head_SphereCollider;
		head_SphereCollider.radius = 0.1165681f;
		head_SphereCollider.center = new Vector3 (-0.13f, 0f, 0f);
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Head(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		head_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.25f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Head(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		head_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (-1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, 1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -40f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 25f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 25f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Spine/Ribs");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_UpperArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		upperArm_L_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = upperArm_L_CapsuleCollider;
		upperArm_L_CapsuleCollider.height = 0.2798699f;
		upperArm_L_CapsuleCollider.center = new Vector3 (-0.1399349f, 0f, 0f);
		upperArm_L_CapsuleCollider.radius = 0.06996747f;
		upperArm_L_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_UpperArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		upperArm_L_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.25f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_UpperArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		upperArm_L_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (0f, -1f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -70f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 10f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 50f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Spine/Ribs");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_LowerArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		lowerArm_L_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = lowerArm_L_CapsuleCollider;
		lowerArm_L_CapsuleCollider.height = 0.1698555f;
		lowerArm_L_CapsuleCollider.center = new Vector3 (-0.08492777f, 0f, 0f);
		lowerArm_L_CapsuleCollider.radius = 0.03397111f;
		lowerArm_L_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_LowerArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		lowerArm_L_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.25f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_LowerArm_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		lowerArm_L_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (0f, 0f, -1f);
		joint.swingAxis = new Vector3 (0f, -1f, 0f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -90f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 0f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 0f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Spine/Ribs/Shoulder_L/UpperArm_L");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_UpperArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		upperArm_R_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = upperArm_R_CapsuleCollider;
		upperArm_R_CapsuleCollider.height = 0.2798699f;
		upperArm_R_CapsuleCollider.center = new Vector3 (-0.1399349f, 0f, 0f);
		upperArm_R_CapsuleCollider.radius = 0.06996746f;
		upperArm_R_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_UpperArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		upperArm_R_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.25f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_UpperArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		upperArm_R_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (0f, -1f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -70f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 10f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 50f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Spine/Ribs");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_LowerArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		lowerArm_R_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = lowerArm_R_CapsuleCollider;
		lowerArm_R_CapsuleCollider.height = 0.1698554f;
		lowerArm_R_CapsuleCollider.center = new Vector3 (-0.0849277f, 0f, 0f);
		lowerArm_R_CapsuleCollider.radius = 0.03397108f;
		lowerArm_R_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_LowerArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		lowerArm_R_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.25f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_LowerArm_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		lowerArm_R_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (0f, 0f, -1f);
		joint.swingAxis = new Vector3 (0f, -1f, 0f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -90f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 0f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 0f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Spine/Ribs/Shoulder_R/UpperArm_R");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_Thigh_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		thigh_L_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = thigh_L_CapsuleCollider;
		thigh_L_CapsuleCollider.height = 0.3249351f;
		thigh_L_CapsuleCollider.center = new Vector3 (-0.1624676f, 0f, 0f);
		thigh_L_CapsuleCollider.radius = 0.09748054f;
		thigh_L_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Thigh_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		thigh_L_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.875f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Thigh_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		thigh_L_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -20f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 70f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 30f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_Shin_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		shin_L_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = shin_L_CapsuleCollider;
		shin_L_CapsuleCollider.height = 0.3590847f;
		shin_L_CapsuleCollider.center = new Vector3 (-0.1795424f, 0f, 0f);
		shin_L_CapsuleCollider.radius = 0.08977118f;
		shin_L_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Shin_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		shin_L_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.875f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Shin_L(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		shin_L_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -80f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 0f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 0f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Thigh_L");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_Thigh_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		thigh_R_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = thigh_R_CapsuleCollider;
		thigh_R_CapsuleCollider.height = 0.3249351f;
		thigh_R_CapsuleCollider.center = new Vector3 (-0.1624675f, 0f, 0f);
		thigh_R_CapsuleCollider.radius = 0.09748053f;
		thigh_R_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Thigh_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		thigh_R_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.875f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Thigh_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		thigh_R_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -20f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 70f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 30f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}

	internal virtual Collider CreateCollider_Shin_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Collider collider = childGameObject.GetComponent <Collider> ();
		if (collider != null) {
			Debug.LogWarning ("Existing collider " + collider.name + " found of type " + collider.GetType ());
			return null;
		}
		shin_R_CapsuleCollider = childGameObject.AddComponent<CapsuleCollider> ();
		collider = shin_R_CapsuleCollider;
		shin_R_CapsuleCollider.height = 0.3590847f;
		shin_R_CapsuleCollider.center = new Vector3 (-0.1795424f, 0f, 0f);
		shin_R_CapsuleCollider.radius = 0.08977118f;
		shin_R_CapsuleCollider.direction = 0;
		collider.isTrigger = false;
		collider.material = (PhysicMaterial) Resources.Load ("RuntimeMaterials/Physic/PlayerPhysicMaterial", typeof(PhysicMaterial));
		allColliders.Add (collider);
		return collider;
	}

	internal virtual Rigidbody CreateRigidbody_Shin_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		Rigidbody rigidbody = childGameObject.GetComponent <Rigidbody> ();
		if (rigidbody != null) {
			Debug.LogWarning ("Existing rigidbody " + rigidbody.name + " found");
			return null;
		}
		rigidbody = childGameObject.AddComponent <Rigidbody> ();
		shin_R_Rigidbody= rigidbody;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = true;
		rigidbody.mass = 1.875f;
		rigidbody.drag = 0f;
		rigidbody.angularDrag = 0.05f;
		rigidbody.interpolation = RigidbodyInterpolation.None;
		rigidbody.detectCollisions = true;
		rigidbody.constraints = RigidbodyConstraints.None;
		allRigidbodies.Add (rigidbody);
		return rigidbody;
	}

	internal virtual CharacterJoint CreateCharacterJoint_Shin_R(GameObject gameObject, string name, string path) {
		Transform childTransform = gameObject.transform.FindChild (path);
		GameObject childGameObject = childTransform.gameObject;
		CharacterJoint joint = childGameObject.GetComponent <CharacterJoint> ();
		if (joint != null) {
			Debug.LogWarning ("Existing joint " + joint.name + " found");
			return null;
		}
		joint = childGameObject.AddComponent <CharacterJoint> ();
		shin_R_CharacterJoint= joint;
		joint.breakForce = Mathf.Infinity;
		joint.breakTorque = Mathf.Infinity;
		joint.anchor = new Vector3 (0f, 0f, 0f);
		joint.axis = new Vector3 (1f, 0f, 0f);
		joint.swingAxis = new Vector3 (0f, 0f, -1f);
		SoftJointLimit lowTwistLimitNew = joint.lowTwistLimit;
		lowTwistLimitNew.limit = -80f;
		lowTwistLimitNew.spring = 0f;
		lowTwistLimitNew.damper = 0f;
		lowTwistLimitNew.bounciness = 0f;
		joint.lowTwistLimit = lowTwistLimitNew;
		SoftJointLimit highTwistLimitNew = joint.highTwistLimit;
		highTwistLimitNew.limit = 0f;
		highTwistLimitNew.spring = 0f;
		highTwistLimitNew.damper = 0f;
		highTwistLimitNew.bounciness = 0f;
		joint.highTwistLimit = highTwistLimitNew;
		SoftJointLimit swing1LimitNew = joint.swing1Limit;
		swing1LimitNew.limit = 0f;
		swing1LimitNew.spring = 0f;
		swing1LimitNew.damper = 0f;
		swing1LimitNew.bounciness = 0f;
		joint.swing1Limit = swing1LimitNew;
		SoftJointLimit swing2LimitNew = joint.swing2Limit;
		swing2LimitNew.limit = 0f;
		swing2LimitNew.spring = 0f;
		swing2LimitNew.damper = 0f;
		swing2LimitNew.bounciness = 0f;
		joint.swing2Limit = swing2LimitNew;
		 Transform parentTransform = gameObject.transform.FindChild ("Armature/Hips/Thigh_R");
		if (parentTransform == null) {
			Debug.LogWarning ("parentGameObject for " + childGameObject.name + " not found! Maybe initalisation is not yet done.");
			joint.connectedBody = null;
		} else {
			joint.connectedBody = parentTransform.gameObject.rigidbody;
		}
		allCharacterJoints.Add (joint);
		return joint;
	}


}

