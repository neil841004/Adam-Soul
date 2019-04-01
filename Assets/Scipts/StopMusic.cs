using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {
	bool stopMusic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		stopMusic = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().stopMusic;
		if(stopMusic){
		FadeOutSound();
		}
	}
	void FadeOutSound(){
        this.StartCoroutine (FadeOut (this.GetComponent<AudioSource>(), 0.005f));
    }
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= FadeTime;
 
            yield return new WaitForSeconds(0.1f);
        }
         audioSource.Stop ();

    }
}
