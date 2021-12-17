using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerattavaEsine : MonoBehaviour
{

    public string esineenTyyppi = "Avain";
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pelaaja"))
        {
            Inventory.Instance.LisaaEsine(esineenTyyppi);
            Destroy(gameObject);
        }
    }
}
