using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolinaController : MonoBehaviour
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
            audioScript.Play("Aumento");
            fuelScript.fuel = fuelScript.fuel + 8;
            Destroy(this.gameObject);
        }
    }
}
