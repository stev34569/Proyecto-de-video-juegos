using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{

    public GameObject motorPantallasGO;
    public GameManager gameManager;

    public Image gasolina;
    public float gasolinaMaxima;


    public float fuel;
    public float distancia;



    [SerializeField]
    TextMeshProUGUI distanciaScore;

    [SerializeField]
    TextMeshProUGUI tiempo;


    SessionManager sessionManager;

    void Start()
    {
        sessionManager = SessionManager.Instance;

        motorPantallasGO = GameObject.Find("GameManager");
        gameManager = motorPantallasGO.GetComponent<GameManager>();

        distanciaScore.text = "0.km";
        tiempo.text = "100%";

        gasolinaMaxima = 100;
        fuel = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.inicioJuego == true && gameManager.juegoTerminado == false)
        {
            
            calculoTiempoDistancia();
            
        }
        sessionManager.scoreManejo = ((int)distancia);
        if (fuel  <= 0 && gameManager.juegoTerminado == false)
        {
            gameManager.juegoTerminado = true;
            gameManager.juegoTerminadoEstados();
                 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        
    }
    void calculoTiempoDistancia()
    {
       
        distancia += Time.deltaTime * gameManager.velocidad;
        distanciaScore.text = ((int)distancia).ToString()+ ".km";
        

        float gasto = Time.deltaTime * gameManager.velocidad / 5;
        fuel -= gasto;

        gasolina.fillAmount = fuel / gasolinaMaxima;

        //tiempo.text = minutos.ToString() + segundos.ToString().PadLeft(2,'0')+ " %";
        tiempo.text = ((int)fuel).ToString() + "%";

    }
}
