using UnityEngine;

/// <summary>
/// ログインマネージャー
/// </summary>
public class LoginManager : MonoBehaviour
{
    [SerializeField] GameObject m_LoginScene;           //ログインシーン制御
    [SerializeField] GameObject m_InputText;            //テキスト入力制御
    [SerializeField] GameObject m_UIController;         //UIコントローラー
    [SerializeField] GameObject m_UIInput;              //UI入力制御
    [SerializeField] GameObject m_UIInputToController;  //UI入力データをUIコントローラー用データに変換
    [SerializeField] GameObject m_Fade;                 //フェード制御
    [SerializeField] GameObject m_SEController;         //SE制御

    LoginScene m_login;                                 //ログインシーン制御クラス
    InputText m_inputText;                              //テキスト入力制御クラス
    UIController m_uiController;                        //UIコントローラークラス
    UIInput m_uiInput;                                  //UI入力制御クラス
    UIInputToController m_uiInputToController;          //入力データをUIコントローラー用に変換するクラス
    Fade m_fade;                                        //フェード制御クラス
    SEController m_seController;                        //SE制御クラス

    bool m_isFadeIn;                                    //フェードイン開始判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_login = m_LoginScene.GetComponent<LoginScene>();
        m_inputText = m_InputText.GetComponent<InputText>();
        m_uiController = m_UIController.GetComponent<UIController>();
        m_uiInput = m_UIInput.GetComponent<UIInput>();
        m_uiInputToController = m_UIInputToController.GetComponent<UIInputToController>();
        m_fade = m_Fade.GetComponent<Fade>();
        m_seController = m_SEController.GetComponent<SEController>();
        m_isFadeIn = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //入力データをコントローラー用に変換
        m_uiInputToController.ManagedUpdate(m_uiInput.GetStickInput());
        //ログインシーンを更新
        m_login.ManagedUpdate(m_uiInputToController.GetSelectValue(),
            m_uiInput.GetIsEnter(), m_fade.GetIsFadeOutEnd());
        //テキスト入力の更新
        m_inputText.ManagedUpdate(m_login.GetIsInputName());
        //UIコントローラーの更新
        m_uiController.ManagedUpdate(m_uiInputToController.GetSelectValue());
        //名前の入力判定をセット
        m_uiInput.SetIsInputName(m_login.GetIsInputName());
        //フェードの更新
        m_fade.ManagedUpdate(m_isFadeIn, m_login.GetIsNext());
        //SE制御の更新
        m_seController.ManagedUpdate(m_uiInputToController.GetSelectValue(),
            m_uiInput.GetIsEnter(), false);
        //UIの入力を初期化
        m_uiInput.SetIsEnter(false);
        m_uiInput.SetStickInput(false);
    }
}