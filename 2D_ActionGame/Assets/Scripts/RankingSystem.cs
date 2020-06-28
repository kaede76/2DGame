using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; // File
using UnityEngine.Networking;

public class RankingSystem : MonoBehaviour
{
    [SerializeField] private Text displayField = default;
    [SerializeField] private Text resultdisplayField = default;
    [SerializeField] private Text inputName = default;

    [SerializeField] private Text Ranking_1 = default;
    [SerializeField] private Text Ranking_2 = default;
    [SerializeField] private Text Ranking_3 = default;
    [SerializeField] private Text Ranking_4 = default;
    [SerializeField] private Text Ranking_5 = default;

    private int minute;
    private int seconds;

    private List<MemberData> _memberList;

    PanelScript Scripts;

    void Start()
    {
        Scripts = GetComponent<PanelScript>();
    }

    public void OnClickShowDisplay()
    {
        displayField.text = PanelScript.minute.ToString("00") + ":" + PanelScript.oldSeconds.ToString("00");
    }

    public void OnClickShowMemberList()
    {
        string sStrOutput = "";

        if (null == _memberList)
        {
            sStrOutput = "no list !";
        }
        else
        {
            //リストの内容を表示
            /*
            foreach (MemberData memberOne in _memberList)
            {
                sStrOutput += $"name:{memberOne.Name} age:{memberOne.Age} hobby:{memberOne.Hobby} \n";
            }
            */
            Ranking_1.text = "一位";
            Ranking_2.text = "二位";
            Ranking_3.text = "三位";
            Ranking_4.text = "四位";
            Ranking_5.text = "五位";

            foreach (MemberData memberOne in _memberList)
            {
                sStrOutput += $"プレイヤー名:{memberOne.Player}さん タイム:{memberOne.Time}秒\n";
            }
        }

        displayField.text = sStrOutput;
        resultdisplayField.text += "今回のタイムは" + PanelScript.resulttime + "秒です！";
    }

    //----------------------ここからデータベースの処理------------------------
    //-----------------------------getMessage---------------------------------

    public void OnClickGetJsonFromWebRequest()
    {
        displayField.text = "ちょっと待ってね...";
        GetJsonFromWebRequest();
    }

    private void GetJsonFromWebRequest()
    {
        // API を呼んだ際に想定されるレスポンス
        // [{"name":"\u3072\u3068\u308a\u3081","age":123,"hobby":"\u30b4\u30eb\u30d5"},{"name":"\u3075\u305f\u308a\u3081","age":25,"hobby":"walk"},{"name":"\u3055\u3093\u306b\u3093\u3081","age":77,"hobby":"\u5c71"}]
        //

        // Wwwを利用して json データ取得をリクエストする
        StartCoroutine(
            DownloadJson(
                CallbackWebRequestSuccess, // APIコールが成功した際に呼ばれる関数を指定
                CallbackWebRequestFailed // APIコールが失敗した際に呼ばれる関数を指定
            )
        );
    }

    private void CallbackWebRequestSuccess(string response)
    {
        //Json の内容を MemberData型のリストとしてデコードする。
        _memberList = MemberDataModel.DeserializeFromJson(response);

        //memberList ここにデコードされたメンバーリストが格納される。

        displayField.text = "ランキング表示ボタンを押してね!";
    }

    private void CallbackWebRequestFailed()
    {
        // jsonデータ取得に失敗した
        displayField.text = "WebRequest Failed";
    }

    private IEnumerator DownloadJson(Action<string> cbkSuccess = null, Action cbkFailed = null)
    {
        //UnityWebRequest www = UnityWebRequest.Get("http://localhost/sample_json.php");
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/rankingsystem/rankingsystem/getMessages");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log($"Success:{www.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(www.downloadHandler.text);
            }
        }
    }

    //-----------------------------setMessage----------------------------
    public void OnclickSetMessage()
    {
        displayField.text = "wait...";
        SetJsonWWW();
    }

    private void SetJsonWWW()
    {
        string sTgtURL = "http://localhost/rankingsystem/rankingsystem/setMessages";

        string player = inputName.text;
        int time = PanelScript.resulttime;

        StartCoroutine(SetMessage(sTgtURL, player, time, WebRequestSuccess, CallbackWebRequestFailed));
    }

    private IEnumerator SetMessage(string url, string player, int time, Action<string> cbkSuccess = null, Action cbkFaild = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("player", player);
        form.AddField("time", time);

        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);

        webRequest.timeout = 5;

        yield return webRequest.SendWebRequest();

        if (webRequest.error != null)
        {
            if (null != cbkFaild)
            {
                cbkFaild();
            }
        }
        else if (webRequest.isDone)
        {
            Debug.Log($"Success166:{webRequest.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(webRequest.downloadHandler.text);
            }
        }
    }

    private void WebRequestSuccess(string response)
    {
        displayField.text = response;
    }
}
