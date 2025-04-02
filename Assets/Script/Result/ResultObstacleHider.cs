using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラとPlayerオブジェクトの間にあるオブジェクトを非表示にするクラス
/// </summary>
public class ResultObstacleHider : MonoBehaviour
{
    [SerializeField] Transform m_Player;                        //Playerオブジェクト
    const int m_DrawRayTime = 5;                                //レイの表示時間(ゲーム中は見えない)
    readonly Vector3 RaySize = new Vector3(0.5f, 0.5f, 0.5f);   //レイの大きさ

    List<GameObject> m_hitObject;                               //レイがヒットしたオブジェクトを格納

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_hitObject = new List<GameObject>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //レイの終了地点を代入
        Vector3 rayEndPosition =
            new Vector3(m_Player.transform.position.x,
            this.transform.position.y,
            m_Player.transform.position.z);

        //レイがヒットしたオブジェクトを有効化
        foreach (GameObject obj in m_hitObject)
        {
            obj.SetActive(true);
        }

        //前フレームのレイがヒットしたオブジェクトデータを破棄
        m_hitObject.Clear();

        //レイをPlayerの座標に向けて発射
        Ray CameraToPlayerRay = new Ray(this.transform.position,
            (rayEndPosition - this.transform.position).normalized);

        //レイがヒットしたオブジェクト全てを判定
        foreach (RaycastHit hit in Physics.BoxCastAll(this.transform.position, 
            RaySize,(rayEndPosition - this.transform.position).normalized,
           this.transform.rotation,Vector3.Distance(rayEndPosition,this.transform.position)))
        {
            //ヒットしたオブジェクトのタグが[Stage]の時実行
            if (hit.collider.gameObject.tag == "Stage")
            {
                //レイがヒットしたオブジェクトを格納
                m_hitObject.Add(hit.collider.gameObject);
                //ヒットしたオブジェクトを無効化
                hit.collider.gameObject.SetActive(false);
            }
        }

        //カメラ、プレイヤー間のレイを表示
        Debug.DrawRay(CameraToPlayerRay.origin,
            (rayEndPosition - this.transform.position),
            Color.red, m_DrawRayTime);
    }
}
