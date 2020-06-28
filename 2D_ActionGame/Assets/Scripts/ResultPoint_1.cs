using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPoint_1 : MonoBehaviour
{
    public GameObject Resultpoint;
    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = Resultpoint.transform.position;
        }
    }
}
