using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverExpand : MonoBehaviour
{
    private void OnMouseOver()
    {
        this.GetComponent<Animator>().SetBool("Hovered", true);
    }

    private void OnMouseExit()
    {
        this.GetComponent<Animator>().SetBool("Hovered", false);
    }
}
