using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour {
	[SerializeField]
	GameObject particles;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		transform.Rotate (new Vector3(0,1,0));
		Debug.DrawLine (transform.position, transform.forward * 5, Color.red);
	}
	
	// Update is called once per frame
	public void SetFire() {
		particles.SetActive (true);
	}
}
