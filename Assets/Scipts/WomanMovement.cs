﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMovement : MonoBehaviour
{
    public GameObject love;
    GameObject lv;

    // Use this for initialization
    void Start()
    {
        lv = Instantiate(love, transform.position, transform.rotation);
        lv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (lv.GetComponent<Love>().i <= 37)
            {
                lv.SetActive(true);
            }
            if (lv.GetComponent<Love>().i >= 38)
            {
                lv.SetActive(false);
                this.GetComponent<Animator>().SetBool("child",true);
                GameObject.FindWithTag("MixAni").GetComponent<Animator>().SetBool("child",false);
            }


        }
    }
    private void OnCollisionEnter(Collision other)
    {
        bool manEnd = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().manEnd;
        if (!this.GetComponent<AudioSource>().isPlaying && !manEnd && other.collider.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
            
        }
        if(other.collider.CompareTag("Player")){
            this.GetComponent<Animator>().SetBool("love",true);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            lv.SetActive(false);
            this.GetComponent<Animator>().SetBool("love",false);
            
        }
    }
}
