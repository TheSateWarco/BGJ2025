using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Hover : MonoBehaviour
{

    [SerializeField] private Renderer rend;
    private OnClick onClick;  // Correct variable name

    void Start()
    {
        rend = GetComponent<Renderer>();
        onClick = GetComponent<OnClick>();  // Get OnClick component from the same GameObject
    }

    void OnMouseOver()
    {
        Debug.Log("Hovering over: " + gameObject.name);

        if (onClick != null && !onClick.getClickBool()) // Check if onClick is assigned
        {
            rend.material.color = Color.blue;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Stopped hovering over: " + gameObject.name);
        rend.material.color = Color.red;
    }
}