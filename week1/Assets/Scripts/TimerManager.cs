using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timeLimit = 60f;

    public TMP_Text timerText;

    void Update()
    {
        timeLimit -= Time.deltaTime;

        timerText.text =
            Mathf.Ceil(timeLimit).ToString();

        if (timeLimit <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}