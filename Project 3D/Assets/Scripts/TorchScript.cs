using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour {

	[SerializeField]
	GameObject particles;
    [HideInInspector]
    public bool isLit = false;


	// Update is called once per frame
	public void SetFire() {
		particles.SetActive (true);
        isLit = true;
	}
}
