using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuoli : MonoBehaviour
{
    public Vector3 nuolenSuunta;
    public float nopeus;
    private void Start()
    {
        Invoke("Tuhoa", 2);
    }
    void Update()
    {
        transform.Translate(Vector2.right * nopeus *Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Tuhoa()
    {
        Destroy(gameObject);
    }
}
