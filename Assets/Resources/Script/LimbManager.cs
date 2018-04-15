using UnityEngine;
using System.Collections;

public class LimbManager : MonoBehaviour
{
    public float respawnTime;
    public float respawnTimer;

    public int armType;

    public GameObject[] Limbs;
    public float Xmin;
    public float Xmax;
    public float Zmin;
    public float Zmax;

    public Vector3 mapmiddle;
    public float force;

    // Use this for initialization
    void Start()
    {
        respawnTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer += Time.deltaTime;
        if (respawnTimer >= respawnTime)
        {
            AddLimb();
        }


    }

    void AddLimb()
    {
        GameObject tempArm;
        switch (Random.Range(0, 5))
        {
            case 1:
                tempArm = Instantiate(Limbs[Random.Range(0, Limbs.Length)], new Vector3(Random.Range(Xmin, Xmax), 15, Zmax), Quaternion.identity) as GameObject;
                tempArm.GetComponent<Rigidbody>().AddForce((mapmiddle - tempArm.transform.position) * force, ForceMode.Force);
                break;
            case 2:
                tempArm = Instantiate(Limbs[Random.Range(0, Limbs.Length)], new Vector3(Random.Range(Xmin, Xmax), 15, Zmin), Quaternion.identity) as GameObject;
                tempArm.GetComponent<Rigidbody>().AddForce((mapmiddle - tempArm.transform.position) * force, ForceMode.Force);
                break;
            case 3:
                tempArm = Instantiate(Limbs[Random.Range(0, Limbs.Length)], new Vector3(Xmin, 15, Random.Range(Zmin, Zmax)), Quaternion.identity) as GameObject;
                tempArm.GetComponent<Rigidbody>().AddForce((mapmiddle - tempArm.transform.position) * force, ForceMode.Force);
                break;
            case 4:
                tempArm = Instantiate(Limbs[Random.Range(0, Limbs.Length)], new Vector3(Xmax, 15, Random.Range(Zmin, Zmax)), Quaternion.identity) as GameObject;
                tempArm.GetComponent<Rigidbody>().AddForce((mapmiddle - tempArm.transform.position) * force, ForceMode.Force);
                break;
        }
        respawnTimer = 0.0f;
        respawnTime = Random.Range(1.0f, 5.0f);
    }
    void Respawn()
    {
        int randX = Rand();
        int randZ = Rand();

        Vector3 position = new Vector3(randX, 10.0f, randZ);

        float directionX = DirectionX(randX);
        float directionY = Random.Range(250, 400);
        float directionZ = DirectionZ(randZ);

        armType = Random.Range(0, Limbs.Length);
        GameObject tempArm = Instantiate(Limbs[armType], position, Quaternion.identity) as GameObject;
        //tempArm.GetComponent<Rigidbody>().AddForce(directionX, directionY, directionZ);

        tempArm.GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0) - position);

        respawnTimer = 0.0f;
        respawnTime = Random.Range(1.0f, 5.0f);

    }

    int Rand()
    {
        int coords = 0;

        while (coords < 15 && coords > -15)
        {
            coords = Random.Range(-20, 20);
        }

        return coords;
    }

    float DirectionX(int xCoords)
    {
        float directionX = 0;

        if (xCoords >= 0)
        {
            //  directionX = Random.Range(Xmin.x, Xmin.y);
        }
        else
        {
            //    directionX = Random.Range(Xmax.x, Xmax.y);
        }

        return directionX;
    }

    float DirectionZ(int zCoords)
    {
        float directionZ = 0;

        if (zCoords >= 0)
        {
            //    directionZ = Random.Range(Zmin.x, Zmin.y);
        }
        else
        {
            //    directionZ = Random.Range(Zmax.x, Zmax.y);
        }

        return directionZ;
    }
}

