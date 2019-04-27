using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryIcon : MonoBehaviour
{
    public Sprite[] sprite;
    Sprite icon;
    int i = 0;
	int j = 0;

    // Use this for initialization
    void Start()
    {
        icon = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
		
		i++;
		if(i >= 15){
			i = 0;
		}
		if(i == 0){
        this.GetComponent<SpriteRenderer>().sprite = sprite[j];
		j++;
		if(j>=4){
			j = 0;
		}
		}
	}
}
