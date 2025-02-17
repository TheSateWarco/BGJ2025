using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class OnClick : MonoBehaviour
{

    [SerializeField] private Renderer rend;
    private bool isClicked = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked on: " + gameObject.name);
        rend.material.color = Color.green;
        isClicked = true;
    }

    void OnMouseExit()
    {
        Debug.Log("Stopped hovering over: " + gameObject.name);
        isClicked = false;
    }

    // Change visibility to public so Hover can access it
    public bool getClickBool()
    {
        return isClicked;
    }
}