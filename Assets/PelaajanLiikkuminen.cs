using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanLiikkuminen : MonoBehaviour
{
    public float liikkumisNopeus;

    Rigidbody2D rb;
    float liikkuminenX;
    float liikkuminenY;
    public Transform ase;
    public static float aseenSuunta;

    SpriteRenderer spRend;
    public Sprite vasenHahmo, oikeaHahmo, ylosHahmo, alasHahmo;

    public Transform tahtain;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        liikkuminenX = Input.GetAxisRaw("Horizontal");
        liikkuminenY = Input.GetAxisRaw("Vertical");

        //Mihin suuntaan pelaaja kulkee N W S E
        if (liikkuminenX > 0)
        {
            //liikkuu oikealle
            aseenSuunta = 0;
            spRend.sprite = oikeaHahmo;
        }
        else if(liikkuminenX < 0)
        {
            //liikkuu vasemmalle
            aseenSuunta = 180;
            spRend.sprite = vasenHahmo;
        }
        if (liikkuminenY > 0)
        {
            //liikkuu ylös
            aseenSuunta = 90;
            spRend.sprite = ylosHahmo;
        }
        else if (liikkuminenY < 0)
        {
            //liikkuu alas
            aseenSuunta = -90;
            spRend.sprite = alasHahmo;
        }

        tahtain.rotation = Quaternion.Euler(0, 0, aseenSuunta);
    }
    private void FixedUpdate()
    {
        rb.position = rb.position + new Vector2(liikkuminenX, liikkuminenY).normalized * liikkumisNopeus / 500;

    }
}
