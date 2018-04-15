using UnityEngine;
using System.Collections;

public class PlayerLimbs : MonoBehaviour
{
    public enum LimbSlot
    {
        LeftArm = 0,
        RightArm = 1,
        LeftLeg = 2,
        RightLeg = 3,
        NoLimb = 4,
    }
    public GameObject noArm;

    public Animator anim;

    public GameObject Head;
    public GameObject L_Arm;
    public GameObject R_Arm;
    public GameObject L_Leg;
    public GameObject R_Leg;


    public int health;
    public int maxHealth;
    public int limbCount;
    //   LimbSlot randLimb;

    private bool started;

    public GameObject changeBlood;

    // Use this for initialization
    void Start()
    {
        maxHealth = 100;
        limbCount = 2;

        anim = transform.GetChild(4).GetComponent<Animator>();

        L_Arm.GetComponent<copyPos>().other = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        L_Arm.transform.GetChild(0).GetComponent<copyPos>().other = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        L_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;


        R_Arm.GetComponent<copyPos>().other = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        R_Arm.transform.GetChild(0).GetComponent<copyPos>().other = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        R_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;

        L_Leg.GetComponent<copyPos>().other = transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        L_Leg.transform.GetChild(0).GetComponent<copyPos>().other = transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
        L_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;

        R_Leg.GetComponent<copyPos>().other = transform.GetChild(3).GetChild(0).GetChild(0).gameObject;
        R_Leg.transform.GetChild(0).GetComponent<copyPos>().other = transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).gameObject;
        R_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;

        Head.GetComponent<copyPos>().other = transform.GetChild(5).GetChild(0).GetChild(0).gameObject;

        started = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DetachLimb(LimbSlot limb)
    {
        transform.GetChild((int)limb).GetChild(0).rotation = Quaternion.identity;
        transform.GetChild((int)limb).GetChild(0).GetChild(0).rotation = Quaternion.identity;
        transform.GetChild((int)limb).GetChild(0).GetChild(0).GetChild(0).rotation = Quaternion.identity;
        transform.GetChild((int)limb).GetChild(0).GetChild(0).GetChild(0).GetChild(0).rotation = Quaternion.identity;
        transform.GetChild((int)limb).GetChild(0).GetComponentInChildren<Rigidbody>().isKinematic = false;
        transform.GetChild((int)limb).GetChild(0).GetComponentInChildren<CapsuleCollider>().enabled = true;
        transform.GetChild((int)limb).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<CapsuleCollider>().enabled = false;
        // transform.GetChild((int)limb).GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), Random.Range(0, 3), Random.Range(-10, 10)));
      //  transform.GetChild((int)limb).GetChild(0).GetComponent<Limb>().Detach();
        //  transform.GetChild((int)limb).GetChild(0).GetComponent<Rigidbody>().AddForce(transform.GetChild((int)limb).GetChild(0).transform.position - transform.position);
        switch (limb)
        {
            case LimbSlot.LeftArm:
                L_Arm.GetComponent<copyPos>().other = null;//_Arm;
                L_Arm.transform.GetChild(0).GetComponent<copyPos>().other = null;//_Arm.transform.GetChild(0).gameObject;
                L_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = null;//L_Arm.transform.GetChild(0).GetChild(0).gameObject;
                L_Arm.GetComponent<copyPos>().copy = false;//_Arm;
                L_Arm.transform.GetChild(0).GetComponent<copyPos>().copy = false;//_Arm.transform.GetChild(0).gameObject;
                L_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().copy = false;//L_Arm.transform.GetChild(0).GetChild(0).gameObject;

                break;
            case LimbSlot.RightArm:
                R_Arm.GetComponent<copyPos>().other = null;//_Arm;
                R_Arm.transform.GetChild(0).GetComponent<copyPos>().other = null;//_Arm.transform.GetChild(0).gameObject;
                R_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = null;//L_Arm.transform.GetChild(0).GetChild(0).gameObject;
                R_Arm.GetComponent<copyPos>().copy = false;//_Arm;
                R_Arm.transform.GetChild(0).GetComponent<copyPos>().copy = false;//_Arm.trans
                R_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().copy = false;
                break;
            case LimbSlot.LeftLeg:
                L_Leg.GetComponent<copyPos>().other = L_Leg;
                L_Leg.transform.GetChild(0).GetComponent<copyPos>().other = L_Leg.transform.GetChild(0).gameObject;
                L_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = L_Leg.transform.GetChild(0).GetChild(0).gameObject;
                break;
            case LimbSlot.RightLeg:
                R_Leg.GetComponent<copyPos>().other = R_Leg;
                R_Leg.transform.GetChild(0).GetComponent<copyPos>().other = R_Leg.transform.GetChild(0).gameObject;
                R_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = R_Leg.transform.GetChild(0).GetChild(0).gameObject;
                break;
        }


        transform.GetChild((int)limb).DetachChildren();
        //AttachLimb(limb, noArm);

    }

