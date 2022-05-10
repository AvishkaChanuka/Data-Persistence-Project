using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text hiScore;
    public InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
        ShowScore();
    }

    void ShowScore()
    {
        hiScore.text = "Best Score: " + DataManager.Instance.BestUserName + " : " + DataManager.Instance.Score; 
    }

    public void GameStart()
    {
        DataManager.Instance.UserName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    { 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
