using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    [SerializeField]
    public string name;

    [SerializeField]
    public AudioClip clip;

    [SerializeField]
    [Range(0.0F, 1.0F)]
    public float volume;

    [SerializeField]
    [Range(0.1F, 3.0F)]
    public float pitch;

    [SerializeField]
    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
