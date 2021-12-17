using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanOsumat : MonoBehaviour
{
    public PelaajanElamat pelaajanElamat;
    public float takaIskuVoima = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Nuoli"))
        {
            pelaajanElamat.MuutaElamia(-1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Sydan"))
        {
            pelaajanElamat.MuutaElamia(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Melee"))
        {
            pelaajanElamat.MuutaElamia(-1);
            GetComponent<Rigidbody2D>().AddForce((transform.position - collision.transform.position)*takaIskuVoima);
        }

    }
}
