using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSpline : MonoBehaviour {

	public GameObject path;
	Transform [] m_transfroms;
	bool reverse = false;

	public float speed = 1.0f;
	float startTime;
	float length;

	int index = 0;
	// Use this for initialization
	void Start () {
		m_transfroms = GetTransforms ();

		Camera.main.transform.position = m_transfroms [index].position;
		Camera.main.transform.rotation = m_transfroms [index].rotation;
	}

	Transform[] GetTransforms () {
		if (path != null) {
			List<Component> components = new List<Component>(path.GetComponentsInChildren(typeof(Transform)));
			List<Transform> transforms = components.ConvertAll(c => (Transform)c);

			transforms.Remove(path.transform);

			return transforms.ToArray();
		}
		return null;
	}

	public void MoveToNext() {
		reverse = false;
		index++;
		startTime = Time.time;
		length = Vector3.Distance (m_transfroms [index - 1].position, m_transfroms [index].position);
	}

	public void MoveTo(int pIndex) {
		index = pIndex;
		startTime = Time.time;
		length = Vector3.Distance (m_transfroms [index].position, m_transfroms [index - 1].position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			MoveToNext();
		}
	
		float distCovered = (Time.time - startTime) * speed;
		float completed = distCovered / length;

		if (index - 1 >= 0) {
			if (reverse) {
				Camera.main.transform.position = Vector3.Lerp (m_transfroms [index + 1].position, m_transfroms [index].position, completed);
				Camera.main.transform.rotation = Quaternion.Lerp (m_transfroms [index + 1].rotation, m_transfroms [index].rotation, completed);
			} else {
				Camera.main.transform.position = Vector3.Lerp (m_transfroms [index - 1].position, m_transfroms [index].position, completed);
				Camera.main.transform.rotation = Quaternion.Lerp (m_transfroms [index - 1].rotation, m_transfroms [index].rotation, completed);
			}
		}
	}
}
