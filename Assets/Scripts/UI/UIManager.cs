using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pnlEnd;
    public GameObject pnlWin;
    public GameObject pnlPause;
    public Sprite imgPause;
    public Sprite imgContinue;
    public Sprite imgSoundOpen;
    public Sprite imgMute;
    public Button btnSound;
    public Button btnTimeLine;
    public GameObject BloodBar;
    public Text BloodText;
    public Text CoinText;
    public int LevelCount;
    //
    private bool isSoundOpen;
    private bool isTimeRun;
    private void Start()
    {
        changeCoinText();
        TurnSound();
        TurnTime();
    }
    public void PlayerDead()
    {
        pnlEnd.SetActive(true);
    }
    public void PlayerWin()
    {
        pnlWin.SetActive(true);
    }
    public void TurnSound()
    {
        if (isSoundOpen)
        {
            AudioListener.volume = 0;
            btnSound.GetComponent<Image>().sprite = imgSoundOpen;
            isSoundOpen = false;
        }
        else
        {
            AudioListener.volume = 1;
            btnSound.GetComponent<Image>().sprite = imgMute;
            isSoundOpen = true;
        }
    }
    public void TurnTime()
    {
        if (isTimeRun)
        {
            Time.timeScale = 0;
            btnTimeLine.GetComponent<Image>().sprite = imgContinue;
            pnlPause.SetActive(true);
            isTimeRun = false;
        }
        else
        {
            Time.timeScale = 1;
            btnTimeLine.GetComponent<Image>().sprite = imgPause;
            pnlPause.SetActive(false);
            isTimeRun = true;
        }
    }
    public void NextLevel()
    {
        int level = PlayerPrefs.GetInt("level");
        if (level == 0)
        {
            level = 1;
        }
        Debug.Log("level " + level);
        if (level < LevelCount)
        {
            level++;
            SceneManager.LoadScene(level.ToString());
            PlayerPrefs.SetInt("level", level);
        }
        else
        {
            SceneManager.LoadScene("1");
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void changeBloodBar(float Blood)
    {
        //cây máu
        float size = Blood / 100;
        if (Blood < 0)
        {
            size = 0;
            Blood = 0;
        }
        BloodBar.transform.localScale = new Vector3(size, 1, 1);
        BloodText.text = Blood.ToString();
    }
    public void changeCoinText()
    {
        float coin = PlayerPrefs.GetInt("coin");
        CoinText.text = coin.ToString();
    }
}
