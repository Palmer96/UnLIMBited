using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.SetFloat("_FresnelExponent", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
