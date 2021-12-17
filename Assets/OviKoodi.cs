using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OviKoodi : MonoBehaviour
{
    public string esineJokaAvaa = "PunainenAvain";


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pelaaja") && Inventory.Instance.LaskeMaara(esineJokaAvaa) > 0)
        {
            Inventory.Instance.PoistaEsine(esineJokaAvaa);
            Destroy(gameObject);
        }
    }
}
