using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class MenuControllerold : MonoBehaviour
{

   // InputField myInputField;
   //
   // private MenuController mainmenu;
    public Image icon;

    public Button Play;
    public Button Options;
    public Button Exit;

    public Button PlayersButton2;
    public Button PlayersButton3;
    public Button PlayersButton4;
    public Button BackButton;

    public GameObject PlayerNumberScreen;
    public GameObject OptionsScreen;
    public GameObject ControlScreen;
    public GameObject QuitMenu;

    public int buttonPos;
    float buttonTimer;
    public float buttonRate;

    public int playerButtonNum;

    public int playerNum;

    // Use this for initialization
    void Start()
    {
        buttonPos = 1;
        playerButtonNum = 1;
        buttonRate = 0.5f;
        buttonTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {


        #region Old
        // buttonTimer -= Time.deltaTime;
        //
        // if (buttonTimer < 0)
        // {
        //     #region MainMenu
        //     //if (PlayerNumberScreen.activeSelf == false && OptionsScreen.activeSelf == false && ControlScreen == false)
        //     {
        //         switch (buttonPos)
        //         {
        //             case 1:
        //                 icon.rectTransform.position = Play.transform.position;
        //                 if (Input.GetAxis("P1_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P2_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P3_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P4_VerticalMovement") < 0)
        //                 {
        //                     buttonPos = 2;
        //                     buttonTimer = buttonRate;
        //                 }
        //                 if (Input.GetButtonDown("P1_A") ||
        //                     Input.GetButtonDown("P2_A") ||
        //                     Input.GetButtonDown("P3_A") ||
        //                     Input.GetButtonDown("P4_A"))
        //                 {
        //                     PlayButton();
        //                 }
        //                 break;
        //             case 2:
        //                 icon.rectTransform.position = Options.transform.position;
        //                 if (Input.GetAxis("P1_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P2_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P3_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P4_VerticalMovement") > 0)
        //                 {
        //                     buttonPos = 1;
        //                     buttonTimer = buttonRate;
        //                 }
        //                 if (Input.GetAxis("P1_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P2_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P3_VerticalMovement") < 0 ||
        //                     Input.GetAxis("P4_VerticalMovement") < 0)
        //                 {
        //                     buttonPos = 3;
        //                     buttonTimer = buttonRate;
        //                 }
        //
        //                 if (Input.GetButtonDown("P1_A") ||
        //                     Input.GetButtonDown("P2_A") ||
        //                     Input.GetButtonDown("P3_A") ||
        //                     Input.GetButtonDown("P4_A"))
        //                 {
        //                     Debug.Log("A");
        //                     ControlsButton();
        //                 }
        //                 break;
        //             case 3:
        //                 icon.rectTransform.position = Exit.transform.position;
        //                 if (Input.GetAxis("P1_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P2_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P3_VerticalMovement") > 0 ||
        //                     Input.GetAxis("P4_VerticalMovement") > 0)
        //                 {
        //                     buttonPos = 2;
        //                     buttonTimer = buttonRate;
        //                 }
        //                 if (Input.GetButtonDown("P1_A") ||
        //                     Input.GetButtonDown("P2_A") ||
        //                     Input.GetButtonDown("P3_A") ||
        //                     Input.GetButtonDown("P4_A"))
        //                 {
        //                     ExitButton();
        //                 }
        //                 break;
        //         }
        //     }
        //     #endregion
        //
        //
        //     #region PlayerNum
        //      if (PlayerNumberScreen.activeSelf == true)
        //      {
        //          switch (playerButtonNum)
        //          {
        //              case 1:
        //                  icon.rectTransform.position = PlayersButton2.transform.position;
        //                  if (Input.GetAxis("P1_HorizontalMovement") < 0 || Input.GetAxis("P2_HorizontalMovement") < 0 || Input.GetAxis("P3_HorizontalMovement") < 0 || Input.GetAxis("P4_HorizontalMovement") < 0)
        //                  {
        //                      playerButtonNum = 2;
        //                      buttonTimer = buttonRate;
        //                  }
        //                 if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                 {
        //                     Debug.Log("A");
        //                     PlayerGame();
        //                 }
        //                 break;
        //              case 2:
        //                  icon.rectTransform.position = PlayersButton3.transform.position;
        //                  if (Input.GetAxis("P1_HorizontalMovement") > 0 || Input.GetAxis("P2_HorizontalMovement") > 0 || Input.GetAxis("P3_HorizontalMovement") > 0 || Input.GetAxis("P4_HorizontalMovement") > 0)
        //                  {
        //                      playerButtonNum = 1;
        //                      buttonTimer = buttonRate;
        //                  }
        //                  if (Input.GetAxis("P1_HorizontalMovement") < 0 || Input.GetAxis("P2_HorizontalMovement") < 0 || Input.GetAxis("P3_HorizontalMovement") < 0 || Input.GetAxis("P4_HorizontalMovement") < 0)
        //                  {
        //                      playerButtonNum = 3;
        //                      buttonTimer = buttonRate;
        //                  }
        //                 if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                 {
        //                     Debug.Log("A");
        //                     PlayerGame();
        //                 }
        //                 break;
        //              case 3:
        //                  icon.rectTransform.position = PlayersButton4.transform.position;
        //                  if (Input.GetAxis("P1_HorizontalMovement") > 0 || Input.GetAxis("P2_HorizontalMovement") > 0 || Input.GetAxis("P3_HorizontalMovement") > 0 || Input.GetAxis("P4_HorizontalMovement") > 0)
        //                  {
        //                      playerButtonNum = 2;
        //                      buttonTimer = buttonRate;
        //                  }
        //               //   if (Input.GetAxis("P1_HorizontalMovement") < 0 || Input.GetAxis("P2_HorizontalMovement") < 0 || Input.GetAxis("P3_HorizontalMovement") < 0 || Input.GetAxis("P4_HorizontalMovement") < 0)
        //               //   {
        //               //       playerButtonNum = 4;
        //               //       buttonTimer = buttonRate;
        //               //   }
        //                 if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                 {
        //                     Debug.Log("A");
        //                     PlayerGame();
        //                 }
        //                 break;
        //             // case 4:
        //             //     icon.rectTransform.position = Back.transform.position;
        //             //     if (Input.GetAxis("P1_HorizontalMovement") > 0 || Input.GetAxis("P2_HorizontalMovement") > 0 || Input.GetAxis("P3_HorizontalMovement") > 0 || Input.GetAxis("P4_HorizontalMovement") > 0)
        //             //     {
        //             //         playerButtonNum = 3;
        //             //         buttonTimer = buttonRate;
        //             //     }
        //             //
        //             //     break;
        //          }
        //          
        //     
        //          icon.rectTransform.position = ControlScreen.transform.GetChild(2).transform.position;
        //          if (Input.GetButtonDown("P1_B") ||
        //              Input.GetButtonDown("P2_B") ||
        //              Input.GetButtonDown("P3_B") ||
        //              Input.GetButtonDown("P4_B"))
        //          {
        //              Debug.Log("B");
        //              PlayerNumberScreen.SetActive(false);
        //          }
        //      }
        //     #endregion
        //
        //
        //     #region Options
        //         if (OptionsScreen.activeSelf == true)
        //         {
        //             switch (buttonPos)
        //             {
        //                 case 1:
        //                     icon.rectTransform.position = Play.transform.position;
        //                     if (Input.GetAxis("P1_VerticalMovement") < 0 || Input.GetAxis("P2_VerticalMovement") < 0 || Input.GetAxis("P3_VerticalMovement") < 0 || Input.GetAxis("P4_VerticalMovement") < 0)
        //                     {
        //                         buttonPos = 2;
        //                         buttonTimer = buttonRate;
        //                     }
        //                     if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                     {
        //                         PlayButton();
        //                     }
        //                     break;
        //                 case 2:
        //                     icon.rectTransform.position = Options.transform.position;
        //                     if (Input.GetAxis("P1_VerticalMovement") < 0 || Input.GetAxis("P2_VerticalMovement") < 0 || Input.GetAxis("P3_VerticalMovement") < 0 || Input.GetAxis("P4_VerticalMovement") < 0)
        //                     {
        //                         buttonPos = 3;
        //                         buttonTimer = buttonRate;
        //                     }
        //                     if (Input.GetAxis("P1_VerticalMovement") > 0 || Input.GetAxis("P2_VerticalMovement") > 0 || Input.GetAxis("P3_VerticalMovement") > 0 || Input.GetAxis("P4_VerticalMovement") > 0)
        //                     {
        //                         buttonPos = 1;
        //                         buttonTimer = buttonRate;
        //                     }
        //
        //                     if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                     {
        //                         Debug.Log("A");
        //                         ControlsButton();
        //                     }
        //                     break;
        //                 case 3:
        //                     icon.rectTransform.position = Exit.transform.position;
        //                     if (Input.GetAxis("P1_VerticalMovement") > 0 || Input.GetAxis("P2_VerticalMovement") > 0 || Input.GetAxis("P3_VerticalMovement") > 0 || Input.GetAxis("P4_VerticalMovement") > 0)
        //                     {
        //                         buttonPos = 2;
        //                         buttonTimer = buttonRate;
        //                     }
        //                     if (Input.GetButtonDown("P1_A") || Input.GetButtonDown("P2_A") || Input.GetButtonDown("P3_A") || Input.GetButtonDown("P4_A"))
        //                     {
        //                         ExitButton();
        //                     }
        //                     break;
        //             }
        //         }
        //    #endregion
        //
        //
        //     #region Controls
        //     if (ControlScreen.activeSelf == true)
        //     {
        //        icon.rectTransform.position = ControlScreen.transform.GetChild(2).transform.position;
        // if (Input.GetButtonDown("P1_B") || //Input.GetButtonDown("P1_A") ||
        //     Input.GetButtonDown("P2_B") || //Input.GetButtonDown("P2_A") ||
        //     Input.GetButtonDown("P3_B") || //Input.GetButtonDown("P3_A") ||
        //     Input.GetButtonDown("P4_B") ) //Input.GetButtonDown("P4_A"))
        // {
        //     Debug.Log("B");
        //     ControlScreen.SetActive(false);
        // }
        // }
        //#endregion
        //
        //
        // }
        #endregion

    }

    public void Players2()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 2);
           Application.LoadLevel(1);
    }
    public void Players3()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 3);
        Application.LoadLevel(1);
    }
    public void Players4()
    {
        PlayerPrefs.SetInt("NumOfPlayers", 4);
        Application.LoadLevel(1);
    }
    public void PlayButton()
    {
        PlayerNumberScreen.SetActive(true);
        Play.interactable = false;
        Options.interactable = false;
        Exit.interactable = false;
    }
    public void Back()
    {
        PlayerNumberScreen.SetActive(false);
        ControlScreen.SetActive(false);
        OptionsScreen.SetActive(false);
        QuitMenu.SetActive(false);
        Play.interactable = true;
        Options.interactable = true;
        Exit.interactable = true;
        Play.Select();
    }
    public void QuitButton()
    {
        QuitMenu.SetActive(true);
        Play.interactable = false;
        Options.interactable = false;
        Exit.interactable = false;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        Debug.Log("Options");
        OptionsScreen.SetActive(true);
        Play.interactable = false;
        Options.interactable = false;
        Exit.interactable = false;
    }

    public void ControlsButton()
    {
        Debug.Log("Controls");
        ControlScreen.SetActive(true);
        Play.interactable = false;
        Options.interactable = false;
        Exit.interactable = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
