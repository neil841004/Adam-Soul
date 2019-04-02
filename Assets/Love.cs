using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Love : MonoBehaviour
{
    public Transform target;
    public float height = 1.2f;
    int i = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loveTarget = new Vector3(target.position.x, target.position.y, target.position.z + height);
        transform.position = loveTarget;
		if (i <= 30)
        {
            Vector3 s3 = new Vector3(i * 0.0001f, i * 0.0001f, 0);
            transform.localScale += s3;
            height += 0.0007f;
        }
    }
    public void Increase()
    {
        if (i <= 45)
        {
			i++;
        }
    }
}
