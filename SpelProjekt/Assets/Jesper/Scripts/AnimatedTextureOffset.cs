using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(AnimatedTextureOffset))]
public class AnimatedTextureOffsetEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Lista alla material")) {
            foreach(Material m in Resources.FindObjectsOfTypeAll<Material>()) {
                Debug.Log(m.name);
            }
        }
    }
}
#endif
public class AnimatedTextureOffset : MonoBehaviour {
    public string jointName = "ENTER_JOINT_NAME";
    public int frameRate = 30;
    public bool lateUpdate;
	private GameObject jointController;
	private int jointScale;
	private float offsetRatio = 1;
	private float currentOffset = 0;
	private float previousOffset = 0;
	private float timer = 0;
    public Material commonFaceMaterial;
    Material myFaceMaterial;
    
	void Start () { enabled = FindAnimatedTexture(); }


    void LateUpdate() {
        if (lateUpdate) {
            SetAnimatedTextureOffset();
        }
    }
    void Update() {
        if (!lateUpdate) {
            SetAnimatedTextureOffset();
        }
    }

    GameObject FindChildByName(Transform root, string n) {
        if (!root) {
            return null;
        }
        Transform tChild = root.Find(n);
        if (tChild) {
            return tChild.gameObject;
        }
        for(int i = 0; i < root.childCount; i++) {
            GameObject go = FindChildByName(root.GetChild(i), n);
            if (go) {
                return go;
            }
        }
        return null;
    }

    bool FindAnimatedTexture(){
        // Find the joint that will be controlling the object,
        // or alert the user if it doesn't exist
        jointController = FindChildByName(transform.parent, jointName);

        if (!jointController) {
            Debug.LogWarning("Error in AnimatedTextureOffset (" + name + "): Could not find" + jointName);
            return false;
        }

        Renderer myRenderer = GetComponent<Renderer>();
		// Make sure a renderer exists on this object
		if(!myRenderer){
			print ("Error in AnimatedTextureOffset: Could not find a renderer on this object.");
			return false;
		}
        if (!commonFaceMaterial) {
            commonFaceMaterial = myRenderer.sharedMaterial;
        }
        int matIdx = 0;
        for(int i = 0; i < myRenderer.sharedMaterials.Length; i++) {
            if (myRenderer.sharedMaterials[i].name == commonFaceMaterial.name) {
                matIdx = i;
            }
        }
        Material[] tmpMats = myRenderer.materials;
        myRenderer.materials = tmpMats;
        myFaceMaterial = myRenderer.sharedMaterials[matIdx];

        myFaceMaterial = myRenderer.sharedMaterials[matIdx];
		// Determine offset ratio by querying the main texture
		Texture myTexture = myFaceMaterial.mainTexture;
		offsetRatio = (float)myTexture.height/(float)myTexture.width;

		// Set the texture scale for the element based on the found offset ratio
		Vector2 size = new Vector2 (offsetRatio, 1);
		myFaceMaterial.SetTextureScale  ("_MainTex", size);


		return true;
	}

	void SetAnimatedTextureOffset(){
		// This timer limits the script to only update a limited amount of times per
		// second, so it doesn't catch interim blended frames between two keys
		if(timer <= 0){
			// Find the controller object as specified (scaleX) and
			// multiply by the joint scale
			jointScale = (int) jointController.transform.localScale.x;
			currentOffset = jointScale*offsetRatio;

			// If the offset has changed, update the offset
			if(currentOffset != previousOffset){    
				Vector2 offset = new Vector2 (currentOffset, 0);
				myFaceMaterial.SetTextureOffset ("_MainTex", offset);
				previousOffset = currentOffset;
			}

			timer = (1/(float)frameRate);
		}
		else {
			timer -= Time.deltaTime;
		}
	}
}