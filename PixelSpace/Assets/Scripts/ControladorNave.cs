using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ControladorNave : MonoBehaviour
{

    public GameObject naveGo;

    public float anguloDeGiro;
    public float velocidad;

    public GameObject gameManagerGO;
    public GameManager gameManagerScript;

    private bool derecha = false;
    private bool izquierda = false;
    private float rangeX = 2.34f;


    private Vector3 inputVector;
    


    // Start is called before the first frame update
    void Start()
    {
        gameManagerGO = GameObject.Find("GameManager");
        gameManagerScript = gameManagerGO.GetComponent<GameManager>();

        naveGo = GameObject.FindObjectOfType<Nave>().gameObject;
        velocidad = 15;
        anguloDeGiro = 35;
    }


    void Update()
    {

        if (transform.position.x < -rangeX)
        {
            transform.position = new Vector2(-rangeX, -2.21f);
        }
        if (transform.position.x > rangeX)
        {
            transform.position = new Vector2(rangeX, -2.21f);
        }

        if (gameManagerScript.inicioJuego == true && gameManagerScript.juegoTerminado == false)
        {
            if (derecha)
            {
                // Movemos el objeto hacia la derecha

                this.transform.Translate(Vector2.right * Time.deltaTime * velocidad);
                naveGo.transform.Rotate(new Vector3(0, 0, 15));
            }

            if (izquierda)
            {
                // Movemos el objeto hacia la izquierda
                this.transform.Translate(Vector2.left * Time.deltaTime * velocidad);
                naveGo.transform.Rotate(new Vector3(0, 0, -15));
            }
        }

        if (gameManagerScript.inicioJuego == true && gameManagerScript.juegoTerminado == false)
        {
            float giroEnZ = 0;
            transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);

            giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;

            naveGo.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);
        }
    }

    public void MoverDerecha()
    {
        derecha = true;
    }

    public void MoverIzqda()
    {
        izquierda = true;
    }

    public void Detener()
    {
        derecha = false;
        izquierda = false;
    }
}
