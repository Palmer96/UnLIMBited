using UnityEngine;
using System.Collections;

public class PlayerNumber : MonoBehaviour
{

    public int num;

    public bool playerSelectActive;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        num = PlayerPrefs.GetInt("NumOfPlayers");

        if (num > 2)
            transform.GetChild(2).gameObject.SetActive(true);
        else
            transform.GetChild(2).gameObject.SetActive(false);
        if (num > 3)
            transform.GetChild(3).gameObject.SetActive(true);
        else
            transform.GetChild(3).gameObject.SetActive(false);
    }
}
