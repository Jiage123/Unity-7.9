using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // t += Time.deltaTime;
        t = Time.time;
        print(t);
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0, t * 0.2f);
    }
}
