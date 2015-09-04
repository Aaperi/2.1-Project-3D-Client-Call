using UnityEngine;
using System.Collections;

public class FireAttackScript : MonoBehaviour {

	[SerializeField]
	GameObject prefab;

	Vector3 rayDirection;
	float VisionAngle = 135f;

	// Use this for initialization
	
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
		rayDirection = transform.forward * 10 - transform.position;
		Debug.Log("hello");
		Debug.DrawLine ( transform.forward,transform.position, Color.yellow);
		
		if ((Vector3.Angle(rayDirection, transform.forward)) <= VisionAngle ) {
			if (Physics.Raycast(transform.position, rayDirection, out hit, 4f)) {
				if (hit.transform.CompareTag("Torch")){
					Debug.Log("hoi");
					hit.transform.GetComponent<TorchScript>().SetFire();
				}
			}
		}
	}
}
