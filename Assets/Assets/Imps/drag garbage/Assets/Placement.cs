using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
        ren.enabled = false;
    }

    private void OnMouseEnter()
    {
        if(ren.enabled == false)
        {
            ren.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (ren.enabled == true)
        {
            ren.enabled = false;
        }
    }

}
