using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kameraseuraapelaajaa : MonoBehaviour
{
    public Transform Player;
    public float kameranNopeus;
    float kameraY;
    float kameraX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y > -1)
        {
            kameraY = Player.position.y;
        }
        kameraX = Player.position.x;
        transform.position = Vector3.Lerp(transform.position, new Vector3(kameraX, kameraY, -10), 0.01f * kameranNopeus);

    }
}