using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject contenedorPantallasGO;
    public GameObject[] contenedorPantallasArray;

    // Definimos estado juego iniciado o detenido
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    int contadorPantallas = 0;
    int selectorPantallas;

    public GameObject pantallaAnterior;
    public GameObject pantallaNueva;

    public float tamañoPantalla;

    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;

    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject naveGo;

    [SerializeField]
    public Image fundido;

    public GameObject play;
    public GameObject pause;

    SessionManager sessionManager;

    void Start()
    {

        sessionManager = SessionManager.Instance;
        fundido.CrossFadeAlpha(0, 0.5f, false);
        InicioJuego();
    }

    void InicioJuego()
    {
        contenedorPantallasGO = GameObject.Find("ContenedorPantallas");

        mCamGo = GameObject.Find("MainCamera");
        mCamComp = mCamGo.GetComponent<Camera>();

        naveGo = GameObject.FindObjectOfType<Nave>().gameObject;


        VelocidadPantallas();
        MedirPantalla();
        BuscarPantallas();
    }
    public void juegoTerminadoEstados()
    {
        naveGo.GetComponent<AudioSource>().Stop();
    }

    void VelocidadPantallas()
    {
        velocidad = 10;
    }

    void BuscarPantallas()
    {
        contenedorPantallasArray = GameObject.FindGameObjectsWithTag("Pantalla");
        for(int i = 0; i < contenedorPantallasArray.Length; i++)
        {
            contenedorPantallasArray[i].gameObject.transform.parent = contenedorPantallasGO.transform;
            contenedorPantallasArray[i].gameObject.SetActive(false);
            contenedorPantallasArray[i].gameObject.name = "PantallaOFF_" + i;
        }
        CrearPantallas();
    }
    void CrearPantallas()
    {
        contadorPantallas ++;
        selectorPantallas = Random.Range(0, contenedorPantallasArray.Length);
        GameObject Pantalla = Instantiate(contenedorPantallasArray[selectorPantallas]);
        Pantalla.SetActive(true);
        Pantalla.name = "Pantalla" + contadorPantallas;
        Pantalla.transform.parent = gameObject.transform;
        PosicionarPantalla();
    }
    void PosicionarPantalla()
    {
        pantallaAnterior = GameObject.Find("Pantalla" + (contadorPantallas - 1));
        pantallaNueva = GameObject.Find("Pantalla" + contadorPantallas);
        MidoPantallas();
        pantallaNueva.transform.position = new Vector3(pantallaAnterior.transform.position.x,
            pantallaAnterior.transform.position.y + tamañoPantalla, 0);

        salioDePantalla = false;


    }
    void MidoPantallas()
    {
        for(int i = 0; i < pantallaAnterior.transform.childCount; i++)
        {
            if (pantallaAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = pantallaAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y - 0.1f;
                tamañoPantalla = tamañoPantalla + tamañoPieza;
            }
            
        }

    }

    public void pauseSi()
    {
        inicioJuego = false;
        pause.SetActive(false);
        play.SetActive(true);
        naveGo.GetComponent<AudioSource>().Stop();


    }
    public void pauseNo()
    {
        inicioJuego = true;
        pause.SetActive(true);
        play.SetActive(false);
        naveGo.GetComponent<AudioSource>().Play();
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCamComp.ScreenToViewportPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);

            if (pantallaAnterior.transform.position.y + tamañoPantalla < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoPantallas();
            }

        }
        
    }

    void DestruyoPantallas()
    {
        Destroy(pantallaAnterior);
        tamañoPantalla = 0;
        pantallaAnterior = null;
        CrearPantallas();
    }
}
