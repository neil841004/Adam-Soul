using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMusic : MonoBehaviour
{
    public AudioClip[] audios;
    public GameObject changeSongIcon;
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
            changeSongIcon.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && iTime == 0)
            {
                iCount += 1;
                if (iCount >= 2) { iCount = 0; }
                this.GetComponent<AudioSource>().clip = audios[iCount];
                this.GetComponent<AudioSource>().Play();
                iTime = 1;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            changeSongIcon.gameObject.SetActive(false);
        }
    }
    void FadeOutSound(){
        this.StartCoroutine (FadeOut (this.GetComponent<AudioSource>(), 0.017f));
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
