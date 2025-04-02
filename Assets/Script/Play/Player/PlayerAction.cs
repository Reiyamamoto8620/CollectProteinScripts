using UnityEngine;

/// <summary>
/// プレイヤー動き管理
/// </summary>
public class PlayerAction : MonoBehaviour
{
    [SerializeField] GameObject m_Barbell;        //手に持たせるバーベルのモデル

    const float m_PlayerAngleMax = 360.0f;        //Playerが向く角度の最大   
    [SerializeField] float m_MoveSpeed;           //Playerの歩く速度
    [SerializeField] float m_RunSpeed;            //Playerの走る速度

    Rigidbody m_rigidbody;                      //RigitBody

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(Vector2 _stickInputValue, PlayerState.State _state)
    {
        //プレイヤーがSquat状態の時、バーベルを有効にする。
        m_Barbell.SetActive(_state == PlayerState.State.Squat);
        //Playerの状態がTired、Squat、Drinkの時に処理に入り、下の処理を飛ばす
        if (_state == PlayerState.State.Tired ||
            _state == PlayerState.State.Squat) return;


        //入力かからプレイヤーを動かす
        OnMove(_stickInputValue);

        //プレイヤーの移動速度を入れる変数
        var speed = _state switch
        {
            //プレイヤーの状態がWalkの時、MoveSpeedを入れる
            PlayerState.State.Walk => m_MoveSpeed,
            //プレイヤーの状態がRunの時、RunSpeedを入れる
            PlayerState.State.Run => m_RunSpeed,
            //プレイヤーの状態が上の2つ以外の場合0を入れる。
            _ => 0f
        };

        //移動方向の力を与える
        m_rigidbody.position += (new Vector3(
            _stickInputValue.x,
            0,
            _stickInputValue.y
        ) * speed);
    }

    /// <summary>
    /// スティック入力を参照してPlayerを動かす
    /// </summary>
    void OnMove(Vector2 _stickInputValue)
    {
        //モデルの向きをスティック入力と同じ方向に向ける
        float degree = 0;
        if (_stickInputValue.x != 0 || _stickInputValue.y != 0)
        {
            degree = Mathf.Atan2(_stickInputValue.x, _stickInputValue.y) * Mathf.Rad2Deg;

            if (degree < 0)
            {
                degree += m_PlayerAngleMax;
            }
            transform.eulerAngles = new Vector3(0, degree, 0);
        }
    }
}