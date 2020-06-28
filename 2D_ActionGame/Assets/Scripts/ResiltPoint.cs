using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResiltPoint : MonoBehaviour
{
    GameObject Player;
    public float DieCount;
    [SerializeField] private GameObject ResultPoint;

    void Start()
    {
        Player = GameObject.Find("UnityChan_2");
        DieCount = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = ResultPoint.transform.position;
            DieCount++;

//            SceneManager.LoadScene("GameMain");
        }
    }
}
