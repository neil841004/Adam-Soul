using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMove : MonoBehaviour
{
    Transform target;
    Vector3 distance;
    Vector3 oringinPos;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        oringinPos = gameObject.transform.parent.GetComponent<Transform>().position;
        distance = (target.position - transform.position).normalized;
        transform.position = oringinPos + (distance * 0.07f);
    }
}
