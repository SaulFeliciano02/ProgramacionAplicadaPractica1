using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

public class Manager : MonoBehaviour
{
    public List<GameObject> semafaroArriba, semafaroAbajo, semafaroIzquierda, semafaroDerecha;
    public bool ArribaYAbajo;
    public bool IzquierdaYDerecha;
    public ArrayList cowsArray = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FuncionamientoSemafaros());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SemaforoArribaYAbajoVerde()
    {
        semafaroArriba[0].SetActive(false); //Verde
        semafaroArriba[1].SetActive(true); //Amarillo
        semafaroArriba[2].SetActive(true); //Rojo  

        semafaroAbajo[0].SetActive(true); //Rojo
        semafaroAbajo[1].SetActive(true); //Amarillo
        semafaroAbajo[2].SetActive(false); //Verde 

        semafaroIzquierda[0].SetActive(false); //Rojo
        semafaroIzquierda[1].SetActive(true); //Amarillo
        semafaroIzquierda[2].SetActive(true); //Verde

        semafaroDerecha[0].SetActive(false); //Rojo
        semafaroDerecha[1].SetActive(true); //Amarillo
        semafaroDerecha[2].SetActive(true); //Verde 

        ArribaYAbajo = true;
        IzquierdaYDerecha = false;
        PasoAbierto();
    }

    void SemaforoArribaYAbajoAmarillo()
    {
        semafaroArriba[0].SetActive(true); //Verde
        semafaroArriba[1].SetActive(false); //Amarillo
        semafaroArriba[2].SetActive(true); //Rojo  

        semafaroAbajo[0].SetActive(true); //Rojo
        semafaroAbajo[1].SetActive(false); //Amarillo
        semafaroAbajo[2].SetActive(true); //Verde 

        semafaroIzquierda[0].SetActive(false); //Rojo
        semafaroIzquierda[1].SetActive(true); //Amarillo
        semafaroIzquierda[2].SetActive(true); //Verde

        semafaroDerecha[0].SetActive(false); //Rojo
        semafaroDerecha[1].SetActive(true); //Amarillo
        semafaroDerecha[2].SetActive(true); //Verde 

        ArribaYAbajo = true;
        IzquierdaYDerecha = false;

    }

    void SemaforoIzquierdaYDerechaVerde()
    {
        semafaroArriba[0].SetActive(true); //Verde
        semafaroArriba[1].SetActive(true); //Amarillo
        semafaroArriba[2].SetActive(false); //Rojo  

        semafaroAbajo[0].SetActive(false); //Rojo
        semafaroAbajo[1].SetActive(true); //Amarillo
        semafaroAbajo[2].SetActive(true); //Verde 

        semafaroIzquierda[0].SetActive(true); //Rojo
        semafaroIzquierda[1].SetActive(true); //Amarillo
        semafaroIzquierda[2].SetActive(false); //Verde

        semafaroDerecha[0].SetActive(true); //Rojo
        semafaroDerecha[1].SetActive(true); //Amarillo
        semafaroDerecha[2].SetActive(false); //Verde 

        ArribaYAbajo = false;
        IzquierdaYDerecha = true;
        PasoAbierto();

    }

    void SemaforoIzquierdaYDerechaAmarillo()
    {
        semafaroArriba[0].SetActive(true); //Verde
        semafaroArriba[1].SetActive(true); //Amarillo
        semafaroArriba[2].SetActive(false); //Rojo  

        semafaroAbajo[0].SetActive(false); //Rojo
        semafaroAbajo[1].SetActive(true); //Amarillo
        semafaroAbajo[2].SetActive(true); //Verde 

        semafaroIzquierda[0].SetActive(true); //Rojo
        semafaroIzquierda[1].SetActive(false); //Amarillo
        semafaroIzquierda[2].SetActive(true); //Verde

        semafaroDerecha[0].SetActive(true); //Rojo
        semafaroDerecha[1].SetActive(false); //Amarillo
        semafaroDerecha[2].SetActive(true); //Verde 

        ArribaYAbajo = false;
        IzquierdaYDerecha = true;

    }

    IEnumerator FuncionamientoSemafaros()
    {
        float velocidad = GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed;
        while (true)
        {
            velocidad = GameObject.Find("Canvas").GetComponent<VelocidadScript>().currentSpeed;
            SemaforoArribaYAbajoVerde();
            yield return new WaitForSeconds(10 / velocidad);

            SemaforoArribaYAbajoAmarillo();
            yield return new WaitForSeconds(7 / velocidad);

            SemaforoIzquierdaYDerechaVerde();
            yield return new WaitForSeconds(10 / velocidad);

            SemaforoIzquierdaYDerechaAmarillo();
            yield return new WaitForSeconds(7 / velocidad);
        }
    }

    IEnumerator IniciarMoverVacas()
    {
        while (cowsArray.Count > 0)
        {
            GameObject vaca = cowsArray[0] as GameObject;
            vaca.GetComponent<VacaScript>().run = true;
            vaca.GetComponent<VacaScript>().barrera = null;
            cowsArray.Remove(vaca);
        }
        yield return new WaitForSeconds(0);
    }

    async void PasoAbierto()
    {
        GameObject triggerStreet = GameObject.Find("TriggerInterseccion");
        while (triggerStreet.GetComponent<TriggerInterseccion>().cowsCounter > 0)
        {
            await Task.Yield();
        }
        StartCoroutine(IniciarMoverVacas());
    }
}
    