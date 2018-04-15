using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour
{
    public GameObject[] Trees;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                Instantiate(Trees[Random.Range(0, 2)], new Vector3(i * Random.Range(1, 5), 0, j * Random.Range(1, 5)), transform.rotation);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
