using UnityEngine;
using System.Collections;

public class WilloWisp : MonoBehaviour
{
    public GameObject Player;
    private bool bKilling;
    private Vector3 currentDir;
    public float fActualMoveSpeed;

    public float OwnerStickingDistance;
    public float MoveSpeed;

    public float WanderOffset;
    public float WanderRadius;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!bKilling)
        {
            currentDir = SeekToOwner() + WanderDirection();
            currentDir.Normalize();
            if ((Player.transform.position - transform.position).magnitude < 20)
            transform.Translate(currentDir * fActualMoveSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, 2f, 5f),
            transform.position.z);
    }





    Vector3 SeekToOwner()
    {
        Player = FindClosestPlayer();
        Vector3 ownerDir = Player.transform.position - transform.position;
        float distance = ownerDir.magnitude;
        ownerDir.Normalize();

        float distFromStickingDistance = distance - OwnerStickingDistance;

        fActualMoveSpeed = MoveSpeed * (1 + (distFromStickingDistance / 2));
        return ownerDir * (distFromStickingDistance / OwnerStickingDistance);
    }

    Vector3 WanderDirection()
    {
        Vector3 wanderCenter = transform.position + (currentDir * WanderOffset);

        Vector3 wanderPoint = wanderCenter + (Random.onUnitSphere * WanderRadius);

        Vector3 wanderDir = wanderPoint - transform.position;
        wanderDir.Normalize();


        return wanderDir;
    }

    GameObject FindClosestPlayer()
    {
        GameObject[] gos;

        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
