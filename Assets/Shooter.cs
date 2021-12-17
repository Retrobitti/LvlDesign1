using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool leftArrow;
    public bool midArrow;
    public bool rightArrow;
    public float startDelay = 1;
    public float attackSpeed = 1;
    public float spread = 10;

    public GameObject projectilePrefab;

    void Start()
    {
        Invoke("Shoot", startDelay);
    }

    void Shoot()
    {
        float attackTimer = 1 / attackSpeed;
        if (midArrow)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        if (rightArrow)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - spread));
        }
        if (leftArrow)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + spread));
        }
        
        

        Invoke("Shoot", attackTimer);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Nuoli"))
        {
            Destroy(gameObject);
            
        }
    }
}
