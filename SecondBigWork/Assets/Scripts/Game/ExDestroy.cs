﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);//延迟两秒销毁自己
    }

    // Update is called once per frame
    void Update()
    {

    }
}
