﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umarijuana : MonoBehaviour {
	bool eatUmariluana;
	public GameObject icon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//eatUmariluana = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().eatUmariluana;
	}
	private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
			icon.SetActive(true);
			GameObject.FindWithTag("Player").SendMessage("EatUmariluana");
        }
    }
	private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
			icon.SetActive(false);
        }
    }
}
