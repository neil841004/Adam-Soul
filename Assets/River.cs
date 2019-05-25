﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            GameObject.FindWithTag("Player").SendMessage("InRiver");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            GameObject.FindWithTag("Player").SendMessage("OutRiver");
        }
    }
}