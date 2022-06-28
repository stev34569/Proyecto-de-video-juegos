using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
 
    [SerializeField]
    Sound[] sounds;

    protected override void Awake()
    {
        base.Awake();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s =
            Array.Find
                (
                    sounds,
                    f => f.name.Equals(name, StringComparison.OrdinalIgnoreCase)
                );

        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        if (s.source == null)
        {
            AudioSource.PlayClipAtPoint(s.clip, Camera.main.transform.position);
        }
        else
        {
            
            s.source.Play();
            
        }
    }

    public void Stop(String name)
    {
        Sound s =
            Array.Find
                (
                    sounds,
                    f => f.name.Equals(name, StringComparison.OrdinalIgnoreCase)
                );

        if (s == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        if (s.source == null)
        {
            AudioSource.PlayClipAtPoint(s.clip, Camera.main.transform.position);
        }
        else
        {

            s.source.Stop();

        }
        
    }
}

