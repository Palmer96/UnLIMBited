using UnityEngine;
using System.Collections;

public class FryingPanStats : MonoBehaviour
{
    public int attackPower;
    public float range;

    public float despawnTime;
    public float despawnTimer;

    public int knockbackForce;

   // Attack.ArmType armtype;

    // Use this for initialization
    void Start()
    {
        attackPower = Random.Range(10, 13);
        range = 1.5f;

        despawnTime = Random.Range(15.0f, 20.0f);
        despawnTimer = 0.0f;

        knockbackForce = 250;

      //  armtype = Attack.ArmType.FryingPan;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)   //if arm is on the ground
        {
            despawnTimer += Time.deltaTime;     //despawn timer counts up

            if (despawnTimer >= despawnTime)    //once despawn timer is equal to a certain time
            {
                Destroy(this.gameObject);
            }
        }
    }

}