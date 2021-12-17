using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Painolaatta : MonoBehaviour
{
    public UnityEvent laattaPainuu;
    public UnityEvent laattaNousee;
    int kuinkaMontaPaalla;
    private void Start()
    {
        kuinkaMontaPaalla = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        kuinkaMontaPaalla++;
        laattaPainuu.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        kuinkaMontaPaalla--;
        if (kuinkaMontaPaalla == 0)
        {
            laattaNousee.Invoke();
        }
    }
}
