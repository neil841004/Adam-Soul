using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMusic : MonoBehaviour
{
    public AudioClip[] audios;
    public GameObject changeSongIcon;
    public GameObject stopSongIcon;
    int iCount = 0;
    int iTime = 0;
    // Use this for initialization
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audios[iCount];
        this.GetComponent<AudioSource>().Play();
    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (iTime > 0)
        {
            iTime++;
            if (iTime >= 5)
            {
                iTime = 0;
            }
        }
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (iCount == 0 || iCount == 2)
            {
                changeSongIcon.gameObject.SetActive(true);
                stopSongIcon.gameObject.SetActive(false);
            }
            if (iCount == 1)
            {
                stopSongIcon.gameObject.SetActive(true);
                changeSongIcon.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && iTime == 0)
            {
                GameObject.FindWithTag("Sound").gameObject.SendMessage("Sound", 2);
                iCount += 1;
                if (iCount >= 3) { iCount = 0; }
                this.GetComponent<AudioSource>().clip = audios[iCount];
                this.GetComponent<AudioSource>().Play();
                iTime = 1;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeSongIcon.gameObject.SetActive(false);
            stopSongIcon.gameObject.SetActive(false);
        }
    }
    void FadeOutSound()
    {
        this.StartCoroutine(FadeOut(this.GetComponent<AudioSource>(), 0.011f));

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
    void FadeOutLowPass()
    {
        this.GetComponent<AudioLowPassFilter>().cutoffFrequency = 200;
        this.StartCoroutine(Out(this.GetComponent<AudioSource>(), 0.01f));
        this.StopCoroutine("Out");
    }
    void FadeInLowPass()
    {
        this.GetComponent<AudioLowPassFilter>().cutoffFrequency = 22000;
        this.StartCoroutine(In(this.GetComponent<AudioSource>(), 0.01f));
        this.StopCoroutine("In");
    }
    public static IEnumerator Out(AudioSource audioSource, float FadeTime)
    {
        while (audioSource.volume > 0.15f)
        {
            audioSource.volume -= FadeTime;
            yield return new WaitForSeconds(0.15f);
        }
    }
    public static IEnumerator In(AudioSource audioSource, float FadeTime)
    {
        while (audioSource.volume < 0.25f)
        {
            audioSource.volume += FadeTime;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
