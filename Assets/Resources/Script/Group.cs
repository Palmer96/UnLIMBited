using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour
{
    public GameObject[] Buttons;
    // Use this for initialization
    void Start()
    {
        Buttons = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            //Buttons.SetValue(transform.GetChild(i).gameObject, i);
            Buttons[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
