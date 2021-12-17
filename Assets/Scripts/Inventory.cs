using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public List<string> tavarat; //Voi nimetä vaikka inventoryksi (Ctrl+R) jos Suomenkieli käy hermoille.

    public int avaimet;
    public int nuolet;
    public int melonit; //No miksipä ei...
    public int kolikot;

    public GameObject avainLaskuri, nuoliLaskuri, meloniLaskuri, kolikkoLaskuri; //Lisää tähän omiasi tai poista olemassa olevia laskureita
    TextMeshProUGUI avainLaskuriTeksti, nuoliLaskuriTeksti, meloniLaskuriTeksti, kolikkoLaskuriTeksti; // Näytöllä näkyvät määrät

    // Ohjeet:
    //
    // Vedä Avaimet/Nuolet/Melonit gameObjektit editorissa Tavarat-objektissa oleviin laskuri slotteihin
    // ...se huutaa null reference exception jos unohdat!
    // (tai ehkä packaged prefba muistaa ne, emt)
    //
    // Funktiot:
    // LisaaEsine("Vesihiisi"); lisää "Vesihiisi"-nimisen esineen inventoryyn, laskee montako niitä on, näyttää näytöllä.
    // PoistaEsine("Avaimet"); poistaa "Avaimet" nimisen esineen inventorystä, laskee montako niitä on, näyttää näytöllä.
    // LaskeMaara("HerpDerp"); laskee montako DerpDerp nimistä itemiä on inventoryssä. Kertoo määrän Int muodossa!
    //
    //
    // Voit esim koodata:
    // Public Int Sammakot;
    //
    // LisaaEsine("Sammakko");
    // Sammakot = LaskeMaara("Sammakot");
    //
    // Nyt tuon Public Int Sammakot arvon pitäisi olla "1"!
    // Sitten tarvitset vaan skriptin joka näyttää ne näytöllä tai w/e
    // 
    // Huomaa että vaikka koodi toimii kaikennimisillä objekteilla niin siinä ei ole kuin avaimet/nuolet/melonit laskuri esillä näytöllä.
    // Muokkaa koodia omaan makuun!
    // Tämä koodi on tosi overengineered tähän peliin, mutta tässä on monimutkaisemman inventory systeemin juuret.

    

    void Start()
    {
        avaimet = LaskeMaara("Avain");
        nuolet = LaskeMaara("Nuoli");
        melonit = LaskeMaara("Meloni");
        kolikot = LaskeMaara("Kolikko");


        avainLaskuriTeksti = avainLaskuri.GetComponent<TextMeshProUGUI>();
        nuoliLaskuriTeksti = nuoliLaskuri.GetComponent<TextMeshProUGUI>();
        meloniLaskuriTeksti = meloniLaskuri.GetComponent<TextMeshProUGUI>(); //Lisää samalla tavalla omia jos haluat näytölle
        kolikkoLaskuriTeksti = kolikkoLaskuri.GetComponent<TextMeshProUGUI>();

        avainLaskuriTeksti.text = "Avaimet: "+LaskeMaara("Avain");
        nuoliLaskuriTeksti.text = "Nuolet: " + LaskeMaara("Nuoli");
        meloniLaskuriTeksti.text = "Melonit: " + LaskeMaara("Meloni");
        kolikkoLaskuriTeksti.text = "Kolikot: " + LaskeMaara("Kolikko");

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void LisaaEsine(string esine)
    {


            tavarat.Add(esine);
            LaskeMaara(esine);
            PaivitaLaskurinTeksti(esine); // Tämä funktio päivittää ruudulla olevan laskurin tekstin, JOS SE ON LISTASSA TUOLLA POHJALLA!

    }

    public void LisaaMontaEsinetta(string esine, int maara)
    {

            for (int i = 0; i < maara; i++)
            {
                tavarat.Add(esine);
                LaskeMaara(esine);
            }

        PaivitaLaskurinTeksti(esine); // Tämä funktio päivittää ruudulla olevan laskurin tekstin, JOS SE ON LISTASSA TUOLLA POHJALLA!

    }



    public void PoistaEsine(string esine)
    {
        tavarat.Remove(esine);
        LaskeMaara(esine);
        PaivitaLaskurinTeksti(esine);
    }


    public void PoistaMontaEsinetta(string esine, int maara)
    {

            for (int i = 0; i < maara; i++)
            {
                tavarat.Remove(esine);
                LaskeMaara(esine);
            }

        PaivitaLaskurinTeksti(esine);

    }


    public int LaskeMaara(string esineenNimi)
    {
        int tavaranMaara = 0;
        
        if (tavarat.Contains(esineenNimi))
        {
            foreach (var tavara in tavarat)
            {
                if (tavara == esineenNimi)
                {
                    tavaranMaara++;
                }
            }
            
            return tavaranMaara;
            
        }
        else
        {
            return 0;
        }
    }
    
    public void PaivitaLaskurinTeksti(string esineTeksti) //Esineen pitää olla tässä listassa jotta näkyy laskurissa. Varo typoja.
    {
        if (esineTeksti == "Avain")
        {
            avainLaskuriTeksti.text = "Avaimet: " + LaskeMaara("Avain");
        }
        if (esineTeksti == "Nuoli")
        {
            nuoliLaskuriTeksti.text = "Nuolet: " + LaskeMaara("Nuoli");
        }
        if (esineTeksti == "Meloni")
        {
            meloniLaskuriTeksti.text = "Meloonit: " + LaskeMaara("Meloni");
        }
        if (esineTeksti == "Kolikko")
        {
            kolikkoLaskuriTeksti.text = "Kolikot: " + LaskeMaara("Kolikko");
        }
    }

    // Instanssi //////////////////////////////////////////////////////////////
    private static Inventory _instance;

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Inventory>();
            }

            return _instance;
        }
    }
    //////////////////////////////////////////////////////////////////////////

}
