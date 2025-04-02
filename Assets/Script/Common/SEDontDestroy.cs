using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SEがシーンを切り替えてもブツ切りされないようにするクラス
/// </summary>
public class SEDontDestroy : MonoBehaviour
{
    Scene m_createScene;      //生成されたシーン

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        //このオブジェクトが勝手に消えないようにする。
        DontDestroyOnLoad(this.gameObject);
        //生成されたシーンを保存
        m_createScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //SEが再生中ではなく、生成されたシーンと現在のシーンが違う時実行
        if (!this.GetComponent<AudioSource>().isPlaying && 
            m_createScene != SceneManager.GetActiveScene())
        {
            //このオブジェクトを削除する
            Destroy(this.gameObject); 
        }
    }
}
