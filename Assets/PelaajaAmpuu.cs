using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaAmpuu : MonoBehaviour
{
    public float ampumisHidastus = 1;

    float lataamisAjastin;

    public GameObject nuoli;
    public int nuolienMaaraAlussa;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.Instance.LisaaMontaEsinetta("Nuoli", nuolienMaaraAlussa);
        lataamisAjastin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && lataamisAjastin <= 0)
        {
            Ammu();
            lataamisAjastin = ampumisHidastus;
        }

        if (lataamisAjastin > 0)
        {
            lataamisAjastin -= Time.deltaTime;
        }
       
    }

    void Ammu()
    {
        if (Inventory.Instance.LaskeMaara("Nuoli") > 0)
        {
            Inventory.Instance.PoistaEsine("Nuoli");
            GameObject klooni = Instantiate(nuoli, transform.GetChild(0).position, transform.rotation);

        }
   
    }
}
