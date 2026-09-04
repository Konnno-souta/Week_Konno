using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // メイン画面へ移動する関数

    public void OnClickStartButton()
    {
        StartCoroutine(LoadSceneWithFade());
    }

    private System.Collections.IEnumerator LoadSceneWithFade()
    {
        // フェード処理（省略）
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainScene");
    }
}