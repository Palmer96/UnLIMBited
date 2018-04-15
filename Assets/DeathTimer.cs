using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    public float Rate;
    public float timer;

    public bool fade;
    // Use this for initialization
    void Start()
    {
        timer = Rate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (fade)
            {
                float alpha = transform.GetChild(0).GetComponent<Image>().color.a;
                transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, alpha-= 0.01f);

                transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, alpha -= 0.01f);
                transform.GetChild(0).GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, alpha -= 0.01f);
                
                if (timer < -2)
                {
                    Destroy(gameObject);
                }
            }
            else
                Destroy(gameObject);
        }
    }
}
