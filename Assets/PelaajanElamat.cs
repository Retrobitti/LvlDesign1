using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PelaajanElamat : MonoBehaviour
{
    public int elamatAlussa;
    public static int elamat;
  
    public List<GameObject> elamaKuvat;
   
    // Start is called before the first frame update
    void Start()
    {    
        elamat = elamatAlussa;
        PaivitaKuvat();
    }

    public void MuutaElamia(int elamienMuutos)
    {
        if (elamat <= elamaKuvat.Count)
        {
            elamat += elamienMuutos;
            PaivitaKuvat();
        }
       
    }

    void PaivitaKuvat()
    {
        foreach (var item in elamaKuvat)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < elamat; i++)
        {
            elamaKuvat[i].SetActive(true);
        }
    }
}
