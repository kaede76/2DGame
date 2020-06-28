using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField]
    //ポーズした時に表示するUiのプレハブ
    private GameObject pauseUI;
    //ポーズUiのインスタンス
    private GameObject pauseInstance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseInstance == null)
            {
                pauseInstance = GameObject.Instantiate(pauseUI) as GameObject;
            }
            else
            {
                Destroy(pauseInstance);
            }
        }
    }
}
