using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaLiike : MonoBehaviour
{

    Rigidbody2D rb;
    float liikkuminenX;
    float liikkuminenY;
    public float liikkumisNopeus;
    Animator anim;
    




    // Update is called once per frame
    void Update()
    {
        float liikkuminenX = Input.GetAxis("Horizontal");
        float liikkuminenY = Input.GetAxis("Vertical");
        rb.position = rb.position + new Vector2(liikkuminenX * liikkumisNopeus / 500, liikkuminenY * liikkumisNopeus / 500);
        if (liikkuminenX > 0)
        {
            anim.Play("Oikea");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  

    private void FixedUpdate()
    {
        rb.position = rb.position + new Vector2(liikkuminenX, liikkuminenY).normalized * liikkumisNopeus / 500;
        print(new Vector2(liikkuminenX, liikkuminenY).normalized);
    }
}
