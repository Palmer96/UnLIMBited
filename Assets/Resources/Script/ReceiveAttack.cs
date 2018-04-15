using UnityEngine;
using System.Collections;
public class ReceiveAttack : MonoBehaviour
{
    public float stunTimer;
    public float stunTime;
    public bool stunned;
    public float burnTimer;
    public float burnTime;
    public bool burning;
    public float burningTimer;
    public float burningRate;
    public int burnAmount;
    private Rigidbody rb;
    public bool alive;
    public int health;
    public bool showHealth;

    private Vector3 startPos;

    public int lives;

    public bool canBeHit;
    public float hitTimer;
    public float hitRate;

    public AudioClip audioStun;
    public AudioClip audioBurn;
    private AudioSource aSource;

    public GameObject leftArm;
    public GameObject rightArm;

    public Material defaultMat;

    public GameObject Hat;
    public GameObject TorsoObj;
    public Material TorsoBody;

    public GameObject Blood;
    public Color colour;
    public GameObject Cloud;


    public GameObject stunParticle;
    public GameObject burnParticle;
    public GameObject dirtParticle;

    public int burnCount;

    public Animator anim;

    private float invincibleTimer;

    // Use this for initialization
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        startPos = transform.position;
        stunTimer = 0.0f;
        stunTime = 3.0f;
        stunned = false;
        alive = true;
        health = 100;
        burnTimer = 4.0f;
        burning = false;
        burningTimer = 1.0f;
        burningRate = burningTimer;
        burnAmount = 3;
        rb = GetComponent<Rigidbody>();
        hitRate = 0.2f;
        hitTimer = hitRate;
        canBeHit = true;
        burnCount = 0;
        lives = 3;
        invincibleTimer = 0;
        anim = transform.GetChild(4).GetComponent<Animator>();

        GameObject DirtPart = (GameObject)Instantiate(dirtParticle, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);

