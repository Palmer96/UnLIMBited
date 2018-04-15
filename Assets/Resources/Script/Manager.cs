using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public bool paused;
    public GameObject PauseScreen;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    int NumOfPlayers;

    public GameObject audioListener;
    // Use this for initialization
    void Start()
    {
        paused = false;
        NumOfPlayers = PlayerPrefs.GetInt("NumOfPlayers");
        Player3.SetActive(false);
        Player4.SetActive(false);
        switch (NumOfPlayers)
        {
            case 3:
                Player3.SetActive(true);
                break;
            case 4:
                Player3.SetActive(true);
                Player4.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            audioListener.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;
            if (Input.GetButtonDown("P1_A") ||
                Input.GetButtonDown("P2_A") ||
                Input.GetButtonDown("P3_A") ||
                Input.GetButtonDown("P4_A"))
            {
                paused = false;
                
            }
            if (Input.GetButtonDown("P1_B") ||
                Input.GetButtonDown("P2_B") ||
                Input.GetButtonDown("P3_B") ||
                Input.GetButtonDown("P4_B"))
            {
                Time.timeScale = 1;
                Application.LoadLevel(0);

            }
        }
        else
        {
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
            audioListener.GetComponent<AudioSource>().UnPause();
        }
    }

    public void Pause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            
            PauseScreen.SetActive(true);
        }
    }

    
}
