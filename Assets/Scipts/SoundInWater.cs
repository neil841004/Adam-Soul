using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInWater : MonoBehaviour {
	public int inW = 200;
	public int outW = 22000;

	void Update() {
		bool onWater = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().onRiver;
		if(onWater){InWater();}
		if(!onWater){OutWater();}	
	}

	void InWater()
    {
        this.GetComponent<AudioLowPassFilter>().cutoffFrequency = inW;

    }
    void OutWater()
    {
        this.GetComponent<AudioLowPassFilter>().cutoffFrequency = outW;

    }
}
