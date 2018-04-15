using UnityEngine;
using System.Collections;

public class SpriteCycle : MonoBehaviour
{
    public float rate;
    public Sprite[] sprites;
    private int count;

    float timer;
    
    // Use this for initialization
    void Start()
    {
        count = 0;
        timer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = rate;
            GetComponent<SpriteRenderer>().sprite = sprites[count];
            if (count == sprites.Length - 1)
            {
                count = 0;
            }
            else
                count++;
            }
    }
}
