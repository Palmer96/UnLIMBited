using UnityEngine;
using System.Collections;

public enum direction
{
    FORWARD = 1,
    RADIUS = 2,
}
[System.Serializable]
public class Burn
{
    public bool bBurn;
    public int burnDPS;
    public float burnTimer;
}

[System.Serializable]
public class Stun
{
    public bool stun;
    public float stunTimer;
}
public class Limb : MonoBehaviour
{
    
    public MeshFilter armMesh;
    public MeshFilter armElbow;
    public MeshFilter armWrist;

   
    public void Attach(PlayerLimb playerLimb)
    {
        playerLimb.ChangeLimb(this);
        Destroy(gameObject);
    }
}
