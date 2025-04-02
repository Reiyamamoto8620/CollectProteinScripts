using UnityEngine;

/// <summary>
/// ガチャマネージャー
/// </summary>
public class GachaManager : MonoBehaviour
{
    [SerializeField] GameObject m_GachaScene;           //ガチャシーンの制御
    [SerializeField] GameObject m_HaveProtein;          //所持プロテインの表示制御
    [SerializeField] GameObject m_SkinUIController;     //スキンUI用コントローラー
    [SerializeField] GameObject m_MenuUIController;     //メニューUI用コントローラー
    [SerializeField] GameObject m_UIInput;              //UIの入力制御
    [SerializeField] GameObject m_GachaUI;              //ガチャUIの制御
    [SerializeField] GameObject m_HaveSkinVisualizer;   //所持スキンのUI表示制御
    [SerializeField] GameObject m_GachaResult;          //ガチャリザルトの表示制御
    [SerializeField] GameObject m_Fade;                 //フェードの制御
    [SerializeField] GameObject m_SEController;         //SEの制御

    GachaScene m_gachaScene;                            //ガチャシーンの制御クラス
    HaveProtein m_haveProtein;                          //所持プロテインの表示制御クラス
    UIController m_skinUIController;                    //スキンUI用コントローラークラス
    UIController m_menuUIController;                    //メニューUI用コントローラークラス
    UIInput m_uiInput;                                  //UIの入力制御クラス
    GachaUI m_gachaUI;                                  //ガチャUIの制御クラス
    HaveSkinVisualizer m_haveSkinVisualizer;            //所持スキンのUI制御クラス
    GachaResult m_gachaResult;                          //ガチャリザルトの表示制御クラス
    Fade m_fade;                                        //フェードの制御クラス
    SEController m_seController;                        //SEの制御クラス

    bool m_isFadeIn;                                    //フェードインの開始判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_gachaScene = m_GachaScene.GetComponent<GachaScene>();
        m_haveProtein = m_HaveProtein.GetComponent<HaveProtein>();
        m_skinUIController = m_SkinUIController.GetComponent<UIController>();
        m_menuUIController = m_MenuUIController.GetComponent<UIController>();
        m_uiInput = m_UIInput.GetComponent<UIInput>();
        m_gachaUI = m_GachaUI.GetComponent<GachaUI>();
        m_haveSkinVisualizer = m_HaveSkinVisualizer.GetComponent<HaveSkinVisualizer>();
        m_gachaResult = m_GachaResult.GetComponent<GachaResult>();
        m_fade = m_Fade.GetComponent<Fade>();
        m_seController = m_SEController.GetComponent<SEController>();
        m_isFadeIn = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //所持スキンのUIの更新
        m_haveSkinVisualizer.ManagedUpdate();
        //ガチャUIの更新
        m_gachaUI.ManagedUpdate(m_uiInput.GetStickInput());
        //ガチャシーンの更新
        m_gachaScene.ManagedUpdate(m_gachaUI.GetSelectValue(), m_uiInput.GetIsEnter(),
            m_gachaUI.GetIsMenu(),m_gachaUI.GetIsSkin(),m_haveSkinVisualizer.GetHaveSkin(),
            m_fade.GetIsFadeOutEnd(),m_uiInput.GetIsSpace());
        //所持プロテインの更新
        m_haveProtein.ManagedUpdate();
        //メニューUIの更新
        m_menuUIController.ManagedUpdate(m_gachaUI.GetSelectValue(),m_gachaUI.GetIsMenu());
        //スキンUIの更新
        m_skinUIController.ManagedUpdate(m_gachaUI.GetSelectValue(), m_gachaUI.GetIsSkin());
        //ガチャリザルトの更新
        m_gachaResult.ManagedUpdate(m_gachaScene.GetIsGetGachaResult());
        //フェードの更新
        m_fade.ManagedUpdate(m_isFadeIn,m_gachaScene.GetIsNext());
        //SEの更新
        m_seController.ManagedUpdate(m_gachaUI.GetSelectValue(),
            m_uiInput.GetIsEnter(),m_gachaUI.GetIsSkin());

        //UIの入力を初期化
        m_uiInput.SetIsEnter(false);
        m_uiInput.SetStickInput(false);
        m_uiInput.SetIsSpace(false);
    }
}