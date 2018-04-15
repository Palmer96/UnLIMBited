using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject[] Groups;
    public Transform[] pos;

    public int groupState = 0;
    public int buttonState = 0;

    private float timer;
    public int levelselected;

    public bool playerSelectActive;
    public int num;

    public AudioClip upBop;
    public AudioClip downBop;
    public AudioClip sideBop;

    public GameObject Mousoleum;
    public Material orginalMousoleum;
    public Material newMousoleum;

    private bool credits;
    // Use this for initialization
    void Start()
    {
        timer = 0.1f;
        groupState = 0;
        buttonState = 0;
        levelselected = 0;
        credits = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, pos[groupState].position, 0.05f);
        transform.rotation = Quaternion.Lerp(transform.rotation, pos[groupState].rotation, 0.05f);


        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (Input.GetAxis("P1_HorizontalMovement") > 0.19f || Input.GetKeyDown(KeyCode.D))
            {
                if (buttonState < Groups[groupState].transform.childCount - 1)
                {
                    if (!playerSelectActive)
                        GetComponent<AudioSource>().PlayOneShot(sideBop, 0.25f);
                    timer = 0.1f;
                    buttonState++;
                }
            }

            if (Input.GetAxis("P1_HorizontalMovement") < -0.19f && buttonState > 0 || Input.GetKeyDown(KeyCode.A))
            {
                if (buttonState > 0)
                {
                    if (!playerSelectActive)
                        GetComponent<AudioSource>().PlayOneShot(sideBop, 0.25f);
                    timer = 0.1f;
                    buttonState--;
                }
            }
        }


        if (groupState == 3)
        {
            num = PlayerPrefs.GetInt("NumOfPlayers");

            switch (num)
            {
                case 2:
                    if (Groups[3].transform.GetChild(0).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(1).GetComponent<MenuChoice>().Ready)
                    {
                        Application.LoadLevel(levelselected);
                    }
                    break;
                case 3:
                    if (Groups[3].transform.GetChild(0).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(1).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(2).GetComponent<MenuChoice>().Ready)
                    {
                        Application.LoadLevel(levelselected);
                    }
                    break;
                case 4:
                    if (Groups[3].transform.GetChild(0).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(1).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(2).GetComponent<MenuChoice>().Ready &&
                                Groups[3].transform.GetChild(3).GetComponent<MenuChoice>().Ready)
                    {
                        Application.LoadLevel(levelselected);
                    }
                    break;
            }
        }

        if (Input.GetButtonDown("P1_A") || Input.GetKeyDown(KeyCode.W))
        {

            switch (groupState)
            {
                case 0: // play
                    switch (buttonState)
                    {
                        case 0: // Play
                            PlayButton();
                            break;
                        case 1: // Controls
                            ControlsButton();
                            break;
                        case 2: // Exit
                            CreditsButton();
                            break;
                        case 3: // Exit
                            ExitButton();
                            break;
                    }
                    break;
                case 1: // Player Num
                    switch (buttonState)
                    {
                        case 0: // 2
                            Players2();
                            break;
                        case 1: // 3
                            Players3();
                            break;
                        case 2: // 4 
                            Players4();
                            break;
                    }
                    break;

                case 2: // Map
                    switch (buttonState)
                    {
                        case 0: // Suburban
                            Level1();
                            break;
                        case 1: // Graveyard
                            Level2();
                            break;
                        case 2: // Mansion 
                            Level3();
                            break;
                    }
                    break;
                case 3: // PlayerSelect


                    break;

            }
            buttonState = 0;
        }

        if (!playerSelectActive)
        {
            if (Input.GetButtonDown("P1_B") || Input.GetKeyDown(KeyCode.S))
            {
                buttonState = 0;
                if (groupState == 4 || groupState == 5)
                    BacktoMain();
                else
                    Back();
            }
        }


        //if (Groups[groupState].GetComponent<Group>().Buttons[buttonState].CompareTag("Menu"))
        if (groupState != 3 && groupState != 5)
            Groups[groupState].GetComponent<Group>().Buttons[buttonState].GetComponent<Select>().selected = true;


    }



    public void Players2()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 2);
        groupState = 2;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }
    public void Players3()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 3);
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
        groupState = 2;
    }
    public void Players4()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 4);
        groupState = 2;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }

    public void Level1()
    {
        levelselected = 1;
        groupState = 3;
        playerSelectActive = true;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }
    public void Level2()
    {
        levelselected = 2;
        groupState = 3;
        playerSelectActive = true;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }
    public void Level3()
    {
        levelselected = 3;
        groupState = 3;
        playerSelectActive = true;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }
    public void PlayButton()
    {
        groupState = 1;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }
    public void Back()
    {
        if (groupState > 0)
        {
            groupState--;
            GetComponent<AudioSource>().PlayOneShot(downBop, 0.25f);
        }
    }
    public void BackFromPlayer()
    {
        groupState = 3;
        GetComponent<AudioSource>().PlayOneShot(downBop, 0.25f);
        playerSelectActive = false;
    }

    public void BacktoMain()
    {
        groupState = 0;
        GetComponent<AudioSource>().PlayOneShot(downBop, 0.25f);
    }

    public void ControlsButton()
    {
        groupState = 4;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }

    public void CreditsButton()
    {
        groupState = 5;
        GetComponent<AudioSource>().PlayOneShot(upBop, 0.25f);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
