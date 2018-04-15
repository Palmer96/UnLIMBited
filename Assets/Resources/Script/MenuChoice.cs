using UnityEngine;
using System.Collections;

public class MenuChoice : MonoBehaviour
{
    public int PlayerID;

    public GameObject cam;

    public Sprite Readysprite;
    public Sprite NotReadysprite;
    public GameObject spriteReady;
    public GameObject spriteLeft;
    public GameObject spriteRight;

    public int loc;

    public bool Ready;
    public GameObject Head;
    public Material FaceMat;
    public Material BodyMat;
    public Material ArmMat;
    public Material LegMat;

    public GameObject Leg;


    public GameObject[] HatsPrefab;
    public Texture[] Faces;
    public Texture[] Clothes;
    public Texture[] Arms;
    public Texture[] LegTex;
    public GameObject[] LegsPrefab;

    private GameObject[] Hats;
    private GameObject[] Legs;

    public int hatCount;
    public int faceCount;
    public int bodyCount;
    public int legCount;

    Vector3 pos;

    public float timer;
    // Use this for initialization
    void Start()
    {
        hatCount = 0;
        faceCount = 0;
        bodyCount = 0;
        legCount = 0;

        Ready = false;


        pos = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
        Hats = new GameObject[HatsPrefab.Length];
        for (int i = 0; i < HatsPrefab.Length; i++)
        {
            Hats[i] = (GameObject)Instantiate(HatsPrefab[i], pos, transform.rotation);
        }
        Legs = new GameObject[LegsPrefab.Length];
        for (int i = 0; i < LegsPrefab.Length; i++)
        {
            Legs[i] = (GameObject)Instantiate(LegsPrefab[i], pos, transform.rotation);
            Legs[i].transform.SetParent(Leg.transform);
        }

        Reset();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Hats[hatCount].transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y - 0.15f, Head.transform.position.z);
        Hats[hatCount].transform.rotation = Head.transform.rotation;

        FaceMat.mainTexture = Faces[faceCount];

        BodyMat.mainTexture = Clothes[bodyCount];

        ArmMat.mainTexture = Arms[bodyCount];
        LegMat.mainTexture = LegTex[bodyCount];

        Legs[legCount].transform.position = Leg.transform.position;
        Legs[legCount].transform.rotation = Leg.transform.rotation;






        if (cam.GetComponent<MenuController>().playerSelectActive)
        {

            if (Input.GetButtonDown("P1_B") || Input.GetKeyDown(KeyCode.S))
            {
                if (!Ready)
                {
                    cam.GetComponent<MenuController>().BackFromPlayer();
                }

                Ready = false;
            }
        }


