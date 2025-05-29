using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;

/// <summary>
/// サーバーにセーブデータを送り保存するクラス
/// </summary>
public class PostSaveData : MonoBehaviour
{
    [SerializeField]
    SaveDataScriptableObject m_SaveData;        //セーブデータ

    /// <summary>
    /// これを持ったオブジェクトが破棄されたときに起動
    /// </summary>
    void OnDestroy()
    {
        //ネットワークに接続がある場合実行
        if (NetworkState.CheckNetworkState())
        {
            SaveUserData();
        }
    }

    /// <summary>
    /// セーブデータをサーバーに送り、保存する
    /// </summary>
    async void SaveUserData()
    {
        //ログに所持プロテインを表示
        Debug.Log("PROTEIN :" +m_SaveData.m_data.protein);
        //セーブデータをJSONに変換
        string jsonstr = JsonUtility.ToJson(m_SaveData.m_data);
        //キーとセーブデータを紐づける
        var data = new Dictionary<string, object> { { "Data", jsonstr } };
        //サーバーにデータを送信
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }
}
