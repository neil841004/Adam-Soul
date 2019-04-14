using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public float centerDistance = 0;
    int sort;
    float fixedZ;
    // Use this for initialization
    void Start()
    {
        sort = this.GetComponent<SpriteRenderer>().sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z != fixedZ){
        // float y = (this.transform.position.z - centerDistance) * -0.01f;
        // this.transform.position = new Vector3(transform.position.x, y, transform.position.z);
        sort = (int)((this.transform.position.z - centerDistance) * -7);
        this.GetComponent<SpriteRenderer>().sortingOrder = sort;
        fixedZ = this.transform.position.z;
        }
    }
}