    public void AttachLimb(LimbSlot limb, GameObject LimbType)
    {

        DetachLimb(limb);

        // transform.GetChild((int)limb).DetachChildren();
        LimbType.transform.position = transform.GetChild((int)limb).position;

        //        LimbType.transform.parent = transform.GetChild((int)limb);
        LimbType.transform.SetParent(transform.GetChild((int)limb).transform);
        LimbType.transform.parent = transform.GetChild((int)limb);
        LimbType.transform.rotation = transform.GetChild((int)limb).rotation;
        limbCount++;
        transform.GetChild((int)limb).GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
        transform.GetChild((int)limb).GetChild(0).GetComponent<CapsuleCollider>().enabled = false;
        transform.GetChild((int)limb).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<CapsuleCollider>().enabled = true;
        switch (limb)
        {
            case LimbSlot.LeftArm:
                L_Arm.GetComponent<copyPos>().other = LimbType.transform.GetChild(0).gameObject;
                L_Arm.transform.GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).gameObject;
                L_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                L_Arm.GetComponent<copyPos>().copy = true;
                L_Arm.transform.GetChild(0).GetComponent<copyPos>().copy = true;
                L_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().copy = true;
                break;
            case LimbSlot.RightArm:
                R_Arm.GetComponent<copyPos>().other = LimbType.transform.GetChild(0).gameObject;
                R_Arm.transform.GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).gameObject;
                R_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                R_Arm.GetComponent<copyPos>().copy = true;
                R_Arm.transform.GetChild(0).GetComponent<copyPos>().copy = true;
                R_Arm.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().copy = true;
                break;
            case LimbSlot.LeftLeg:
                L_Leg.GetComponent<copyPos>().other = LimbType.transform.GetChild(0).gameObject;
                L_Leg.transform.GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).gameObject;
                L_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                break;
            case LimbSlot.RightLeg:
                R_Leg.GetComponent<copyPos>().other = LimbType.transform.GetChild(0).gameObject;
                R_Leg.transform.GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).gameObject;
                R_Leg.transform.GetChild(0).GetChild(0).GetComponent<copyPos>().other = LimbType.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                break;
        }

    }


    void OnTriggerStay(Collider other)
    {

        if (Input.GetButton("P" + GetComponent<PlayerMovement>().m_playerId.ToString() + "_X"))
        {
            if (other.gameObject.CompareTag("RA_Default") ||
                other.gameObject.CompareTag("RA_Behemoth") ||
                other.gameObject.CompareTag("RA_Fryingpan") ||
                other.gameObject.CompareTag("RA_Mallet") ||
                other.gameObject.CompareTag("RA_Golf"))
            {
                if (other.gameObject.CompareTag("RA_Behemoth"))
                    other.transform.localScale = new Vector3(-1.5f, -1.5f, -1.5f);
                else
                    other.transform.localScale = new Vector3(-1, -1, -1);

                AttachLimb(LimbSlot.LeftArm, other.gameObject);
                GameObject Blood = (GameObject)Instantiate(changeBlood, transform.position, transform.rotation);
                Blood.transform.SetParent(transform);
                Blood.transform.localPosition = new Vector3(-0.6f, 0.8f, 0);

                
                anim.SetTrigger("PickupLeft");
            }
        }
        /////////////////////////////////

       else if (Input.GetButton("P" + GetComponent<PlayerMovement>().m_playerId.ToString() + "_Y"))
        {
            if (other.gameObject.CompareTag("RA_Default") ||
            other.gameObject.CompareTag("RA_Behemoth") ||
            other.gameObject.CompareTag("RA_Fryingpan") ||
            other.gameObject.CompareTag("RA_Mallet") ||
            other.gameObject.CompareTag("RA_Golf"))
            {
                if (other.gameObject.CompareTag("RA_Behemoth"))
                    other.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                else
                    other.transform.localScale = new Vector3(1, 1, 1);

                AttachLimb(LimbSlot.RightArm, other.gameObject);
                GameObject Blood = (GameObject)Instantiate(changeBlood, transform.position, transform.rotation);
                Blood.transform.SetParent(transform);
                Blood.transform.localPosition = new Vector3(-0.6f, 0.8f, 0);

                anim.SetTrigger("PickupRight");
            }
        }

        /////////////////////////////////

    }
}