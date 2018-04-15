using UnityEngine;
using System.Collections;

public class positionmove : MonoBehaviour
{
    public Transform[] pos;
    public int num;
    public Transform destination;
    // Use this for initialization
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {

        destination = pos[num];

        transform.position = Vector3.Lerp(transform.position, pos[num].position, 0.05f);
        transform.rotation = Quaternion.Lerp(transform.rotation, pos[num].rotation, 0.05f);

    }
}
