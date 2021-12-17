using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Maalitaulu : MonoBehaviour
{
    public UnityEvent maaliinOsuuNuoli;
    public string nuolenTagi = "Nuoli";
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag(nuolenTagi))
        {
            maaliinOsuuNuoli.Invoke();
        }
    }
}
