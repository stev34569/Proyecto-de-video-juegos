using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{

    public GameObject gameManagerGo;
    public GameManager gameManagerScript;

    public Sprite[] numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorNaveGO;
    public GameObject naveGo;

    public GameObject window;

    // Start is called before the first frame update
    void Start()
    {
        inicioComponentes();
    }

    void inicioComponentes()
    {
        gameManagerGo = GameObject.Find("GameManager");
        gameManagerScript = gameManagerGo.GetComponent<GameManager>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        naveGo = GameObject.Find("Nave");
        controladorNaveGO = GameObject.Find("ControladorNave");
        InicioCuentaAtras();
    }


    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }
    IEnumerator Contando()
    {
        controladorNaveGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        gameManagerScript.inicioJuego = true;
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        naveGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        Destroy(window);
        contadorNumerosGO.SetActive(false);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
