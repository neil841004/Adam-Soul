using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public float centerDistance = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = (this.transform.position.z - centerDistance) * -0.01f;
        this.transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
