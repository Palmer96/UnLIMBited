using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = Vector3.Lerp(transform.position, Camera.transform.position, 0.1f);
        transform.Rotate(speed, speed, speed);
    }
}
