using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 匿名ログインクラス
/// </summary>
public class MyUnityAuthentivation : MonoBehaviour
{
    [SerializeField]
    SaveDataScriptableObject m_SaveData;    //セーブデータ

    /// <summary>
    /// 生成時に実行
    /// </summary>
    async void Awake()
    {
        bool isNetworkConnect = false;
        //初期化
        await UnityServices.InitializeAsync();
        Debug.Log(UnityServices.State);
        //ネットワーク接続がある場合実行
        if (NetworkState.CheckNetworkState())
        {
            //サインインを実行
            await SignInAnonymouslyAsync();
            //データをロード
            await LoadData();
            //ネットワークの接続判定をtrueに
            isNetworkConnect = true;
        }
        //ネットワーク接続がない場合実行
        else
        {
            //ネットワークの接続判定をfalseに
            isNetworkConnect = false;
        }
        //ゲームオブジェクトが削除されないようにする
        DontDestroyOnLoad(this.gameObject);

        //ネットワーク接続がある場合ログイン画面に移行
        if (isNetworkConnect)
        {
            SceneManager.LoadScene("Login");
        }
        //ネットワーク接続がない場合タイトル画面に移行
        else
        {
            SceneManager.LoadScene("Title");
        }
    }

    /// <summary>
    /// 匿名ログイン
    /// </summary>
    async UniTask SignInAnonymouslyAsync()
    {
        //匿名ログインを実行
        try
        {
            //匿名ログインを実行
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            //匿名ログイン成功
            Debug.Log("匿名サインイン成功!" + AuthenticationService.Instance.PlayerId);
        }
        //匿名ログインの認証に失敗
        catch (AuthenticationException ex)
        {
            // 認証エラー時の例外
            Debug.LogException(ex);
        }
        //それ以外の失敗
        catch (RequestFailedException exception)
        {
            // リクエストエラー時の例外
            Debug.LogException(exception);
        }
    }

    /// <summary>
    /// サーバーからセーブデータを取得
    /// </summary>
    public async UniTask LoadData()
    {
        //サーバーからセーブデータを獲得
        var playerData = 
            await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "Data" });
        //セーブデータから中身を取り出す。
        playerData.TryGetValue("Data", out var keyName);
        if (keyName != null)
        {
            //取り出したJSONデータを、オブジェクトに変換して格納
            m_SaveData.m_data =
                JsonUtility.FromJson<Data>(keyName.Value.GetAs<string>());
            Debug.Log("ローカルProtein :" + m_SaveData.m_data.protein);
        }
    }
}