        DirtPart.GetComponent<DeathTimer>().timer = 5;
        DirtPart.GetComponent<DeathTimer>().Rate = 5;
    }
    // Update is called once per frame
    void Update()
    {
        invincibleTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Death();
        }


        if (health <= 0)
        {
            Death();
        }


        hitTimer -= Time.deltaTime;

        if (hitTimer < 0)
        {
            canBeHit = true;
        }
        else
        {
            canBeHit = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            burning = true;

            aSource.clip = audioBurn;
            aSource.Play();
            burningTimer = 3;
            burnAmount = 1;
        }
        if (burning == true)
        {

            burningTimer -= Time.deltaTime;
            if (burningTimer <= 0)
            {
                aSource.clip = audioBurn;
                aSource.Play();
                burningTimer = burningRate;
                health -= burnAmount;
                burnCount++;

                GameObject BurnPart = (GameObject)Instantiate(burnParticle, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
                BurnPart.transform.SetParent(transform);
                BurnPart.GetComponent<DeathTimer>().timer = 2;
                BurnPart.GetComponent<DeathTimer>().Rate = 2;
            }
            if (burnCount == 3)
            {
                aSource.Stop();
                burning = false;

            }
        }

    }
    void OnTriggerEnter(Collider col)
    {
     //   if (invincibleTimer < 0)
     //   {
     //       rb.isKinematic = false;
     //       if (col.gameObject.CompareTag("Hand"))
     //       {
     //           if (canBeHit)
     //           {
     //               if (!ContainsGameObject(gameObject, col.gameObject))
     //               {
     //                   if (col.GetComponent<wrist>().attacking)
     //                   {
     //                       Vector3 directionToTarget = transform.position - col.transform.parent.parent.parent.transform.position;
     //                       float angle = Vector3.Angle(transform.forward, directionToTarget);
     //                       if (Mathf.Abs(angle) > 90 || Mathf.Abs(angle) < 180)
     //                       {
     //                           hitTimer = hitRate;
     //                           //Vector3 dir = this.transform.position - col.transform.position;
     //                           Vector3 dir = -col.transform.parent.parent.parent.parent.parent.transform.forward;
     //                           dir.y = 0;
     //
     //                           GetComponent<PlayerMovement>().anim.SetTrigger("Knockback");
     //                           if (GetComponent<PlayerMovement>().stunned == false)
     //                           {
     //                               if (col.transform.parent.parent.parent.GetComponent<Limb>().stun)
     //                               {
     //                                   GetComponent<PlayerMovement>().stunned = true;
     //                                   GetComponent<PlayerMovement>().stunTimer = col.transform.parent.parent.parent.GetComponent<Limb>().stunTimer;
     //
     //                                   GameObject StunPart = (GameObject)Instantiate(stunParticle, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
     //                                   StunPart.transform.SetParent(transform);
     //                                   StunPart.GetComponent<DeathTimer>().timer = GetComponent<PlayerMovement>().stunTimer;
     //                                   StunPart.GetComponent<DeathTimer>().Rate = GetComponent<PlayerMovement>().stunTimer;
     //                               }
     //                           }
     //
     //                           transform.rotation = Quaternion.LookRotation(transform.position - col.transform.parent.parent.parent.parent.parent.transform.position);
     //
     //                           aSource.clip = col.transform.parent.parent.parent.GetComponent<Limb>().audioHit;
     //                           aSource.Play();
     //
     //
     //                           Vector3 force = dir.normalized * col.transform.parent.parent.parent.GetComponent<Limb>().knockbackForce;
     //                           rb.AddForce(force * 10, ForceMode.Force);
     //                           health -= col.transform.parent.parent.parent.GetComponent<Limb>().attackPower / 2;
     //
     //                           if (!burning)
     //                           {
     //                               burning = col.transform.parent.parent.parent.GetComponent<Limb>().bBurn;
     //                               burnCount = 0;
     //                               aSource.clip = audioBurn;
     //                               aSource.Play();
     //                               burningRate = col.transform.parent.parent.parent.GetComponent<Limb>().burnTimer;
     //                               burningTimer = burningRate;
     //                               burnAmount = col.transform.parent.parent.parent.GetComponent<Limb>().burnDPS;
     //
     //                               GameObject BurnPart = (GameObject)Instantiate(burnParticle, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
     //                               BurnPart.transform.SetParent(transform);
     //                               BurnPart.GetComponent<DeathTimer>().timer = burningTimer;
     //                               BurnPart.GetComponent<DeathTimer>().Rate = burningTimer;
     //                           }
     //
     //
     //                       }
     //                   }
     //               }
     //           }
     //       }
     //   }
    }
    bool ContainsGameObject(GameObject currentGO, GameObject go)
    {
        if (currentGO == go)
        {
            return true;
        }
        if (currentGO.transform.childCount == 0)
        {
            return false;
        }
        bool bCollided = false;
        for (int i = 0; i < currentGO.transform.childCount; ++i)
        {
            bCollided = ContainsGameObject(currentGO.transform.GetChild(i).gameObject, go);
            if (bCollided)
            {
                return true;
            }
        }
        return false;
    }



    public void Death()
    {

        health = 100;
        lives--;


        burning = false;

        for (int i = 6; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject != null)
                Destroy(transform.GetChild(i).gameObject);
        }

        GameObject Head = (GameObject)Instantiate(transform.GetChild(5).GetChild(0).gameObject, transform.GetChild(5).GetChild(0).position, transform.GetChild(5).GetChild(0).rotation);
        Head.AddComponent<Rigidbody>();
        Head.AddComponent<SphereCollider>();
        Head.GetComponent<SphereCollider>().center = new Vector3(-0.56f, 0, -0.2f);
        Head.GetComponent<SphereCollider>().radius = 0.75f;

        GameObject hat = (GameObject)Instantiate(Hat, Head.transform.position, Head.transform.rotation);
        hat.AddComponent<Rigidbody>();
        hat.AddComponent<SphereCollider>();


        GameObject Torso = (GameObject)Instantiate(TorsoObj, transform.GetChild(5).GetChild(0).position, transform.GetChild(5).GetChild(0).rotation);
        // Torso.GetComponent<Renderer>().material = TorsoBody;

        leftArm.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = defaultMat;
        GameObject Larm = (GameObject)Instantiate(leftArm, transform.position, transform.rotation);
        Larm.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = defaultMat;
        Larm.transform.localScale = new Vector3(-1, -1, -1);
        GetComponent<PlayerLimbs>().AttachLimb(PlayerLimbs.LimbSlot.LeftArm, Larm);


        rightArm.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = defaultMat;
        GameObject Rarm = (GameObject)Instantiate(rightArm, transform.position, transform.rotation);
        Rarm.transform.GetChild(1).GetChild(0).GetComponent<Renderer>().material = defaultMat;
        GetComponent<PlayerLimbs>().AttachLimb(PlayerLimbs.LimbSlot.RightArm, Rarm);


        GameObject Lleg = (GameObject)Instantiate(transform.GetChild(2).GetChild(0).gameObject, transform.GetChild(5).GetChild(0).position, transform.GetChild(5).GetChild(0).rotation);
        Lleg.GetComponent<Rigidbody>().isKinematic = false;
        Lleg.GetComponent<CapsuleCollider>().enabled = true;
        Lleg.GetComponent<CapsuleCollider>().center = new Vector3(0.6f, 0, 0);


        GameObject Rleg = (GameObject)Instantiate(transform.GetChild(3).GetChild(0).gameObject, transform.GetChild(5).GetChild(0).position, transform.GetChild(5).GetChild(0).rotation);
        Rleg.GetComponent<Rigidbody>().isKinematic = false;
        Rleg.GetComponent<CapsuleCollider>().enabled = true;
        Rleg.GetComponent<CapsuleCollider>().center = new Vector3(0.6f, 0, 0);


        float rate = 5;
        Head.AddComponent<DeathTimer>();
        Head.GetComponent<DeathTimer>().Rate = rate;

        hat.AddComponent<DeathTimer>();
        hat.GetComponent<DeathTimer>().Rate = rate;

        Torso.AddComponent<DeathTimer>();
        Torso.GetComponent<DeathTimer>().Rate = rate;

        Lleg.AddComponent<DeathTimer>();
        Lleg.GetComponent<DeathTimer>().Rate = rate;

        Rleg.AddComponent<DeathTimer>();
        Rleg.GetComponent<DeathTimer>().Rate = rate;

        GameObject blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Head.transform);
        blood.transform.localPosition = new Vector3(0, -0.65f, -0.35f);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Lleg.transform);
        blood.transform.localPosition = new Vector3(0.6f, 0.6f, 0);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Rleg.transform);
        blood.transform.localPosition = new Vector3(0.6f, 0.6f, 0);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Torso.transform);
        blood.transform.localPosition = new Vector3(-0.6f, 0.8f, 0);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Torso.transform);
        blood.transform.localPosition = new Vector3(0.6f, 0.8f, 0);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Torso.transform);
        blood.transform.localPosition = new Vector3(-0.5f, -0.3f, 0);

        blood = (GameObject)Instantiate(Blood, transform.position, transform.rotation);
        blood.transform.SetParent(Torso.transform);
        blood.transform.localPosition = new Vector3(0.5f, -0.3f, 0);

        // GameObject hat = (GameObject)Instantiate(Hat, Head.transform.position, Head.transform.rotation);

        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);

        transform.position = startPos;

        if (lives == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            GameObject DirtPart = (GameObject)Instantiate(dirtParticle, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
            DirtPart.GetComponent<DeathTimer>().timer = 5f;
            DirtPart.GetComponent<DeathTimer>().Rate = 5f;
        }

        anim.SetTrigger("Climbing");
        rb.isKinematic = true;

        GetComponent<PlayerMovement>().stunned = true;
        GetComponent<PlayerMovement>().stunTimer = 1.5f;
        invincibleTimer = 1.5f;
    }
}