using UnityEngine;
using System.Collections;

public class defaultArmStats : MonoBehaviour
{
    public int attackPower;
    public int attackMin;
    public int attackMax;
    public float range;

    public float despawnTime;
    public float despawnMin;
    public float despawnMax;
    public float despawnTimer;

    public int knockbackForce;

   // Attack.ArmType armtype;

    // Use this for initialization
    void Start()
    {
		attackPower = 5;
        range = 1.0f;

        despawnTime = Random.Range(despawnMin, despawnMax);
        despawnTimer = 0.0f;

        knockbackForce = 50;

      //  armtype = Attack.ArmType.defaultArm;
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