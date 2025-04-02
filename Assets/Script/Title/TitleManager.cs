using UnityEngine;

/// <summary>
/// タイトルマネージャークラス
/// </summary>
public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_TitleScene;               //タイトルシーン制御
    [SerializeField] GameObject m_UIController;             //UI制御
    [SerializeField] GameObject m_UIInput;                  //UI入力制御
    [SerializeField] GameObject m_UIInputToController;      //UI入力をコントローラーを変換する
    [SerializeField] GameObject m_HaveProtein;              //所持プロテイン制御
    [SerializeField] GameObject m_Fade;                     //フェード制御
    [SerializeField] GameObject m_SEController;             //SE制御

    TitleScene m_titleScene;                                //タイトルシーン制御クラス
    UIController m_uiController;                            //UI制御クラス
    UIInput m_uiInput;                                      //UI入力制御クラス
    UIInputToController m_uiInputToController;              //UI入力をコントローラに変換するクラス
    HaveProtein m_haveProtein;                              //所持プロテイン制御クラス
    Fade m_fade;                                            //フェード制御クラス
    SEController m_seController;                            //SE制御クラス

    bool m_isFadeIn;                                        //フェードイン判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_titleScene = m_TitleScene.GetComponent<TitleScene>();
        m_uiController = m_UIController.GetComponent<UIController>();
        m_uiInput = m_UIInput.GetComponent<UIInput>();
        m_uiInputToController = m_UIInputToController.GetComponent<UIInputToController>();
        m_haveProtein = m_HaveProtein.GetComponent<HaveProtein>();
        m_fade = m_Fade.GetComponent<Fade>();
        m_seController = m_SEController.GetComponent<SEController>();
        m_isFadeIn = true;
    }
    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //UI入力をコントローラーに変換
        m_uiInputToController.ManagedUpdate(m_uiInput.GetStickInput());
        //タイトルシーンを更新
        m_titleScene.ManagedUpdate(m_uiInputToController.GetSelectValue(),
            m_uiInput.GetIsEnter(),m_fade.GetIsFadeOutEnd());
        //UI制御を更新
        m_uiController.ManagedUpdate(m_uiInputToController.GetSelectValue());
        //所持プロテイン制御を更新
        m_haveProtein.ManagedUpdate();
        //フェード制御を更新
        m_fade.ManagedUpdate(m_isFadeIn, m_titleScene.GetIsNext());
        //SE制御を更新
        m_seController.ManagedUpdate(m_uiInputToController.GetSelectValue(), m_uiInput.GetIsEnter(),false);
        //UI入力を初期化
        m_uiInput.SetIsEnter(false);
        m_uiInput.SetStickInput(false);
    }
}
