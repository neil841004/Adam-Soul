using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBraying : MonoBehaviour
{
    int i = 0;
	int iRandom;
    // Use this for initialization
    void Start()
    {
		iRandom = Random.Range(200,700);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
			if(i == 0){iRandom = Random.Range(100,500);}
            if (i <= iRandom)
            {
				if(i == iRandom-1){
					this.GetComponent<AudioSource>().Play();
				}
                i++;
				if(i == iRandom){
					i = 0;
				} 
            }

        }

    }
}
