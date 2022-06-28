using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    [Tooltip("Nombre del jugador.")]
    public string nombre;

    [Tooltip("Marcador maximo.")]
    public int playerScore;

    [Tooltip("Marcador del jugador.")]
    public int scoreManejo;

    [Tooltip("Marcador realizado.")]
    public float realizado;



}
