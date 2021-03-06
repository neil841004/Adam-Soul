﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashIcon : MonoBehaviour
{
    Color color;
    bool changeA = true;
    // Use this for initialization
    void Start()
    {
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Flash();
    }
    void Flash()
    {
        if (color.a <= 0.3f)
        {
            changeA = false;
        }
        if (color.a >= 0.7)
        {
            changeA = true;
        }
        if (color.a >= 0.3f && changeA)
        {
            color.a -= 0.015f;
        }
        if (color.a <= 0.7f && !changeA)
        {
            color.a += 0.015f;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
