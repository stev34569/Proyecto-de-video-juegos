using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public GameObject fuelGo;
    public FuelController fuelScript;

    public AudioManager audioScript;

    private void Start()
    {
        audioScript = AudioManager.Instance;
        fuelGo = GameObject.FindObjectOfType<FuelController>().gameObject;
        fuelScript = fuelGo.GetComponent<FuelController>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Nave>()!= null)
        { 
            audioScript.Play("Choque");
            fuelScript.fuel = fuelScript.fuel - 20;
            Destroy(this.gameObject);
        }
    }
}
