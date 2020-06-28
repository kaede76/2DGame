using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    using UnityEngine.UI;

public class ToGameMain : MonoBehaviour
{
    private float step_time;
    [SerializeField] private Text TimeCount = default;
    private float Times;
    private int timekeeper;

    void Start()
    {
        step_time = 0f;
        Times = 15f;
        timekeeper = 0;
    }

    void Update()
    {
        step_time += Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
        {
            StartGame();
        }

        timekeeper = (int)Times - (int)step_time;

        TimeCount.text = (timekeeper).ToString("0") + "秒後にゲームが始まります...";

        if (step_time >= 15.0f)
        {
            SceneManager.LoadScene("GameMain");
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameMain");
    }
}
