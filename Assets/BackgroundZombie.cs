using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundZombie : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float speed;

    public Vector3[] points;
    private int count;
    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Vector3.Distance(transform.position, points[count]) < 3)
        {
            transform.position = Vector3.Lerp(transform.position, points[count], speed);
            //transform.LookAt(points[count + 1]);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[count], speed * 10);
          //  transform.LookAt(points[count]);
        }
        Transform trans = transform;
        trans.LookAt(points[count+1]);

        transform.rotation = Quaternion.Lerp(transform.rotation, trans.rotation, speed);

        if (Vector3.Distance(transform.position, points[count]) < 1)
        {
            if (count == points.Length - 1)
            {
                count = 0;
            }
            else
                count++;
        }
    }
}
