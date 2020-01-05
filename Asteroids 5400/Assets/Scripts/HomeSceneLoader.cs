using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    HomeSceneLoader deals with all buttons and the ability to load the game scene. 

*/
public class HomeSceneLoader : MonoBehaviour
{
    //Music Button Logic...
    public Button musicBtn;
    public Sprite musicOn;
    public Sprite musicOff;
    private bool musicBtnOn = true;
    public int musicOnOff;

    public Text highScoreText;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Ensure that the game is not paused. 
        Time.timeScale = 1;
        GetHighScore();

        musicOnOff = PlayerPrefs.GetInt("Music", 1);
        MusicBtn();
    }

    public void MusicBtn()
    {
        if (musicOnOff == 0)
        {
            musicBtn.image.sprite = musicOff;
        }
        else
        {
            musicBtn.image.sprite = musicOn;
        }
    }

    /* Obtain score via playprefabs */
    public void GetHighScore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highScoreText.text = "" + highscore;
    }

    /*  Button Controls */

    //Event Trigger that loads the game scene...
    public void TouchToStart()
    {
        SceneManager.LoadScene("GameScene");
        print("Screen was touched");
    }

    //Button logic that open the app store page for game reviews. 
    public void RateUsBtn()
    {
        print("Rate Our Game Button");
    }

    //Button logic that open the 54thstreet webpage.
    public void MoreGamesBtn()
    {
        Application.OpenURL("https://54thstreetstudios.com/");
    }

    //Button logic that opens the 54thstreet instagram.
    public void InstagramBtn()
    {
        Application.OpenURL("instagram://user?username=54thstreetstudio");
    }

    //Button logic that controls the music logic for the game. 
    public void MusicOnOffControl()
    {
        if (musicOnOff == 0)
        {
            musicBtn.image.sprite = musicOn;
            musicOnOff = 1;
            PlayerPrefs.SetInt("Music", musicOnOff);
            print(PlayerPrefs.GetInt("Music"));
        }else if (musicOnOff == 1)
        {
            musicBtn.image.sprite = musicOff;
            musicOnOff = 0;
            PlayerPrefs.SetInt("Music", musicOnOff);
            print(PlayerPrefs.GetInt("Music"));
        }
    }

}
