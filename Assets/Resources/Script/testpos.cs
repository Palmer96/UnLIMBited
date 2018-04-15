using UnityEngine;
using System.Collections;

public class testpos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("x: " + transform.position.x + ", y: " + transform.position.y + ", z: " + transform.position.z);
	}
}
