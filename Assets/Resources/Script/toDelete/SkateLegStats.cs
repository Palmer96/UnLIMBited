using UnityEngine;
using System.Collections;

public class SkateLegStats : MonoBehaviour
{
    public float speed;

    public float despawnTime;
    public float despawnTimer;

    // Use this for initialization
    void Start()
    {
        despawnTime = Random.Range(15.0f, 20.0f);
        despawnTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)   //if arm is on the ground
        {
            despawnTimer += Time.deltaTime;     //despawn timer counts up

            if (despawnTimer >= despawnTime)    //once despawn timer is equal to a certain time
            {
                Destroy(this.gameObject);           //destroy arm
            }
        }
    }
}
