using UnityEngine;
using System.Collections;

public class GrassSpawn : MonoBehaviour
{
    public GameObject Grass;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            Instantiate(Grass, new Vector3(Random.Range(-12f, 13f), 0, Random.Range(-10f, 14f)), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
