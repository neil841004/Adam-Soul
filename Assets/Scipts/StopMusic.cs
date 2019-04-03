using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {
	bool stopMusic;
	bool stop = true;
	float volume;
	// Use this for initialization
	void Start () {
		volume = this.GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {
		if(stop){
		stopMusic = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().stopMusic;
		}
		if(stopMusic && stop){
		this.StartCoroutine (FadeOut (this.GetComponent<AudioSource>(), volume * 0.1f));
		stop = false;
		}
	}

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {

        while (audioSource.volume > 0) {
            audioSource.volume -= FadeTime;
            yield return new WaitForSeconds(0.1f);
        }
        audioSource.Stop ();

    }
}
