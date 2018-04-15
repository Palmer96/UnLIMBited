using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public GameObject gameUI;

    public Image P1_Primary;
    public Image P1_Secondary;
    public Text P1_Health;

    public Image P2_Primary;
    public Image P2_Secondary;
    public Text P2_Health;

    public Image P3_Primary;
    public Image P3_Secondary;
    public Text P3_Health;

    public Image P4_Primary;
    public Image P4_Secondary;
    public Text P4_Health;

    public Sprite lifeSprite;
    public Sprite nolifeSprite;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;


    public Sprite NoArm;
    public Sprite DefaultArm;
    public Sprite BehemothArm;
    public Sprite FryingPanArm;
    public Sprite MalletArm;
    public Sprite GolfArm;


    public GameObject P1_Sprite;
    public GameObject P2_Sprite;
    public GameObject P3_Sprite;
    public GameObject P4_Sprite;

    public bool gameOver;

    public float timer;

    // Use this for initialization
    void Start()
    {
        timer = 1;
        // int playernum = PlayerPrefs("");
        gameOver = false;
        //1 3
        P1_Primary = gameUI.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        P1_Secondary = gameUI.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        P1_Health = gameUI.transform.GetChild(0).GetChild(3).GetComponent<Text>();

        //P2_Primary = gameUI.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        //P2_Secondary = gameUI.transform.GetChild(1).GetChild(1).GetComponent<Image>();
        P2_Health = gameUI.transform.GetChild(1).GetChild(3).GetComponent<Text>();

        //P3_Primary = gameUI.transform.GetChild(2).GetChild(0).GetComponent<Image>();
        //P3_Secondary = gameUI.transform.GetChild(2).GetChild(1).GetComponent<Image>();
        P3_Health = gameUI.transform.GetChild(2).GetChild(3).GetComponent<Text>();

        //P4_Primary = gameUI.transform.GetChild(3).GetChild(0).GetComponent<Image>();
        //P4_Secondary = gameUI.transform.GetChild(3).GetChild(1).GetComponent<Image>();
        P4_Health = gameUI.transform.GetChild(3).GetChild(3).GetComponent<Text>();

        gameUI.transform.GetChild(2).gameObject.SetActive(false);
        gameUI.transform.GetChild(3).gameObject.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        switch (PlayerPrefs.GetInt("NumOfPlayers"))
        {
            case 3:
                gameUI.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 4:
                gameUI.transform.GetChild(2).gameObject.SetActive(true);
                gameUI.transform.GetChild(3).gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        UpdateLives();

        if (gameOver == true)
        {
            timer -= Time.deltaTime;

            // GetComponent<Manager>().paused = true;
            if (timer < 0)
            {
                if (Input.GetButtonDown("P1_A") || Input.GetKeyDown(KeyCode.Y) ||
                    Input.GetButtonDown("P2_A") ||
                    Input.GetButtonDown("P3_A") ||
                    Input.GetButtonDown("P4_A"))
                {
                    Application.LoadLevel(Application.loadedLevel);
                    Time.timeScale = 1;
                }

                else if (Input.GetButtonDown("P1_B") || Input.GetKeyDown(KeyCode.U) ||
                    Input.GetButtonDown("P2_B") ||
                    Input.GetButtonDown("P3_B") ||
                    Input.GetButtonDown("P4_B"))
                {
                    Application.LoadLevel(0);
                    Time.timeScale = 1;
                }
            }
        }

        if (Player1.activeSelf)
            P1_Sprite.GetComponent<Image>().fillAmount = Player1.GetComponent<ReceiveAttack>().health * 0.01f;
        if (Player2.activeSelf)
            P2_Sprite.GetComponent<Image>().fillAmount = Player2.GetComponent<ReceiveAttack>().health * 0.01f;
        if (Player3.activeSelf)
            P3_Sprite.GetComponent<Image>().fillAmount = Player3.GetComponent<ReceiveAttack>().health * 0.01f;
        if (Player4.activeSelf)
            P4_Sprite.GetComponent<Image>().fillAmount = Player4.GetComponent<ReceiveAttack>().health * 0.01f;

        // if (Player1 != null)
        // {
        //     Switch(P1_Primary, Player1.GetComponent<PlayerMovement>().PrimaryArm);
        //     Switch(P1_Secondary, Player1.GetComponent<PlayerMovement>().secondaryArm);
        // }
        // if (Player2 != null)
        // {
        //     Switch(P2_Primary, Player2.GetComponent<PlayerMovement>().PrimaryArm);
        //     Switch(P2_Secondary, Player2.GetComponent<PlayerMovement>().secondaryArm);
        // }
        // if (Player3 != null)
        // {
        //     Switch(P3_Primary, Player3.GetComponent<PlayerMovement>().PrimaryArm);
        //     Switch(P3_Secondary, Player3.GetComponent<PlayerMovement>().secondaryArm);
        // }
        // if (Player4 != null)
        // {
        //     Switch(P4_Primary, Player3.GetComponent<PlayerMovement>().PrimaryArm);
        //     Switch(P4_Secondary, Player3.GetComponent<PlayerMovement>().secondaryArm);
        // }



    }

    void Switch(Image Arm, GameObject limb)
    {
        //if (limb)
        //{
        //    if (limb.tag != "NoArm")
        //    {
        //        if (limb.GetComponent<Limb>().originaltag == "LA_Default" || limb.GetComponent<Limb>().originaltag == "RA_Default")
        //        {
        //            Arm.sprite = DefaultArm;
        //        }
        //        else if (limb.GetComponent<Limb>().originaltag == "LA_Behemoth" || limb.GetComponent<Limb>().originaltag == "RA_Behemoth")
        //        {
        //            Arm.sprite = BehemothArm;
        //        }
        //        else if (limb.GetComponent<Limb>().originaltag == "LA_Fryingpan" || limb.GetComponent<Limb>().originaltag == "RA_Fryingpan")
        //        {
        //            Arm.sprite = FryingPanArm;
        //        }
        //        else if (limb.GetComponent<Limb>().originaltag == "LA_Mallet" || limb.GetComponent<Limb>().originaltag == "RA_Mallet")
        //        {
        //            Arm.sprite = MalletArm;
        //        }
        //        else if (limb.GetComponent<Limb>().originaltag == "LA_Golf" || limb.GetComponent<Limb>().originaltag == "RA_Golf")
        //        {
        //            Arm.sprite = GolfArm;
        //        }
        //        else
        //        {
        //            Arm.sprite = NoArm;
        //        }
        //    }
        //    else
        //    {
        //        //Debug.Log("NoArm");
        //        Arm.sprite = NoArm;
        //    }
        //}
        //else
        //    Arm.sprite = NoArm;
    }

    void UpdateLives()
    {
        /////////////////////////////////////////////////////////////////////////////////

        if (Player1.GetComponent<ReceiveAttack>().lives == 3)
        {
            gameUI.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<Image>().sprite = lifeSprite;
        }
        else if (Player1.GetComponent<ReceiveAttack>().lives == 2)
        {
            gameUI.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else if (Player1.GetComponent<ReceiveAttack>().lives == 1)
        {
            gameUI.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else
        {
            gameUI.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }

        /////////////////////////////////////////////////////////////////////////////////

        if (Player2.GetComponent<ReceiveAttack>().lives == 3)
        {
            gameUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().sprite = lifeSprite;
        }
        else if (Player2.GetComponent<ReceiveAttack>().lives == 2)
        {
            gameUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else if (Player2.GetComponent<ReceiveAttack>().lives == 1)
        {
            gameUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else
        {
            gameUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }

        /////////////////////////////////////////////////////////////////////////////////

        if (Player3.GetComponent<ReceiveAttack>().lives == 3)
        {
            gameUI.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(2).GetComponent<Image>().sprite = lifeSprite;
        }
        else if (Player3.GetComponent<ReceiveAttack>().lives == 2)
        {
            gameUI.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else if (Player3.GetComponent<ReceiveAttack>().lives == 1)
        {
            gameUI.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else
        {
            gameUI.transform.GetChild(2).GetChild(4).GetChild(0).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(2).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }

        /////////////////////////////////////////////////////////////////////////////////

        if (Player4.GetComponent<ReceiveAttack>().lives == 3)
        {
            gameUI.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(2).GetComponent<Image>().sprite = lifeSprite;
        }
        else if (Player4.GetComponent<ReceiveAttack>().lives == 2)
        {
            gameUI.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else if (Player4.GetComponent<ReceiveAttack>().lives == 1)
        {
            gameUI.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Image>().sprite = lifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }
        else
        {
            gameUI.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Image>().sprite = nolifeSprite;
            gameUI.transform.GetChild(3).GetChild(4).GetChild(2).GetComponent<Image>().sprite = nolifeSprite;
        }

        /////////////////////////////////////////////////////////////////////////////////


        if (!Player2.activeSelf &&
            !Player3.activeSelf &&
            !Player4.activeSelf)
        {
            gameOver = true;
            gameUI.transform.GetChild(6).gameObject.SetActive(true);
            gameUI.transform.GetChild(6).GetChild(1).GetChild(0).gameObject.SetActive(true);
        }

        if (!Player1.activeSelf &&
            !Player3.activeSelf &&
            !Player4.activeSelf)
        {
            gameOver = true;
            gameUI.transform.GetChild(6).gameObject.SetActive(true);
            gameUI.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(true);
        }

        if (!Player1.activeSelf &&
            !Player2.activeSelf &&
            !Player4.activeSelf)
        {
            gameOver = true;
            gameUI.transform.GetChild(6).gameObject.SetActive(true);
            gameUI.transform.GetChild(6).GetChild(1).GetChild(2).gameObject.SetActive(true);
        }
        if (!Player1.activeSelf &&
            !Player2.activeSelf &&
            !Player3.activeSelf)
        {
            gameOver = true;
            gameUI.transform.GetChild(6).gameObject.SetActive(true);
            gameUI.transform.GetChild(6).GetChild(1).GetChild(3).gameObject.SetActive(true);
        }
        if (!Player1.activeSelf &&
            !Player2.activeSelf &&
            !Player3.activeSelf &&
            !Player3.activeSelf)
        {
            gameOver = true;
            gameUI.transform.GetChild(6).gameObject.SetActive(true);
            gameUI.transform.GetChild(6).GetChild(1).GetChild(4).gameObject.SetActive(true);
        }


    }
}
