using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{

    public List<string> tavarat; //Voi nimet� vaikka inventoryksi (Ctrl+R) jos Suomenkieli k�y hermoille.

    public int avaimet;
    public int nuolet;
    public int melonit; //No miksip� ei...
    public int kolikot;

    public GameObject avainLaskuri, nuoliLaskuri, meloniLaskuri, kolikkoLaskuri; //Lis�� t�h�n omiasi tai poista olemassa olevia laskureita
    TextMeshProUGUI avainLaskuriTeksti, nuoliLaskuriTeksti, meloniLaskuriTeksti, kolikkoLaskuriTeksti; // N�yt�ll� n�kyv�t m��r�t

    // Ohjeet:
    //
    // Ved� Avaimet/Nuolet/Melonit gameObjektit editorissa Tavarat-objektissa oleviin laskuri slotteihin
    // ...se huutaa null reference exception jos unohdat!
    // (tai ehk� packaged prefba muistaa ne, emt)
    //
    // Funktiot:
    // LisaaEsine("Vesihiisi"); lis�� "Vesihiisi"-nimisen esineen inventoryyn, laskee montako niit� on, n�ytt�� n�yt�ll�.
    // PoistaEsine("Avaimet"); poistaa "Avaimet" nimisen esineen inventoryst�, laskee montako niit� on, n�ytt�� n�yt�ll�.
    // LaskeMaara("HerpDerp"); laskee montako DerpDerp nimist� itemi� on inventoryss�. Kertoo m��r�n Int muodossa!
    //
    //
    // Voit esim koodata:
    // Public Int Sammakot;
    //
    // LisaaEsine("Sammakko");
    // Sammakot = LaskeMaara("Sammakot");
    //
    // Nyt tuon Public Int Sammakot arvon pit�isi olla "1"!
    // Sitten tarvitset vaan skriptin joka n�ytt�� ne n�yt�ll� tai w/e
    // 
    // Huomaa ett� vaikka koodi toimii kaikennimisill� objekteilla niin siin� ei ole kuin avaimet/nuolet/melonit laskuri esill� n�yt�ll�.
    // Muokkaa koodia omaan makuun!
    // T�m� koodi on tosi overengineered t�h�n peliin, mutta t�ss� on monimutkaisemman inventory systeemin juuret.

    

    void Start()
    {
        avaimet = LaskeMaara("Avain");
        nuolet = LaskeMaara("Nuoli");
        melonit = LaskeMaara("Meloni");
        kolikot = LaskeMaara("Kolikko");


        avainLaskuriTeksti = avainLaskuri.GetComponent<TextMeshProUGUI>();
        nuoliLaskuriTeksti = nuoliLaskuri.GetComponent<TextMeshProUGUI>();
        meloniLaskuriTeksti = meloniLaskuri.GetComponent<TextMeshProUGUI>(); //Lis�� samalla tavalla omia jos haluat n�yt�lle
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
            PaivitaLaskurinTeksti(esine); // T�m� funktio p�ivitt�� ruudulla olevan laskurin tekstin, JOS SE ON LISTASSA TUOLLA POHJALLA!

    }

    public void LisaaMontaEsinetta(string esine, int maara)
    {

            for (int i = 0; i < maara; i++)
            {
                tavarat.Add(esine);
                LaskeMaara(esine);
            }

        PaivitaLaskurinTeksti(esine); // T�m� funktio p�ivitt�� ruudulla olevan laskurin tekstin, JOS SE ON LISTASSA TUOLLA POHJALLA!

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
    
    public void PaivitaLaskurinTeksti(string esineTeksti) //Esineen pit�� olla t�ss� listassa jotta n�kyy laskurissa. Varo typoja.
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
