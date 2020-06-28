using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button Play;
    public Button NewGame;
    public Button Exit;
    public Button Level1;
    public Button Level2;
    public Text Coin;
    private void Start()
    {
        Time.timeScale = 1;
        Coin.text = PlayerPrefs.GetInt("coin").ToString();
    }
    public void PlayContinue()
    {
        int level = PlayerPrefs.GetInt("level");
        if (level == 0)
        {
            PlayerPrefs.SetInt("level", 1);
            SceneManager.LoadScene(level.ToString());
        }
        else
        {
            SceneManager.LoadScene(level.ToString());
        }
    }
    public void PlayNewGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayContinue();
    }
    public void ExitGame()
    {
        Application.Quit(0);
    }
    public void PlayLevel(int i)
    {
        SceneManager.LoadScene(i.ToString());
    }
}
