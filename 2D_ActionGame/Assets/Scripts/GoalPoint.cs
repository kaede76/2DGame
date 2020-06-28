using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GoalPoint : MonoBehaviour
{
    [SerializeField] private Text LogText = default;

    public int ItemPoint;
    GameObject Timer;
    GameObject Player;
    PanelScript Timerscript;
    Player PlayerScript;

    void Start()
    {
        Timer = GameObject.Find("TimePanel");
        Player = GameObject.Find("UnityChan_2");
        Timerscript = Timer.GetComponent<PanelScript>();
        PlayerScript = Player.GetComponent<Player>();
    }

    private void Update()
    {
        if(PlayerScript.GoalItem >= ItemPoint)
        {
            LogText.text = "ゴールへ向かおう！";
            //Destroy(LogText);
        }
    }

    //プレイヤーに接触したとき
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //ゴール出来る場合
            if(PlayerScript.GoalItem >= ItemPoint)
            {
                Debug.Log(PanelScript.oldSeconds);
                SceneManager.LoadScene("Result");
            //ゴール出来ない場合
            }
            else
            {
                LogText.text = "まだラーメンが足りないよ！";
                Debug.Log("まだゴールできない");
            }
        }
    }
}
