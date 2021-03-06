﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake3DSound : MonoBehaviour {
	AudioSource audio;
	Transform target;
	public float distance;
	public float originVolume = 0.3f;
	public float decrease = 0.005f;
	bool stopMusic;
	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource>();
		target = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		stopMusic = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().stopMusic;
		if(!stopMusic){
		distance = (transform.position - target.position).sqrMagnitude;
		audio.volume = originVolume - distance*decrease;
		}
	}
}
