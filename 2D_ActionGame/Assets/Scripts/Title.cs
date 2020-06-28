using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            StartGame();
        }
    }
    //　スタートボタンを押したら実行する
    public void StartGame()
    {
         SceneManager.LoadScene("Description");
    }
}
