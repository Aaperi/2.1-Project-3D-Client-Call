using UnityEngine;
using System.Collections;

public class CheckIfGrounded : MonoBehaviour {

    public bool Grounded = true;
    menuScript menuScript;

    void Start()
    {
        menuScript = GameObject.FindObjectOfType(typeof(menuScript)) as menuScript;
    }

	// Update is called once per frame
	void Update () {
        CheckGrounded();
	}
    void CheckGrounded()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            if (hit.transform.GetComponent<Collider>() == null) return;
            Grounded = true;
        }
        else
        {
            Grounded = false;

        }
        if (Grounded && GetComponentInChildren<FireAttackScript>().canShoot() && !menuScript.canvasOn && !menuScript.paused) GetComponent<SmallBroMovement>().enabled = true;
        Debug.Log("SMALL BRO ===>>>>" + Grounded);
    }
}
