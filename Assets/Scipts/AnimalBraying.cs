using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBraying : MonoBehaviour
{
    int i = 0;
	int iRandom;
    bool manEnd;
    // Use this for initialization
    void Start()
    {
		iRandom = Random.Range(200,700);
    }

    // Update is called once per frame
    void Update()
    {
        manEnd = GameObject.FindWithTag("MixAni").GetComponent<MixAnimation>().manEnd;
        if (!this.GetComponent<AudioSource>().isPlaying && !manEnd)
        {
			if(i == 0){iRandom = Random.Range(1700,2500);}
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
