using UnityEngine;
using System.Collections;

public class Pumpkin : MonoBehaviour
{
    public bool destroyed;
    // Use this for initialization
    void Start()
    {
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyed)
        {
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(2).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(3).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(4).GetComponent<Rigidbody>().isKinematic = false;

            transform.GetChild(0).GetComponent<MeshCollider>().isTrigger = false;
            transform.GetChild(1).GetComponent<MeshCollider>().isTrigger = false;
            transform.GetChild(2).GetComponent<MeshCollider>().isTrigger = false;
            transform.GetChild(3).GetComponent<MeshCollider>().isTrigger = false;
            transform.GetChild(4).GetComponent<MeshCollider>().isTrigger = false;

        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Hand"))
        {
                if (col.GetComponent<wrist>().attacking)
                {
                destroyed = true;
                transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(2).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(3).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(4).GetComponent<Rigidbody>().isKinematic = false;



            }
        }
    }
}
