using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    GameObject Player;
    GameObject resultPoint;
    Player PlayerScript;
    ResiltPoint resultPointScript;
    [SerializeField]
    public static int minute;
    [SerializeField]
    private float seconds;
    public static int resulttime;
    //　前のUpdateの時の秒数
    public static float oldSeconds;
    //　ゴール後のタイム
    public float lasttime;
    //　タイマー表示用テキスト
    public Text timerText;
    public Text GoalItem;

    public int ItemCount;

    void Start()
    {
        Player = GameObject.Find("UnityChan_2");
        PlayerScript = Player.GetComponent<Player>();
        resultPoint = GameObject.Find("ResultZone");
        resultPointScript = resultPoint.GetComponent<ResiltPoint>();

        minute = 0;
        seconds = 0;
        oldSeconds = 0f;
        lasttime = 0f;
        resulttime = 0;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //if (PlayerScript.GoalItem >= 0)
        //{
        //    GoalItem.text = "×" + (ItemCount - PlayerScript.GoalItem);
        //}

        if (PlayerScript.GoalItem >= 0)
        {
            GoalItem.text = "×" + (ItemCount - PlayerScript.GoalItem);
            if (ItemCount <= 0)
            {
                GoalItem.text = "×" + 0;
            }
        }

        seconds += Time.deltaTime;
        if(seconds >=1.0f)
        {
            resulttime++;
            seconds = seconds - 1.0f;
        }
        //if (seconds >= 60f)
        //{
        //    minute++;
        //    seconds = seconds - 60;
        //}
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text =(resulttime).ToString("00秒");
        }
        oldSeconds = resulttime;
    }

    void TimeStop()
    {
        oldSeconds += Time.timeScale = 0f;
    }
}
