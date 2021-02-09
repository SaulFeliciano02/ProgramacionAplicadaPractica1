using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class VelocidadScript : MonoBehaviour
{

    public Button btnslow;
    public Button btnNormal;
    public Button btnFast;
    public float currentSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        btnNormal.GetComponent<Image>().color = Color.yellow;
        btnslow.onClick.AddListener(setSlowSpeed);
        btnNormal.onClick.AddListener(setNormalSpeed);
        btnFast.onClick.AddListener(setFastSpeed);
    }

    void setSlowSpeed()
    {
        currentSpeed = 0.5f;
        btnslow.GetComponent<Image>().color = Color.yellow;
        btnNormal.GetComponent<Image>().color = Color.white;
        btnFast.GetComponent<Image>().color = Color.white;
    }

    void setNormalSpeed()
    {
        currentSpeed = 1;
        btnslow.GetComponent<Image>().color = Color.white;
        btnNormal.GetComponent<Image>().color = Color.yellow;
        btnFast.GetComponent<Image>().color = Color.white;
    }

    void setFastSpeed()
    {
        currentSpeed = 2;
        btnslow.GetComponent<Image>().color = Color.white;
        btnNormal.GetComponent<Image>().color = Color.white;
        btnFast.GetComponent<Image>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