        if (Ready)
        {
            spriteReady.GetComponent<SpriteRenderer>().sprite = Readysprite;
            spriteLeft.SetActive(false);
            spriteRight.SetActive(false);
            if (Input.GetButtonDown("P" + PlayerID.ToString() + "_B") || Input.GetKeyDown(KeyCode.S))
            {
                Ready = false;
            }
        }
        else
        {
            spriteReady.GetComponent<SpriteRenderer>().sprite = NotReadysprite;

            spriteLeft.SetActive(true);
            spriteRight.SetActive(true);

            if (cam.GetComponent<MenuController>().playerSelectActive)
            {

                if (Input.GetButtonDown("P" + PlayerID.ToString() + "_A") || Input.GetKeyDown(KeyCode.W))
                {
                    Ready = true;
                    Save();
                }


                timer -= Time.deltaTime;
                if (timer < 0)
                {

                    if (Input.GetAxis("P" + PlayerID + "_VerticalMovement") > 0.5f && (loc > 0))
                    {
                        timer = 0.2f;
                        loc--;
                    }

                    if (Input.GetAxis("P" + PlayerID + "_VerticalMovement") < -0.5f && (loc < 2))
                    {
                        timer = 0.2f;
                        loc++;
                    }

                    if (Input.GetAxis("P" + PlayerID + "_HorizontalRotate") > 0.2f)
                    {
                        transform.GetChild(0).transform.Rotate(0, -2, 0);
                    }
                    if (Input.GetAxis("P" + PlayerID + "_HorizontalRotate") < -0.2f)
                    {
                        transform.GetChild(0).transform.Rotate(0, 2, 0);
                    }

                    if (Input.GetAxis("P" + PlayerID + "_HorizontalMovement") > 0.2f)
                    {
                        timer = 0.2f;
                        spriteRight.GetComponent<ArrowUI>().active = true;
                        switch (loc)
                        {
                            case 0:
                                Hats[hatCount].transform.position = pos;
                                if (hatCount == Hats.Length - 1)
                                    hatCount = 0;
                                else
                                    hatCount++;
                                break;

                            case 1:
                                if (faceCount == Faces.Length - 1)
                                    faceCount = 0;
                                else
                                    faceCount++;

                                FaceMat.mainTexture = Faces[faceCount];
                                break;

                            case 2:
                                if (bodyCount == Clothes.Length - 1)
                                    bodyCount = 0;
                                else
                                    bodyCount++;
                                BodyMat.mainTexture = Clothes[bodyCount];
                                ArmMat.mainTexture = Arms[bodyCount];
                                LegMat.mainTexture = LegTex[bodyCount];
                                break;

                                // case 3:
                                //     Legs[legCount].transform.position = pos;
                                //     if (legCount == Legs.Length - 1)
                                //         legCount = 0;
                                //     else
                                //         legCount++;
                                //     break;


                        }

                    }
                    if (Input.GetAxis("P" + PlayerID + "_HorizontalMovement") < -0.2f)
                    {
                        timer = 0.2f;
                        spriteLeft.GetComponent<ArrowUI>().active = true;
                        switch (loc)
                        {
                            case 0:
                                Hats[hatCount].transform.position = pos;
                                if (hatCount == 0)
                                    hatCount = Hats.Length - 1;
                                else
                                    hatCount--;
                                break;

                            case 1:
                                if (faceCount == 0)
                                    faceCount = Faces.Length - 1;
                                else
                                    faceCount--;
                                if (PlayerID == 1)
                                    FaceMat.mainTexture = Faces[faceCount];
                                break;

                            case 2:
                                if (bodyCount == 0)
                                    bodyCount = Clothes.Length - 1;
                                else
                                    bodyCount--;
                                BodyMat.mainTexture = Clothes[bodyCount];
                                ArmMat.mainTexture = Arms[bodyCount];
                                LegMat.mainTexture = LegTex[bodyCount];
                                break;

                            case 3:
                                Legs[legCount].transform.position = pos;
                                if (legCount == 0)
                                    legCount = Legs.Length - 1;
                                else
                                    legCount--;
                                break;
                        }

                    }
                }

                switch (loc)
                {
                    case 0:
                        spriteLeft.transform.localPosition = new Vector3(spriteLeft.transform.localPosition.x, 2.3f, spriteLeft.transform.localPosition.z);
                        spriteRight.transform.localPosition = new Vector3(spriteRight.transform.localPosition.x, 2.3f, spriteRight.transform.localPosition.z);
                        break;

                    case 1:
                        spriteLeft.transform.localPosition = new Vector3(spriteLeft.transform.localPosition.x, 1.4f, spriteLeft.transform.localPosition.z);
                        spriteRight.transform.localPosition = new Vector3(spriteRight.transform.localPosition.x, 1.4f, spriteRight.transform.localPosition.z);
                        break;

                    case 2:
                        spriteLeft.transform.localPosition = new Vector3(spriteLeft.transform.localPosition.x, 0.3f, spriteLeft.transform.localPosition.z);
                        spriteRight.transform.localPosition = new Vector3(spriteRight.transform.localPosition.x, 0.3f, spriteRight.transform.localPosition.z);
                        break;

                    case 3:
                        spriteLeft.transform.localPosition = new Vector3(spriteLeft.transform.localPosition.x, -0.5f, spriteLeft.transform.localPosition.z);
                        spriteRight.transform.localPosition = new Vector3(spriteRight.transform.localPosition.x, -0.5f, spriteRight.transform.localPosition.z);
                        break;
                }






                /////////////////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Hats[hatCount].transform.position = pos;
                    if (hatCount == Hats.Length - 1)
                        hatCount = 0;
                    else
                        hatCount++;
                }
                /////////////////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (faceCount == Faces.Length - 1)
                        faceCount = 0;
                    else
                        faceCount++;
                    if (PlayerID == 1)
                        FaceMat.mainTexture = Faces[faceCount];
                }
                /////////////////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.N))
                {
                    if (bodyCount == Clothes.Length - 1)
                        bodyCount = 0;
                    else
                        bodyCount++;
                    BodyMat.mainTexture = Clothes[bodyCount];
                    ArmMat.mainTexture = Arms[bodyCount];
                    LegMat.mainTexture = LegTex[bodyCount];
                }
                /////////////////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.M))
                {
                    Legs[legCount].transform.position = pos;
                    if (legCount == Legs.Length - 1)
                        legCount = 0;
                    else
                        legCount++;
                }
            }
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt("P" + PlayerID + "_Hat", hatCount);
        PlayerPrefs.SetInt("P" + PlayerID + "_Face", faceCount);
        PlayerPrefs.SetInt("P" + PlayerID + "_Body", bodyCount);
        PlayerPrefs.SetInt("P" + PlayerID + "_Leg", legCount);
    }

    void Load()
    {

        hatCount = PlayerPrefs.GetInt("P" + PlayerID + "_Hat");
        faceCount = PlayerPrefs.GetInt("P" + PlayerID + "_Face");
        bodyCount = PlayerPrefs.GetInt("P" + PlayerID + "_Body");
        legCount = PlayerPrefs.GetInt("P" + PlayerID + "_Leg");


        FaceMat.mainTexture = Faces[faceCount];
        BodyMat.mainTexture = Clothes[bodyCount];
    }

    void Reset()
    {
        PlayerPrefs.SetInt("P" + PlayerID + "_Hat", 0);
        PlayerPrefs.SetInt("P" + PlayerID + "_Face", 0);
        PlayerPrefs.SetInt("P" + PlayerID + "_Body", 0);
        PlayerPrefs.SetInt("P" + PlayerID + "_Leg", 0);
    }
}
