using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacaScript : MonoBehaviour
{
    public bool run;
    public char Calle;
    public GameObject barrera = null;
    private Vector3 movingCalle;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
    }

// Update is called once per frame
    void Update()
    {
        if (run)
        {
            switch (Calle)
            {
                case 'D':
                    movingCalle = new Vector3(0, 2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed, 0);
                    break;
                case 'C':
                    movingCalle = new Vector3(0, -2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed, 0);
                    break;
                case 'A':
                    movingCalle = new Vector3(-2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed, 0, 0);
                    break;
                case 'B':
                    movingCalle = new Vector3(2 * Time.deltaTime * GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed, 0, 0);
                    break;
            }
            gameObject.transform.position += movingCalle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "BarreraArribaYAbajo":
                run = manager.GetComponent<Manager>().ArribaYAbajo;
                if (!run)
                {
                    barrera = collider.gameObject;
                    manager.GetComponent<Manager>().cowsArray.Add(gameObject);
                }
                break;
            case "BarreraIzquierdaYDerecha":
                run = manager.GetComponent<Manager>().IzquierdaYDerecha;
                if (!run)
                {
                    barrera = collider.gameObject;
                    manager.GetComponent<Manager>().cowsArray.Add(gameObject);
                }
                break;
            case "Vaca":
                run = collider.gameObject.GetComponent<VacaScript>().run;
                if (!run)
                {
                    barrera = collider.gameObject.GetComponent<VacaScript>().barrera;
                    manager.GetComponent<Manager>().cowsArray.Add(gameObject);
                }
                break;
            case "Destroyer":
                Destroy(this.gameObject);
                break;
        }
    }
}
