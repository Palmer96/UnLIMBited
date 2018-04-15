using UnityEngine;
using System.Collections;

public class BehemothStats : MonoBehaviour
{
    public int attackPower;
    public float range;

    public float despawnTime;
    public float despawnTimer;

    public int knockbackForce;

   // Attack.ArmType armtype;

    //Rigidbody rigidbody;

    void Start()
    {
        attackPower = Random.Range(15, 20);
        range = 1.0f;

        despawnTime = Random.Range(10.0f, 20.0f);
        despawnTimer = 0.0f;

        knockbackForce = 250;

       // armtype = Attack.ArmType.Behemoth;
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