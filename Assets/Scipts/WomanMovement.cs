using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMovement : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnCollisionStay(Collision other)
    {
        if(other.collider.CompareTag("Player")){
            
        }
    }

}
