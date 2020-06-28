using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //　ボタンを押したら実行する
    public void BackGame()
    {
        SceneManager.LoadScene("GameMain");
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
