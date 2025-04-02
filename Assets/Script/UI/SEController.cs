using UnityEngine;

/// <summary>
/// SE制御クラス
/// </summary>
public class SEController : MonoBehaviour
{
    [SerializeField] AudioClip m_SelectSE;      //選択SE
    [SerializeField] AudioClip m_EnterSE;       //決定SE
    [SerializeField] GameObject m_AudioSource;  //オーディオソース
    AudioSource m_audioSource;                  //オーディオソースクラス

    int m_lastSelectValue;                      //前回のセレクト番号
    bool m_lastIsSkin;                          //前回のスキンの判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_audioSource = m_AudioSource.GetComponent<AudioSource>();
        m_lastSelectValue = 0;
        m_lastIsSkin = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue, bool _isEnter,bool _isSkin)
    {
        //前回のセレクト番号が今回のセレクト番号と値が違う、
        //前回のスキン判定が今回のスキン判定と値が違う時に実行
        if (m_lastSelectValue != _selectValue || m_lastIsSkin != _isSkin)
        {
            m_audioSource.PlayOneShot(m_SelectSE);
        }
        //決定ボタンが押された時実行
        if (_isEnter)
        {
            m_audioSource.PlayOneShot(m_EnterSE);
        }
        //今回のセレクト番号を保存する
        m_lastSelectValue = _selectValue;
        //今回のスキン判定を保存する
        m_lastIsSkin = _isSkin;
    }
}
