using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// シンプルな入力管理クラス
/// 
/// Input System を使用して、
/// キーボード入力を取得する。
/// 
/// 他のクラスからは
/// SimpleInput.Move などを通して
/// 入力状態へアクセスする。
/// </summary>
public class SimpleInput : MonoBehaviour
{
    /// <summary>
    /// 移動入力
    /// 
    /// X：左右
    /// Y：上下
    /// </summary>
    public static Vector2 Move { get; private set; }

    /// <summary>
    /// ショット入力
    /// 
    /// Spaceキーが押された瞬間に true になる
    /// </summary>
    public static bool FirePressed { get; private set; }

    /// <summary>
    /// リスタート入力
    /// 
    /// Rキーが押された瞬間に true になる
    /// </summary>
    public static bool RestartPressed { get; private set; }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    void Update()
    {
        // 毎フレーム初期化
        FirePressed = false;
        RestartPressed = false;

        // 現在のキーボード情報を取得
        Keyboard keyboard = Keyboard.current;

        // キーボード未接続時
        if (keyboard == null)
        {
            Move = Vector2.zero;
            return;
        }

        // 移動ベクトル初期化
        Vector2 move = Vector2.zero;

        // =========================
        // 上入力
        // Wキー または ↑キー
        // =========================
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            move.y += 1f;
        }

        // =========================
        // 下入力
        // Sキー または ↓キー
        // =========================
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            move.y -= 1f;
        }

        // =========================
        // 左入力
        // Aキー または ←キー
        // =========================
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            move.x -= 1f;
        }

        // =========================
        // 右入力
        // Dキー または →キー
        // =========================
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            move.x += 1f;
        }

        // 斜め移動時の速度が速くならないよう正規化
        Move = move.normalized;

        // =========================
        // ショット入力
        // Spaceキーを押した瞬間
        // =========================
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            FirePressed = true;
        }

        // =========================
        // リスタート入力
        // Rキーを押した瞬間
        // =========================
        if (keyboard.rKey.wasPressedThisFrame)
        {
            RestartPressed = true;
        }
    }
}