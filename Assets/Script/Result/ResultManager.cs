using UnityEngine;

/// <summary>
/// リザルトマネージャークラス
/// </summary>
public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject m_ResultScene;              //リザルトシーン制御
    [SerializeField] GameObject m_Score;                    //スコア制御
    [SerializeField] GameObject m_UIController;             //UI制御
    [SerializeField] GameObject m_UIInput;                  //UI入力制御
    [SerializeField] GameObject m_UIInputToController;      //UIの入力をコントローラーに変換
    [SerializeField] GameObject m_Fade;                     //フェード制御
    [SerializeField] GameObject m_SEController;             //SE制御

    ResultScene m_resultScene;                              //リザルトシーンクラス
    Score m_score;                                          //スコア制御クラス
    UIController m_uiController;                            //UI制御クラス
    UIInput m_uiInput;                                      //UI入力制御クラス
    UIInputToController m_uiInputToController;              //UIの入力をコントローラーに変換するクラス
    Fade m_fade;                                            //フェード制御クラス
    SEController m_seController;                            //SE制御クラス

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_resultScene = m_ResultScene.GetComponent<ResultScene>();
        m_score = m_Score.GetComponent<Score>();
        m_uiController = m_UIController.GetComponent<UIController>();
        m_uiInput = m_UIInput.GetComponent<UIInput>();
        m_uiInputToController = m_UIInputToController.GetComponent<UIInputToController>();
        m_fade = m_Fade.GetComponent<Fade>();
        m_seController = m_SEController.GetComponent<SEController>();
    }
    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //UI入力をコントローラーに変換する
        m_uiInputToController.ManagedUpdate(m_uiInput.GetStickInput());
        //リザルトシーンを更新
        m_resultScene.ManagedUpdate(m_uiInputToController.GetSelectValue(),
            m_uiInput.GetIsEnter(),m_fade.GetIsFadeOutEnd());
        //スコアを更新
        m_score.ManagedUpdate();
        //U制御を更新
        m_uiController.ManagedUpdate(m_uiInputToController.GetSelectValue());
        //フェード制御を更新
        m_fade.ManagedUpdate(false, m_resultScene.GetIsNext());
        //UI入力をリセット
        m_uiInput.SetIsEnter(false);
        m_uiInput.SetStickInput(false);
        //SE制御を更新
        m_seController.ManagedUpdate(m_uiInputToController.GetSelectValue(), m_uiInput.GetIsEnter(),false);
    }
}
