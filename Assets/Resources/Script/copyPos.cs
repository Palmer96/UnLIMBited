using UnityEngine;
using System.Collections;

public class copyPos : MonoBehaviour
{
    public GameObject other;
    public bool copy;

    public Vector3 offset;
    // Use this for initialization
    void Start()
    {
        copy = true;    
      //  other.transform.Rotate(180, 0, 0);
     //   if (Arms)
           // transform.GetChild(1).transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (copy && other != null)
        {
        other.transform.position = transform.position + offset;
        other.transform.rotation = transform.rotation;
        }
    }
}
