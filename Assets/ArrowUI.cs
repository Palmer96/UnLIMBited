using UnityEngine;
using System.Collections;

public class ArrowUI : MonoBehaviour
{
    public bool active;
    private float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0.1f;
        active = false;
        GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            active = false;
                timer = 0.1f;
                GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 1);

            }
        }
    }
}
