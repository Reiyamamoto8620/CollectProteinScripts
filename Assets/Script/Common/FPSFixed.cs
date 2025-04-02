using UnityEngine;

/// <summary>
/// FPS固定クラス
/// </summary>
public class FPSFixed : MonoBehaviour
{
    public const int FPS = 60;                   //ゲーム内フレームレート

    void Awake()
    {
        //フレームを60FPSに固定
        Application.targetFrameRate = FPS;
    }
}
