using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioClip[] se;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlaySound(int id)
    {
        this.GetComponent<AudioSource>().clip = se[id];
        this.GetComponent<AudioSource>().Play();

    }
    void StopSound(int id)
    {
        this.GetComponent<AudioSource>().clip = se[id];
        this.GetComponent<AudioSource>().Stop();
    }
    void FadeOutSound(int id){
        this.GetComponent<AudioSource>().clip = se[id];
        this.StartCoroutine (FadeOut (this.GetComponent<AudioSource>(), 0.1f));
    }
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= FadeTime;
 
            yield return new WaitForSeconds(0.1f);
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
}
