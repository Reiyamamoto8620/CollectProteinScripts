using System.Collections.Generic;
using Unity.Services.CloudCode;
using Unity.Services.CloudSave;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ガチャシーンクラス
/// </summary>
public class GachaScene : MonoBehaviour
{
    [SerializeField]
    SaveDataScriptableObject m_SaveData;            //セーブデータ
    
    [SerializeField] GameObject m_GachaStopImage;   //ガチャが引けないときに表示する画像

    const int m_GachaResultActiveCountMax = 2 * FPSFixed.FPS; //ガチャの結果を表示する時間
    const int m_GachaCost = 10;                     //ガチャの消費プロテイン
    int m_gachaResultActiveCount;                   //ガチャ結果を表示する時間カウント
    bool m_isGacha;                                 //ガチャを回したかの判定
    bool m_isGetGachaResult;                        //ガチャリザルトの獲得判定
    bool m_isCanGachaRoll;                          //ガチャが回せるかの判定

    bool m_isNext;                                  //シーンの移行判定

    /// <summary>
    /// メニューUIのセレクト番号
    /// </summary>
    enum MenuUISelectNumber
    {
        Roll,
        Title
    }

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_gachaResultActiveCount = 0;
        m_isGetGachaResult = false;
        m_isGacha = false;
        m_isCanGachaRoll = false;
        m_isNext = false;
    }
    
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue, bool _isEnter, bool _isMenu, bool _isSkin, 
        List<bool> _haveSkin, bool _isFadeOutEnd,bool _isSpace)
    {
        //シーンの移行判定がtrueで、フェードが終了している時、実行
        if (m_isNext && _isFadeOutEnd)
        {
            SceneManager.LoadScene("Title");
        }
        //それ以外の時実行
        else
        {
            //決定ボタンが押されている時実行
            if (_isEnter)
            {
                //メニューUIを制御中の時実行
                if (_isMenu)
                {
                    Menu(_selectValue);
                }
                //スキンUIを制御中の時実行
                if (_isSkin)
                {
                    Skin(_selectValue, _haveSkin);
                }
            }
            //ガチャリザルトの獲得判定がtrueの時実行
            if (m_isGetGachaResult)
            {
                //ガチャリザルトの表示時間カウントが表示時間を越えている時実行
                if (m_gachaResultActiveCount > m_GachaResultActiveCountMax)
                {
                    //ガチャリザルトの表示判定をfalse
                    m_isGetGachaResult = false;
                    //ガチャを回したかの判定をfalse
                    m_isGacha = false;
                    //ガチャリザルトの表示時間カウントをリセット
                    m_gachaResultActiveCount = 0;
                }
                //ガチャリザルトの表示時間をカウント
                m_gachaResultActiveCount++;
            }

            //所持プロテインの数がガチャコスト以上で、ガチャが回したかの判定がfalseの時実行
            if (m_SaveData.m_data.protein >= m_GachaCost && !m_isGacha)
            {
                //ガチャが回せるかの判定をtrue
                m_isCanGachaRoll = true;
            }
            //それ以外の時実行
            else
            {
                //ガチャが回せるかの判定をfalse
                m_isCanGachaRoll = false;
            }
            //ガチャが回せない時は表示せず、回せるときは表示する。
            m_GachaStopImage.SetActive(!m_isCanGachaRoll);

            //スペースキーが押された時実行
            if (_isSpace)
            {
                //ガチャのデータを削除
                ClearGachaData();
            }
            
        }
    }
    /// <summary>
    /// ガチャが回された時の処理
    /// </summary>
    async void OnGacha()
    {
        //サーバーにリクエストを送り、結果を受け取る
        var responce = await CloudCodeService.Instance.CallEndpointAsync("Gacha");
        //結果をJSONから変換して、セーブデータに保存する
        m_SaveData.m_data = JsonUtility.FromJson<Data>(responce);
        //ガチャリザルトの表示判定をtrue
        m_isGetGachaResult = true;
    }

    /// <summary>
    /// メニューUIの結果を処理
    /// </summary>
    void Menu(int _selectValue)
    {
        //セレクト番号がRollの時実行
        if (_selectValue == (int)MenuUISelectNumber.Roll)
        {
            //ガチャが回せる状態の時実行
            if (m_isCanGachaRoll)
            {
                //ガチャを実行
                OnGacha();
                //ガチャが回されたかの判定をtrue
                m_isGacha = true;
                //ログを表示
                Debug.Log("ガチャ回した");
            }
        }
        //セレクト番号がTitleの時実行
        if (_selectValue == (int)MenuUISelectNumber.Title)
        {
            //シーンの移行判定をtrue
            m_isNext = true;
        }
    }
    /// <summary>
    /// スキンUIの結果を処理
    /// </summary>
    void Skin(int _selectValue, List<bool> _haveSkin)
    {
        //スキンリストの数だけ回す
        for (int i = 0; i < _haveSkin.Count; i++)
        {
            //セレクト番号のスキンを所持している時に実行
            if (_selectValue == i && _haveSkin[i])
            {
                //現在のスキンをセレクト番号のスキンに変更
                m_SaveData.m_data.nowSkin = _selectValue;
            }
        }
    }
    /// <summary>
    /// ガチャリザルトの表示判定を取得
    /// </summary>
    public bool GetIsGetGachaResult()
    {
        return m_isGetGachaResult;
    }
    /// <summary>
    /// シーンの移行判定を取得
    /// </summary>
    public bool GetIsNext()
    {
        return m_isNext;
    }
    /// <summary>
    /// ガチャのスキンデータを削除
    /// </summary>
    async void ClearGachaData()
    {
        //所持しているスキンをNormalのみにして
        m_SaveData.m_data.gold = false;
        m_SaveData.m_data.silver = false;
        m_SaveData.m_data.black = false;
        m_SaveData.m_data.red = false;
        m_SaveData.m_data.blue = false;
        m_SaveData.m_data.green = false;
        m_SaveData.m_data.yellow = false;
        m_SaveData.m_data.purple = false;
        m_SaveData.m_data.orange = false;

        //現在のスキンをNormalにする
        m_SaveData.m_data.nowSkin = 0;
        //セーブデータをJSONに変換
        string jsonstr = JsonUtility.ToJson(m_SaveData.m_data);
        //キーとセーブデータを紐づける
        var data = new Dictionary<string, object> { { "Data", jsonstr } };
        //データをサーバーに送信
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }
}