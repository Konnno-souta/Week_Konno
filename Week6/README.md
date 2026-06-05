### Week1

## Starter(完成)

### ゲーム概要
プレイヤーを操作し、床が落ちる前に他の床に飛び乗って回避する3Dアクションゲームです。

### 基本ルール
・WASD/移動
・Space/ジャンプ
・床外に落下するとゲームオーバー
・Result画面からRetry可能

### 仕様環境
・Unity6
・新 InputSystem

### シーン構成

# Scene 内容
Init　初期化
Title タイトル画面
Game ゲーム本編
GameOver ゲームオーバー画面

## 主なスクリプト

 #Script            #内容
GameManager.cs     シーン遷移管理
StartButton.cs     スタートボタン
Result.cs          Result画面UI
CameraFollow.cs    カメラ管理
GameOverManager.cs ゲームオーバー画面管理  
PlayerJump.cs      プレイヤー管理
GroundSpawner.cs   ステージのスポナー管理(未実装)

### プレイヤー仕様
## 移動
Rigidbody に AddForce を使用して移動。
rb.AddForce(moveDirection * moveForce, ForceMode.Force);

## ジャンプ
接地判定後にImpulseでジャンプ。
rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

## 接地判定
Physics.CheckSphere()
を利用。
