using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// アイテムの動作管理
/// </summary>
public class PointItemAction : MonoBehaviour
{
    LineRenderer m_lineRenderer;            //アイテムから落ちる線
    const float m_ItemRotateSpeed = 1f;     //アイテムの回転速度
    const int m_ItemLineHeight = 5;         //線の表示を開始する高さ
    const float m_LineWidth = 0.05f;        //線の太さ
    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        if (this.gameObject.tag == "Protein")
        {
            //LineRendererをアタッチ
            m_lineRenderer = GetComponent<LineRenderer>();

            m_lineRenderer.startWidth = m_LineWidth;
            m_lineRenderer.endWidth = m_LineWidth;
        }
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        //アイテムを回転させる
        transform.Rotate(0f, m_ItemRotateSpeed, 0f, Space.World);

        //アイテムの高さがm_ItemLineHeight以下で、
        //アイテムがプロテインかつシーンがPlayの時実行
        if (this.transform.position.y <= m_ItemLineHeight &&
            this.gameObject.tag == "Protein" &&
            SceneManager.GetActiveScene().name == "Play")
        {
            Vector3 lineEndPoint = this.transform.position;
            lineEndPoint.y = 0;
            // 線を引く場所を指定する
            m_lineRenderer.SetPositions(new Vector3[] { this.transform.position, lineEndPoint });
        }
    }
}
