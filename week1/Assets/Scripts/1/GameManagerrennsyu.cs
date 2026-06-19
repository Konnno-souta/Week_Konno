//using UnityEngine;
//using UnityEngine.SceneManagement;

//public enum State
//{
//    Init,
//    Title,
//    Game,
//    Result
//}

///// <summary>
///// ゲームの状態を管理するクラス
///// </summary>
//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;
//    public State currentState = State.Init;
//    public bool stateEnd = false;
//    public int gameMode = 0;

//    public static object Instance { get; internal set; }

//    private void Awake()
//    {
//        //シングルトン化
//        if(instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }
//    }
//    /// <summary>
//    /// ステート管理
//    /// </summary>
//    private void Update()
//    {
//        switch (currentState)
//        {
//            case State.Init:
//                if (stateEnd)
//                {
//                    currentState = State.Title;
//                    SceneManager.LoadScene("Title");
//                    stateEnd = false;
//                }
//                break;
//            case State.Title:
//                if (stateEnd)
//                {
//                    currentState = State.Game;
//                    switch (gameMode)
//                    {
//                        case 0:
//                            SceneManager.LoadScene("StarterGame");
//                            break;
//                        case 1:
//                            SceneManager.LoadScene("StanderdGame");
//                            break;
//                        case 2:
//                            SceneManager.LoadScene("ChallengeGame");
//                            break;
//                        default:
//                            SceneManager.LoadScene("StarterGame");
//                            break;
//                    }
                    
//                    stateEnd = false;
//                }
//                break;
//            case State.Game:
//                if (stateEnd)
//                {
//                    currentState = State.Result;
//                    SceneManager.LoadScene("Result");
//                    stateEnd = false;
//                }
//                break;
//            case State.Result:
//                if (stateEnd)
//                {
//                    currentState = State.Title;
//                    SceneManager.LoadScene("Title");
//                    stateEnd = false;
//                }
//                break;
//            default:
//                break;
//        }
//    }
//}
