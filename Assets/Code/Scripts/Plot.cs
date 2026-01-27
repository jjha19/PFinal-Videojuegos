using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered: " + gameObject.name);
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("Build tower here" + gameObject.name);
    }
}
