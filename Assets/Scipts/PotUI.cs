using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotUI : MonoBehaviour
{
    public Color color;
    public bool changeA = true;
    public Sprite[] icon;
    public int currentIcon = 0;
    public bool haveMix = false;
    GameObject a, b;
    public bool iHaveMix;
    public bool show = false;
    // Use this for initialization
    void Start()
    {        
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void Update()
    {
        a = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_1;
        b = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().animal_2;
        if (haveMix)
        {
            currentIcon = 4;
        }
        if (!haveMix)
        {
            if (!a || !b)
            {
                currentIcon = 1;
            }
            if (a && b && a.name != b.name)
            {
                currentIcon = 2;
            }
            if (a && b && a.name == b.name)
            {
                currentIcon = 3;
            }
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = icon[currentIcon];
        if(show){
        Flash();
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = color;
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
    }
    void FlashStart(){
        color.a = 0.5f;
        changeA = true;
        show = true;
    }
    void EndShow(){
        color.a = 0;
        show = false;
    }

}
