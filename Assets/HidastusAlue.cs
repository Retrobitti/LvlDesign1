using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidastusAlue : MonoBehaviour
{
    // Start is called before the first frame update
    float pelaajanLiikuminenEnnen;
    public float hidastusKerroin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pelaaja"))
        {
            pelaajanLiikuminenEnnen = collision.gameObject.GetComponent<PelaajanLiikkuminen>().liikkumisNopeus;
            collision.gameObject.GetComponent<PelaajanLiikkuminen>().liikkumisNopeus = pelaajanLiikuminenEnnen * hidastusKerroin;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pelaaja"))
        {
            collision.gameObject.GetComponent<PelaajanLiikkuminen>().liikkumisNopeus = pelaajanLiikuminenEnnen;
        }
    }
}
