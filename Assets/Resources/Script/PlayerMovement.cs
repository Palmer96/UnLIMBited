using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{

    public int intPlayerHealth;
    public int m_playerId;
    public float playerSpeed;
    public bool currentLeft;
    private Rigidbody rb;
    public GameObject Manager;
    public GameObject PrimaryArm;
    public GameObject secondaryArm;
    public GameObject noArm;
    public bool stunned;
    public float stunTimer;
    public float stunTime;

    public Animator anim;
    float moveHorizontal;
    float moveVertical;

    public bool attacking;
    public float attackSeparationTimer;
    public int attackSeparation;

    public GameObject head;

    public GameObject Lwrist;
    public GameObject Rwrist;

    private AudioSource aSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        currentLeft = false;
        PrimaryArm = transform.GetChild((int)PlayerLimbs.LimbSlot.RightArm).GetChild(0).gameObject;
        secondaryArm = transform.GetChild((int)PlayerLimbs.LimbSlot.LeftArm).GetChild(0).gameObject;
        stunned = false;
        stunTimer = 0.0f;
        stunTime = 3.0f;

        attacking = false;
        attackSeparationTimer = 1.0f;
        attackSeparation = 0;

        anim = transform.GetChild(4).GetComponent<Animator>();

        anim.SetTrigger("Climbing");
        stunned = true;
        stunTimer = 1.5f;

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Manager.GetComponent<Manager>().paused == false) // && Manager.GetComponent<GameUI>().gameOver == false)
        {
            if (!stunned)
            {

                // Get input form controller left stick
                moveHorizontal = Input.GetAxis("P" + m_playerId.ToString() + "_HorizontalMovement");
                moveVertical = Input.GetAxis("P" + m_playerId.ToString() + "_VerticalMovement");

                moveHorizontal += Input.GetAxis("Horizontal");
                moveVertical += Input.GetAxis("Vertical");

                if (moveHorizontal > 0.1f ||
                    moveHorizontal < -0.1f ||
                    moveVertical > 0.1f ||
                    moveVertical < -0.1f)
                {
                    anim.SetBool("Walk", true);
                    Vector3 rotate = new Vector3(moveHorizontal, 0.0f, moveVertical);
                    transform.forward = Vector3.Normalize(-rotate);
                }
                else
                {
                    anim.SetBool("Walk", false);
                }

                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                transform.position += movement * playerSpeed;


                PrimaryArm = transform.GetChild((int)PlayerLimbs.LimbSlot.LeftArm).GetChild(0).gameObject;
                secondaryArm = transform.GetChild((int)PlayerLimbs.LimbSlot.RightArm).GetChild(0).gameObject;

           //     Lwrist = PrimaryArm.GetComponent<Limb>().Wrist;
           //     Rwrist = secondaryArm.GetComponent<Limb>().Wrist;



                if (Input.GetButtonDown("P" + m_playerId.ToString() + "_A"))
                {
                    if (PrimaryArm.CompareTag("RA_Default") ||
                PrimaryArm.CompareTag("RA_Behemoth"))
                        anim.SetTrigger("LeftHit");
                    else
                        anim.SetTrigger("LeftSwing");
                    if (Lwrist.GetComponent<wrist>().attacking == false)
                    {
                 //       aSource.clip = PrimaryArm.GetComponent<Limb>().audioSwing;
                 //       aSource.Play();
                    }
                    Lwrist.GetComponent<wrist>().Attack();
                }

                if (Input.GetButtonDown("P" + m_playerId.ToString() + "_B"))
                {
                    if (secondaryArm.CompareTag("RA_Default") ||
                secondaryArm.CompareTag("RA_Behemoth"))
                        anim.SetTrigger("RightHit");
                    else
                        anim.SetTrigger("RightSwing");
                    if (Lwrist.GetComponent<wrist>().attacking == false)
                    {
             //           aSource.clip = secondaryArm.GetComponent<Limb>().audioSwing;
             //           aSource.Play();
                    }
                    Rwrist.GetComponent<wrist>().Attack();
                }
            }

            else
            {
                stunTimer -= Time.deltaTime;
                if (stunTimer < 0)
                {
                    stunned = false;
                }
            }


            //   if (Input.GetAxis("P" + m_playerId.ToString() + "_RightTrigger") > 0.5f)

            if (Input.GetButtonDown("P" + m_playerId.ToString() + "_A"))
            {
                if (Manager.GetComponent<Manager>().paused == true)
                {
                    Manager.GetComponent<Manager>().Pause();
                }
            }

        }
        else
        {
            anim.SetBool("Walk", false);
        }


        if (Input.GetButtonDown("P" + m_playerId.ToString() + "_Pause"))
        {
            Manager.GetComponent<Manager>().Pause();
        }

        if (Input.GetKeyDown(KeyCode.V))
            anim.SetTrigger("RightHit");
        if (Input.GetKeyDown(KeyCode.B))
            anim.SetTrigger("RightSwing");


    }




    void SwitchCurrentArm()
    {
        if (currentLeft)
        {
            if (transform.GetChild((int)PlayerLimbs.LimbSlot.RightArm).childCount != 0)
            {
                currentLeft = false;
            }
        }
        else
        {
            if (transform.GetChild((int)PlayerLimbs.LimbSlot.LeftArm).childCount != 0)
            {
                currentLeft = true;
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            if (diff.sqrMagnitude > 2)
            {
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        GameObject closest2 = null;
        float distance2 = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            if (go != closest)
            {
                Vector3 diff = go.transform.position - position;
                if (diff.sqrMagnitude > 2)
                {
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance2)
                    {
                        closest2 = go;
                        distance2 = curDistance;
                    }
                }
            }
        }
        return closest2;
    }

}