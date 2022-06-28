using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalController : MonoBehaviour
{

    public bool juegoTerminado;
    public float distanciaTotal;


    [SerializeField]
    public Image fundido;

    SessionManager sessionManager;


    [SerializeField]
    TextMeshProUGUI totalDistancia;

    [SerializeField]
    TextMeshProUGUI nombreJugador;

    [SerializeField]
    TextMeshProUGUI felicitaciones;

    [SerializeField]
    TextMeshProUGUI record;

    public AudioManager audioScript;

    FuelController fuelController;

    // Start is called before the first frame update
    void Start()
    {
        audioScript = AudioManager.Instance;
        audioScript.Play("Final");
        sessionManager = SessionManager.Instance;
        fundido.CrossFadeAlpha(0, 0.5f, false);
        finalizarjuego();
    }
    void finalizarjuego()
    {
        nombreJugador.text = sessionManager.nombre;
        totalDistancia.text = sessionManager.scoreManejo + ".Km";

        if (sessionManager.scoreManejo > sessionManager.playerScore)
        {
            sessionManager.playerScore = sessionManager.scoreManejo;
            felicitaciones.gameObject.SetActive(true);
            record.text = "Record: " + sessionManager.playerScore.ToString() + ".Km";
        }
        else
        {
            felicitaciones.gameObject.SetActive(false);
            record.text = "Record: " + sessionManager.playerScore.ToString() + ".Km";
        }

    }

    public void juegoTerminadoEstadosFinal()
    {
    }

    public void OnTerminar()
    {
        audioScript.Stop("Final");
        fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine("returne");
    }
    IEnumerator returne()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void Inicio()
    {
        audioScript.Stop("Final");
        fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine("retorno");
    }
    IEnumerator retorno()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }


    void Update()
    {
        
    }
}
