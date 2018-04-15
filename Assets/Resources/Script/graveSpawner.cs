using UnityEngine;
using System.Collections;

public class graveSpawner : MonoBehaviour
{

    public GameObject[] Graves;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = i; j < 5; i++)
            {
                Instantiate(Graves[0], new Vector3(i * 1.5f, 0.5f, j * 1.5f), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    GameObject randGrave()
    {

        GameObject grave = Graves[Random.Range(0,Graves.Length)];

        return grave;
    }
}