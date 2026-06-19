using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        resultText.text =
            PlayerPrefs.GetString("Result");

        scoreText.text =
            "SCORE : " +
            PlayerPrefs.GetInt("ResultScore");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}