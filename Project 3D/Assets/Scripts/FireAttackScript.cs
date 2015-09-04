using UnityEngine;
using System.Collections;

public class FireAttackScript : MonoBehaviour {

	[SerializeField]
	GameObject prefab;
    [HideInInspector]
    public Transform torchTransform;
	Vector3 rayDirection;
	float VisionAngle = 55;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.K)) {
			GameObject go = Instantiate(prefab,this.transform.position+  this.transform.forward * 0.5f, this.transform.rotation) as GameObject;
			go.transform.parent = this.transform;
			Destroy(go,1.7f);	
			Hit();
	


		}
	}

	private void Hit() {
		RaycastHit hit;
		rayDirection = torchTransform.position - transform.position;
		
		
		
		if ((Vector3.Angle(rayDirection, transform.forward)) <= VisionAngle * 0.5f) {
			if (Physics.Raycast(transform.position, rayDirection, out hit, 3.5f)) {
				if (hit.transform.CompareTag("Torch")){
					Debug.Log("LIT UP !");
					hit.transform.GetComponent<TorchScript>().SetFire();
				}
			}
		}
	}
}
