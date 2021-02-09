﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInterseccion : MonoBehaviour
{
    public int cowsCounter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        cowsCounter++;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        cowsCounter--;
    }
}
