using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ネットワーク接続状態を表示するクラス
/// </summary>
public class NetworkVisualizer : MonoBehaviour
{
    
    [SerializeField] Sprite m_OnlineTexture;                //オンライン状態のテクスチャ
    [SerializeField] Sprite m_OfflineTexture;               //オフライン状態のテクスチャ
    [SerializeField] GameObject m_NetworkStateImage;        //ネットワークの状態を表示するオブジェクト
    [SerializeField] GameObject m_GachaStopImage;           //ガチャシーンの移行可能判定を可視化するオブジェクト
    void Awake()
    {
        Sprite nowNetWorkStateTexture;                                  //現在のネットワーク状態のテクスチャ
        //ネットワークの状態が接続状態の時実行
        if (NetworkState.CheckNetworkState())
        {
            //現在のネットワーク状態のテクスチャをオンラインにする。
            nowNetWorkStateTexture = m_OnlineTexture;
            //ガチャシーンの移行可能判定を非表示にする
            m_GachaStopImage.SetActive(false);
        }
        //ネットワークの状態が切断状態の時実行
        else
        {
            //現在のネットワーク状態のテクスチャをオフラインにする。
            nowNetWorkStateTexture = m_OfflineTexture;
            //ガチャシーンの移行可能判定を表示にする
            m_GachaStopImage.SetActive(true);
        }
        //ネットワーク状態を
        m_NetworkStateImage.GetComponent<Image>().sprite = nowNetWorkStateTexture;
    }
}
