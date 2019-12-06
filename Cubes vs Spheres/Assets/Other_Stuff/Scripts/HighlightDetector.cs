using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightDetector : MonoBehaviour
{
    public MeshRenderer[] m;

    void OnMouseEnter() //If mouse is hovering over tile, tile highlighter is enabled
    {
        Debug.Log("YES");
        m = this.GetComponentsInChildren<MeshRenderer>();
        m[1].enabled = true;
    }

    void OnMouseExit() //Tile hightlighter is disabled
    {
        Debug.Log("NO");
        m = this.GetComponentsInChildren<MeshRenderer>();
        m[1].enabled = false;
    }
}