using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPS : MonoBehaviour
{
    Animator animator;
    Animator screenAnimator;
    Animator ps4Animator;
    bool OpenPs4 = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("PS4") && GameObject.Find("Screen") && !OpenPs4)
        {
            animator.SetBool("onPS4", true);
			screenAnimator = GameObject.Find("Screen").GetComponent<Animator>();
            ps4Animator = GameObject.Find("PS4").GetComponent<Animator>();
            screenAnimator.SetBool("onPS4", true);
            ps4Animator.SetBool("onPS4", true);
            this.GetComponent<AudioSource>().Play();
            OpenPs4 = true;
        }
    }
}
