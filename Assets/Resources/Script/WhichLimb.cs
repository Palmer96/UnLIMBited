using UnityEngine;
using System.Collections;

public class WhichLimb : MonoBehaviour {
    public int LimbLocation;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  Destroy(gameObject);
        }
    }
}
