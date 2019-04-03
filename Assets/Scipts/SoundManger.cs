using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    int package = 0;
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
    void Sound(int id)
    {
        this.GetComponent<AudioSource>().PlayOneShot(se[id]);
        if (id == 6)
        {
            if (package == 1) { this.GetComponent<AudioSource>().pitch = 0.7f; }
            if (package == 2) { this.GetComponent<AudioSource>().pitch = 0.5f; }
        }
        else
        {
            this.GetComponent<AudioSource>().pitch = 1;
        }
        if (id == 4 || id == 5 || id == 13 || id == 1)
        {
            if (id == 4 || id == 5)
            {
                this.GetComponent<AudioSource>().volume = 1;
            }
            if (id == 13)
            {
                this.GetComponent<AudioSource>().volume = 0.2f;
            }
            if(id == 1){
                this.GetComponent<AudioSource>().volume = 0.4f;
            }
        }
        else { this.GetComponent<AudioSource>().volume = 0.65f; }
    }
    void FadeOutSound(int id)
    {
        this.GetComponent<AudioSource>().clip = se[id];
        this.StartCoroutine(FadeOut(this.GetComponent<AudioSource>(), 0.1f));
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= FadeTime;

            yield return new WaitForSeconds(0.1f);
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
    void Package(int i)
    {
        package = i;
    }
}
