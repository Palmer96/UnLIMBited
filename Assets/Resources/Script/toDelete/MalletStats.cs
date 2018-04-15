using UnityEngine;
using System.Collections;

public class MalletStats : MonoBehaviour
{
    public int attackPower;
    public float range;

    public float despawnTime;
    public float despawnTimer;

    public int knockbackForce;

   // public Attack.ArmType armtype;

    // Use this for initialization
    void Start()
    {
        attackPower = Random.Range(8, 10);
        range = 1.25f;

        despawnTime = Random.Range(15.0f, 20.0f);
        despawnTimer = 0.0f;

        knockbackForce = 0;

       // armtype = Attack.ArmType.Mallet;
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