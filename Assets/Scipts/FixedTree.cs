using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTree : MonoBehaviour {
	Vector3 tree;
	// Use this for initialization
	void Start () {
		tree = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = tree;
	}
}
