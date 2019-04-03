using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTransparent : MonoBehaviour
{
    Color color;
    bool enterTree = false;


    // Use this for initialization
    void Start()
    {
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (enterTree)
        {
            if (color.a >= 0.5f)
            {
                color.a -= 0.05f;
            }
        }
        else
        {
            if (color.a <= 1)
            {
                color.a += 0.05f;
            }
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = color;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTree = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTree = false;
        }
    }
}
