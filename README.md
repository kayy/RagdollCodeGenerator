RagdollCodeGenerator
====================

Code generator that saves all ragdoll components in a C# factory class which you can invoke at runtime.

Using Unity's ragdoll wizard leads to the problem that the prefab connection to the character 
model is broken. That means after a change of the model in your 3D software yo have to perform the 
whole procedure again. To avoid this I wrote an open source code generator that saves all ragdoll 
components in a C# factory class which you can invoke at runtime.
