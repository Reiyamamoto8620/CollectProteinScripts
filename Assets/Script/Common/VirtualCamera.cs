using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// カメラ移動制御クラス
/// </summary>
public class VirtualCamera : MonoBehaviour
{
    [SerializeField] GameObject m_FirstCameraPosition;        //現在のカメラ位置のオブジェクト
    [SerializeField] GameObject m_SecondCameraPosition;       //カメラの移動先のオブジェクト

    CinemachineVirtualCamera m_firstCamera;                   //現在のカメラ位置
    CinemachineVirtualCamera m_secondCamera;                  //カメラの移動先

    const int m_CameraMoveWaitTime = 2;                     //カメラの移動開始を待つフレーム
    const int m_VirtualCameraOn = 1;                        //起動しているカメラの優先値
    const int m_VirtualCameraOff = 0;                       //停止しているカメラの優先値

    bool m_isBlend;                                         //カメラのブレンド開始判定
    CinemachineBrain m_brain;                               //カメラ制御クラス
    int m_cameraMoveWaitCount;                              //カメラの移動開始を待つカウント

    string m_nowSceneName;                                  //現在のシーン名

    /// <summary>
    /// 起動時に実行
    /// </summary>
    void Awake()
    {
        m_firstCamera = m_FirstCameraPosition.GetComponent<CinemachineVirtualCamera>();
        m_secondCamera = m_SecondCameraPosition.GetComponent<CinemachineVirtualCamera>();

        m_isBlend = false;
        m_cameraMoveWaitCount = 0;
        m_nowSceneName = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //カメラの移動開始の待機時間が過ぎた時に実行
        if (m_cameraMoveWaitCount > m_CameraMoveWaitTime)
        {
            //現在のカメラを停止状態にする
            m_firstCamera.Priority = m_VirtualCameraOff;
            //移動先のカメラを起動状態にする
            m_secondCamera.Priority = m_VirtualCameraOn;
        }

        //カメラの移動開始の待ち時間をカウント
        m_cameraMoveWaitCount++;

        //自身が管理しているカメラのBrainを取得
        m_brain = CinemachineCore.Instance.FindPotentialTargetBrain(m_secondCamera);

        //カメラのブレンド判定がNull以外の時、または、カメラのブレンド開始判定がtrueの時実行
        if (m_brain.ActiveBlend != null || m_isBlend)
        {
            //カメラのブレンド判定がNullで、カメラのブレンド開始判定がtrueの時実行
            if (m_brain.ActiveBlend == null && m_isBlend)
            {
                //シーンがTitleToPlayの時実行
                if(m_nowSceneName == "TitleToPlay")
                {
                    //PlaySceneにシーン変更
                    SceneManager.LoadScene("Play");
                }
                //シーンがPlayToResultの時実行
                if (m_nowSceneName == "PlayToResult")
                {
                    //ResultSceneにシーン変更
                    SceneManager.LoadScene("Result");
                }
            }
            //ブレンド判定を有効化
            m_isBlend = true;
        }
    }
}
