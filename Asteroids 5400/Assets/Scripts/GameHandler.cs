using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public Text GameEndingText;
    public Button RestartButton;
    public Button HomeButton;
    public Button PauseButton;
    public Sprite PlayButtonSprite;
    public Sprite PauseButtonSprite;

    public Text ScoreText;
    public int ScoreValue = 0;
    public int pointToLifeCounter = 0;
    int pointPerLife = 10000;

    public Text LivesText;
    public int CurrentLives = 3;
    public int StartingLives = 3;

    bool isGamePaused = false;

    public AudioSource BGAudioSource;
    public AudioSource soundSource;
    public AudioClip bgMusic;
    public AudioClip bangLarge;
    public AudioClip bangMedium;
    public AudioClip bangSmall;
    public AudioClip beat1;
    public AudioClip beat2;
    public AudioClip extraShip;
    public AudioClip fire;
    public AudioClip saucerBig;
    public AudioClip saucerSmall;
    public AudioClip thrust;

    public void PlayThrust()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(thrust);
        }
    }
    public void PlaySaucerSmall()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(saucerSmall);
        } 
    }
    public void PlaySaucerBig()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(saucerBig);
        }  
    }
    public void PlayFire()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(fire);
        } 
    }
    public void PlayExtraShip()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(extraShip);
        } 
    }
    public void PlayBeatTwo()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(beat2);
        }
    }
    public void PlayBeatOne()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(beat1);
        }
    }
    public void PlayBangSmall()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(bangSmall);
        } 
    }
    public void PlayBangMedium()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(bangMedium);
        } 
    }
    public void PlayBangLarge()
    {
        if (musicOnOff != 0)
        {
            soundSource.PlayOneShot(bangLarge);
        } 
    }

    public void PlayBGMusic()
    {
        if (musicOnOff == 0) {
            BGAudioSource.Pause();
            print("pause");
        }
        else {
            BGAudioSource.Play();
            print("play");
        }
    }

    int musicOnOff;

    // Start is called before the first frame update
    void Start()
    {
        GameEndingText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        HomeButton.gameObject.SetActive(false);

        shipSpawnerScript = FindObjectOfType<ShipSpawnner>();

        musicOnOff = PlayerPrefs.GetInt("Music", 1);
        print(PlayerPrefs.GetInt("Music"));

        PlayBGMusic();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + ScoreValue;
        LivesText.text = "Lives: " + CurrentLives;
        EndGame();
        GivePlayerExtraLives();

        if (!largeShipOnScreen)
        {
            StartCoroutine(LargeShipSpawner());
        }

        if (ScoreValue >= 10000)
        {
            if (!smallShipOnScreen)
            {
                StartCoroutine(SmallShipSpawner());
            }
        }

    }

    [HideInInspector]
    public bool largeShipOnScreen = false;

    [HideInInspector]
    public bool smallShipOnScreen = false;

    ShipSpawnner shipSpawnerScript;

    IEnumerator LargeShipSpawner()
    {
        largeShipOnScreen = true;
        float randomTime = Random.Range(3, 8);
        yield return new WaitForSeconds(randomTime);
        shipSpawnerScript.SpawnLargeShip(10);
        
    }

    IEnumerator SmallShipSpawner()
    {
        smallShipOnScreen = true;
        float smallShipTimer = 10;
        yield return new WaitForSeconds(smallShipTimer);
        shipSpawnerScript.SpawnSmallShip(smallShipTimer);
    }

    /* Give player another live if he get 10,000 points in a game */
    public void GivePlayerExtraLives()
    {
        if (pointToLifeCounter >= 10000)
        {
            pointToLifeCounter = pointToLifeCounter - pointPerLife;
            PlayExtraShip();
            CurrentLives += 1;
        }
    }

    /* Handles all in game sounds */
    public void BulletSound()
    {
        //Audio



    }

    /* Check and set the score if it is higher than the highscore */
    private void SettingHighScore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);

        if (ScoreValue > highscore)
        {
            PlayerPrefs.SetInt("Highscore", ScoreValue);
        }
    }

    /* End Game When Lives less  <= 0 */

    private void EndGame()
    {
        if (CurrentLives <= 0)
        {
            SettingHighScore();
            GameEndingText.gameObject.SetActive(true);
            GameEndingText.text = "Game Over, Out Of Lives!";

            RestartButton.gameObject.SetActive(true);
            HomeButton.gameObject.SetActive(true);
            //PauseButton.image.sprite = PlayButtonSprite;
            Time.timeScale = 0;
        }
    }

    /* In Game Buttons */

    public void RestartButtonFunc()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void HomeButtonFunc()
    {
        SceneManager.LoadScene("HomePage");
        Time.timeScale = 1;
    }

    public void PauseButtonFunc()
    {
        
        if (!isGamePaused)
        {
            GameEndingText.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
            HomeButton.gameObject.SetActive(true);
            PauseButton.image.sprite = PlayButtonSprite;
            Time.timeScale = 0;

            isGamePaused = true;
        }else
        {
            GameEndingText.gameObject.SetActive(false);
            RestartButton.gameObject.SetActive(false);
            HomeButton.gameObject.SetActive(false);
            PauseButton.image.sprite = PauseButtonSprite;
            Time.timeScale = 1;

            isGamePaused = false;
        }
    }
}
