using UnityEngine;
using System.Collections;

public class wrist : MonoBehaviour
{
    public bool attacking;

    private float timer;
    private float rate;

    void Start()
    {
        attacking = false;

        rate = 0.5f;
        timer = rate;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            attacking = false;
        }
    }

    public void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            timer = rate;
        }
    }
}
