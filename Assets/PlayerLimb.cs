using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimb : MonoBehaviour
{

    public MeshFilter armMesh;
    public MeshFilter armElbow;
    public MeshFilter armWrist;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLimb(Limb limb)
    {
        armMesh.mesh = limb.armMesh.mesh;
        armElbow.mesh = limb.armElbow.mesh;
        armWrist.mesh = limb.armWrist.mesh;
    }
    public void DetachLimb(Limb limb)
    {
        armMesh.mesh = null;
        armElbow.mesh = null;
        armWrist.mesh = null;
    }
}
