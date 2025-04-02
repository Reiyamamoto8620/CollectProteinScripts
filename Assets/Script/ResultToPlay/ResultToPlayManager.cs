using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルトからプレイシーンの移行制御マネージャー
/// </summary>
public class ResultToPlayManager : MonoBehaviour
{
    [SerializeField] GameObject m_Fade;         //フェード制御

    Fade m_fade;                                //フェード制御クラス

    bool m_isFadeIn;                            //フェードイン判定
    
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_fade = m_Fade.GetComponent<Fade>();
        m_isFadeIn = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //フェード制御を更新
        m_fade.ManagedUpdate(m_isFadeIn, false);
        //フェードインが終了している時実行
        if(m_fade.GetIsFadeInEnd())
        {
            SceneManager.LoadScene("Play");
        }
    }
}
