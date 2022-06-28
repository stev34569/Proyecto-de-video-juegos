using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BienvenidaController : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nombreInput;

    [SerializeField]
    public Image fundido;

    SessionManager sessionManager;

    public AudioManager audioScript;


    void Start()
    {
        audioScript = AudioManager.Instance;
        audioScript.Play("Inicio");
        sessionManager = SessionManager.Instance;
        fundido.CrossFadeAlpha(0, 0.5f, false);

    }
   
    
    public void OnIniciar()
    {
        audioScript.Stop("Inicio");
        fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine("returne");
    }
    IEnumerator returne()
    {
        yield return new WaitForSeconds(1);
        sessionManager.nombre = nombreInput.text;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}