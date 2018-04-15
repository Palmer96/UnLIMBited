using UnityEngine;
using System.Collections;

public class LimbSelect : MonoBehaviour
{
    public GameObject Player1Hat;
    public GameObject Player1Lleg;
    public GameObject Player1Rleg;

    public GameObject Player2Hat;
    public GameObject Player2Lleg;
    public GameObject Player2Rleg;

    public GameObject Player3Hat;
    public GameObject Player3Lleg;
    public GameObject Player3Rleg;

    public GameObject Player4Hat;
    public GameObject Player4Lleg;
    public GameObject Player4Rleg;


    public GameObject[] HatsPrefab;
    public GameObject[] LegsPrefab;


    // Use this for initialization
    void Awake()
    {
       // Destroy(Player1Lleg.transform.GetChild(0).gameObject);
       // Destroy(Player1Rleg.transform.GetChild(0).gameObject);
       // 
       // Destroy(Player2Lleg.transform.GetChild(0).gameObject);
       // Destroy(Player2Rleg.transform.GetChild(0).gameObject);
       // 
       // Destroy(Player3Lleg.transform.GetChild(0).gameObject);
       // Destroy(Player3Rleg.transform.GetChild(0).gameObject);
       // 
       // Destroy(Player4Lleg.transform.GetChild(0).gameObject);
       // Destroy(Player4Rleg.transform.GetChild(0).gameObject);

        //----------------------------------------------------------------------------------//

        int hatCount = PlayerPrefs.GetInt("P1_Hat");
        int legCount = PlayerPrefs.GetInt("P1_Leg");

        Vector3 pos = new Vector3(Player1Hat.transform.position.x, Player1Hat.transform.position.y - 0.15f, Player1Hat.transform.position.z);
        GameObject Hat = (GameObject)Instantiate(HatsPrefab[hatCount], pos, Player1Hat.transform.rotation);
        Hat.transform.SetParent(Player1Hat.transform);
        Player1Lleg.transform.parent.GetComponent<ReceiveAttack>().Hat = Hat;


     //   GameObject Lleg = (GameObject)Instantiate(LegsPrefab[legCount * 2], Player1Lleg.transform.position, Player1Lleg.transform.rotation);
     //   Lleg.transform.SetParent(Player1Lleg.transform);
     //   Lleg.GetComponent<CapsuleCollider>().enabled = false;
     //   Lleg.GetComponent<Rigidbody>().isKinematic = true;
     //
     //   GameObject Rleg = (GameObject)Instantiate(LegsPrefab[legCount * 2 + 1], Player1Rleg.transform.position, Player1Rleg.transform.rotation);
     //   Rleg.transform.SetParent(Player1Rleg.transform);
     //   Rleg.GetComponent<CapsuleCollider>().enabled = false;
     //   Rleg.GetComponent<Rigidbody>().isKinematic = true;

        //----------------------------------------------------------------------------------//

        hatCount = PlayerPrefs.GetInt("P2_Hat");
        legCount = PlayerPrefs.GetInt("P2_Leg");

        pos = new Vector3(Player2Hat.transform.position.x, Player2Hat.transform.position.y - 0.15f, Player2Hat.transform.position.z);

        Hat = (GameObject)Instantiate(HatsPrefab[hatCount], pos, Player2Hat.transform.rotation);
        Hat.transform.SetParent(Player2Hat.transform);
        Player2Lleg.transform.parent.GetComponent<ReceiveAttack>().Hat = Hat;


      //  Lleg = (GameObject)Instantiate(LegsPrefab[legCount * 2], Player2Lleg.transform.position, Player2Lleg.transform.rotation);
      //  Lleg.transform.SetParent(Player2Lleg.transform);
      //  Lleg.GetComponent<CapsuleCollider>().enabled = false;
      //  Lleg.GetComponent<Rigidbody>().isKinematic = true;
      //
      //  Rleg = (GameObject)Instantiate(LegsPrefab[legCount * 2 + 1], Player2Rleg.transform.position, Player2Rleg.transform.rotation);
      //  Rleg.transform.SetParent(Player2Rleg.transform);
      //  Rleg.GetComponent<CapsuleCollider>().enabled = false;
      //  Rleg.GetComponent<Rigidbody>().isKinematic = true;


        //----------------------------------------------------------------------------------//

        hatCount = PlayerPrefs.GetInt("P3_Hat");
        legCount = PlayerPrefs.GetInt("P3_Leg");

        pos = new Vector3(Player3Hat.transform.position.x, Player3Hat.transform.position.y - 0.15f, Player3Hat.transform.position.z);

        Hat = (GameObject)Instantiate(HatsPrefab[hatCount], pos, Player3Hat.transform.rotation);
        Hat.transform.SetParent(Player3Hat.transform);

        Player3Lleg.transform.parent.GetComponent<ReceiveAttack>().Hat = Hat;

       // Lleg = (GameObject)Instantiate(LegsPrefab[legCount * 2], Player3Lleg.transform.position, Player3Lleg.transform.rotation);
       // Lleg.transform.SetParent(Player3Lleg.transform);
       // Lleg.GetComponent<CapsuleCollider>().enabled = false;
       // Lleg.GetComponent<Rigidbody>().isKinematic = true;
       //
       // Rleg = (GameObject)Instantiate(LegsPrefab[legCount * 2 + 1], Player3Rleg.transform.position, Player3Rleg.transform.rotation);
       // Rleg.transform.SetParent(Player3Rleg.transform);
       // Rleg.GetComponent<CapsuleCollider>().enabled = false;
       // Rleg.GetComponent<Rigidbody>().isKinematic = true;

        //----------------------------------------------------------------------------------//

        hatCount = PlayerPrefs.GetInt("P4_Hat");
        legCount = PlayerPrefs.GetInt("P4_Leg");
        pos = new Vector3(Player4Hat.transform.position.x, Player4Hat.transform.position.y - 0.15f, Player4Hat.transform.position.z);

        Hat = (GameObject)Instantiate(HatsPrefab[hatCount], pos, Player4Hat.transform.rotation);
        Hat.transform.SetParent(Player4Hat.transform);

        Player4Lleg.transform.parent.GetComponent<ReceiveAttack>().Hat = Hat;

       // Lleg = (GameObject)Instantiate(LegsPrefab[legCount * 2], Player4Lleg.transform.position, Player4Lleg.transform.rotation);
       // Lleg.transform.SetParent(Player4Lleg.transform);
       // Lleg.GetComponent<CapsuleCollider>().enabled = false;
       // Lleg.GetComponent<Rigidbody>().isKinematic = true;
       //
       // Rleg = (GameObject)Instantiate(LegsPrefab[legCount * 2 + 1], Player4Rleg.transform.position, Player4Rleg.transform.rotation);
       // Rleg.transform.SetParent(Player4Rleg.transform);
       // Rleg.GetComponent<CapsuleCollider>().enabled = false;
       // Rleg.GetComponent<Rigidbody>().isKinematic = true;

        //----------------------------------------------------------------------------------//

    }


    // Update is called once per frame
    void Update()
    {

    }
}
