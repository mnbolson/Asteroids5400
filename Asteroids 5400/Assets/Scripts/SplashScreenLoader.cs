using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
SplahsScreenLoader is a custom splash screen that was created for 54th street
studios instead of using Unitys built in splash screen
*/
public class SplashScreenLoader : MonoBehaviour
{

    float delay = 1f;
    public string mainMenu = "HomePage";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainMenuScene());
    }

    //Logic to open the HomePageScene when the "delay" time has passed...
    IEnumerator LoadMainMenuScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(mainMenu);
    }
}
