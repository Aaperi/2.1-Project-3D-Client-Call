using UnityEngine;
using System.Collections;

public class FireAttackScript : MonoBehaviour {
	//Components
	[SerializeField]
	GameObject prefabFire;
	[SerializeField]
	GameObject prefabWater;
	[HideInInspector]
	public Transform torchTransform;
	GameObject torch;
	private SmallBroMovement smallBroMovement;
	private CheckIfGrounded checkGrounded;
	
	
	
	float nextFireTime;
	float delayFire = 1.5f;
	
	//Variables
	bool isInRange = false;
	void Start()
	{
		smallBroMovement = GetComponentInParent<SmallBroMovement>();
		checkGrounded = GetComponentInParent<CheckIfGrounded>();
	}
	// Update is called once per frame
	void Update () {
		
		if (canShoot() && checkGrounded.Grounded) {
			
			if (Input.GetKeyDown(KeyCode.K)) {
				GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
				smallBroMovement.enabled = false;
				
				
				
				if (isInRange) {
					if (!torch.GetComponent<TorchScript>().isLit) {
						GameObject go = Instantiate(prefabFire, this.transform.position - this.transform.forward * 1.5f, this.transform.rotation) as GameObject;
						go.transform.parent = this.transform;
						Destroy(go, 1.7f);
						torch.GetComponent<TorchScript>().SetFire();
					}else {
						GameObject go = Instantiate(prefabWater, this.transform.position - this.transform.forward * 1.5f, this.transform.rotation) as GameObject;
						go.transform.parent = this.transform;
						Destroy(go, 1.7f);
						torch.GetComponent<TorchScript>().ExtinguishFire();
					}
				} else{
					GameObject go = Instantiate(prefabFire, this.transform.position - this.transform.forward * 1.5f, this.transform.rotation) as GameObject;
					go.transform.parent = this.transform;
					Destroy(go, 1.7f);
				}
				nextFireTime = Time.time + delayFire;
			}
		}
		
	}
	public bool canShoot()
	{
		if (Time.time < nextFireTime)
		{
			return false;
		} else {
			return true;
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