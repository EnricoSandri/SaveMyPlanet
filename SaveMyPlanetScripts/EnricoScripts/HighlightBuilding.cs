using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBuilding : MonoBehaviour
{

    Color selectColor;
    Renderer canvasRenderer;

    // Start is called before the first frame update
    void Start()
    {
        canvasRenderer = GetComponent<Renderer>();
        selectColor = new Color(0.1686275f, .3215686f, .1882353f);
    }
    

    private void OnMouseOver()
    {

        canvasRenderer.material.SetColor("_EmissionColor", selectColor);

    }

    private void OnMouseExit()
    {
        canvasRenderer.material.SetColor("_EmissionColor", Color.clear);
    }

}
