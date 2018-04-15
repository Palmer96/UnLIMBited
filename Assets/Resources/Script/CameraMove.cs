using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public GameObject[] Players;

    private Vector3 Pos;

    public float yDis;
    public float zDis;

    public float YOffset;
    public float XOffset;
    public float Multiplyer;

    private float DistanceApart;

    public float MoveSpeed;

    // Use this for initialization
    void Start()
    {
        // yDis = 9;
        // zDis = -7;
        int players = Players.Length;

        if (players == 2)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceApart = 0;

        //    for (int i = 0; i < Players.Length-1; i++)
        //    {
        //        for (int j = i; j < Players.Length-1; i++)
        //        {
        //            if (Vector3.Distance(Players[i].transform.position, Players[j].transform.position) > DistanceApart)
        //            {
        //                Debug.Log(i + " " + j);
        //                DistanceApart = Vector3.Distance(Players[i].transform.position, Players[j].transform.position);
        //            }
        //        }
        //    }


        // for (int i = 0; i < Players.Length; i++)
        // {
        //
        // }


        if (Vector3.Distance(Player1.transform.position, Player2.transform.position) > DistanceApart)
        {
            DistanceApart = Vector3.Distance(Player1.transform.position, Player2.transform.position);
        }
        if (Player3.activeSelf)
        {

            if (Vector3.Distance(Player1.transform.position, Player3.transform.position) > DistanceApart)
            {
                DistanceApart = Vector3.Distance(Player1.transform.position, Player3.transform.position);
            }
            if (Vector3.Distance(Player2.transform.position, Player3.transform.position) > DistanceApart)
            {
                DistanceApart = Vector3.Distance(Player2.transform.position, Player3.transform.position);
            }

            if (Player4.activeSelf)
            {

                if (Vector3.Distance(Player1.transform.position, Player4.transform.position) > DistanceApart)
                {
                    DistanceApart = Vector3.Distance(Player1.transform.position, Player4.transform.position);
                }
                if (Vector3.Distance(Player2.transform.position, Player4.transform.position) > DistanceApart)
                {
                    DistanceApart = Vector3.Distance(Player2.transform.position, Player4.transform.position);
                }
                if (Vector3.Distance(Player3.transform.position, Player4.transform.position) > DistanceApart)
                {
                    DistanceApart = Vector3.Distance(Player3.transform.position, Player4.transform.position);
                }
            }
        }
        yDis = ((DistanceApart * +YOffset) * Multiplyer) + YOffset;
        zDis = ((DistanceApart * -XOffset) * Multiplyer) - XOffset;

        Pos = Player1.transform.position + Player2.transform.position;

        if (Player4.activeSelf)
        {
            Pos += Player3.transform.position;
            Pos += Player4.transform.position;
            Pos *= 0.25f;
        }
        else if (Player3.activeSelf)
        {
            Pos += Player3.transform.position;
            Pos /= 3;
        }
        else
        {
            Pos *= 0.5f;
        }


        //  transform.LookAt(Pos);
        //    transform.position = new Vector3(Pos.x, Pos.y + yDis, Pos.z + zDis);

        float yPos = Pos.y + yDis;
        float zPos = Pos.z + zDis;

        yPos = Mathf.Clamp(yPos, 9, 22);
        zPos = Mathf.Clamp(zPos, -37, 0);

        transform.position = Vector3.Lerp(transform.position, new Vector3(Pos.x, yPos, zPos), MoveSpeed);

    }
}
