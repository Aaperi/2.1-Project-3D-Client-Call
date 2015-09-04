using UnityEngine;
using System.Collections;

public class FireAttackScript : MonoBehaviour {

	[SerializeField]
	GameObject prefab;
    [HideInInspector]
    public Transform torchTransform;
	Vector3 rayDirection;
	float VisionAngle = 55;
	
	GameObject torch;

	bool isInRange = false;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.K)) {
			GameObject go = Instantiate(prefab,this.transform.position - this.transform.forward *1.5f, this.transform.rotation) as GameObject;
			go.transform.parent = this.transform;
			Destroy(go,1.7f);

			if (isInRange) {
				torch.GetComponent<TorchScript>().SetFire();
			}
		}
	}

	void OnTriggerEnter(Collider hit) {
		if (hit.transform.CompareTag ("Torch")) {
			torch = hit.gameObject;
			isInRange = true;
		}
	}

	void OnTriggerExit(Collider hit) {
		if (hit.transform.CompareTag ("Torch")) {
			isInRange = false;
		}
	}
}
