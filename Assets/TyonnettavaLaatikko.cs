using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyonnettavaLaatikko : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //rb.MovePosition(rb.position + collision.collider.transform.position);
    }
}
