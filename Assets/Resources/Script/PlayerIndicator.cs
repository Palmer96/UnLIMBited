using UnityEngine;
using System.Collections;

public class PlayerIndicator : MonoBehaviour
{
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
       // transform.rotation = Player.transform.rotation;
       // transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.activeSelf && Player.GetComponent<ReceiveAttack>().alive)
        {
            transform.position = new Vector3(Player.transform.position.x, 0.51f, Player.transform.position.z);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
