using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstanciadorArriba : MonoBehaviour
{
    public GameObject cow;
    enum Calle
    {
        A,
        B,
        C,
        D
    };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateCow", 0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCow()
    {
            GameObject clonecow = Instantiate(cow, new Vector3(-20, -20, -20), Quaternion.identity);
            Array values = Enum.GetValues(typeof(Calle));
            System.Random random = new System.Random();
            Calle randomDir = (Calle)values.GetValue(random.Next(values.Length));
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            Quaternion rotationPoint = new Quaternion(0, 0, 0, 0);
            char dir = 'A';
            switch (randomDir)
            {
                case Calle.B:
                    dir = 'B';
                    spawnPoint = new Vector3(-7.26f, -0.7f, 4);
                    rotationPoint = Quaternion.Euler(0, 0, 90);
                break;
                case Calle.A:
                    dir = 'A';
                    spawnPoint = new Vector3(7.26f, 0.7f, 4);
                    rotationPoint = Quaternion.Euler(0, 0, 270);
                break;
                case Calle.C:
                    dir = 'C';
                    spawnPoint = new Vector3(-1, 5, 4);
                break;
                case Calle.D:
                    dir = 'D';
                    spawnPoint = new Vector3(1, -5, 4);
                    rotationPoint = Quaternion.Euler(0, 0, 180);
                break;
            }

        clonecow.transform.position = spawnPoint;
        clonecow.transform.rotation = rotationPoint;
        clonecow.GetComponent<VacaScript>().Calle = dir;
        clonecow.GetComponent<VacaScript>().run = true;
    }    
}
