using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour
{
    public bool selected;
    public Shader newShader;
    private Shader oldShader;
    private float width;
    // Use this for initialization
    void Start()
    {
        selected = false;
        oldShader = GetComponent<Renderer>().material.shader;
        width = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (selected)
        {
            if (width < 0.04f)
            {
                width += 0.01f;
            }
        }
        else
        {
            if (width > 0)
            {
                width -= 0.01f;
            }
        }
        GetComponent<Renderer>().material.SetFloat("_OutlineWidth", width);
        selected = false;
    }
}
