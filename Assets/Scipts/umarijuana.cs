using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umarijuana : MonoBehaviour {
	public GameObject rainbow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
			StartCoroutine("Crazzy");
        }
    }
	public IEnumerator Crazzy(){
		rainbow.SetActive(true);
		yield return new WaitForSeconds(5f);
		
		rainbow.SetActive(false);
	}
}
