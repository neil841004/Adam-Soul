using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {
	private GameObject player;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Detect")&&player.GetComponent<PlayerMovement>().isAttack)
        {
            transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }
    }
}
