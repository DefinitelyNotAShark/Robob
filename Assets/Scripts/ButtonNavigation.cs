using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNavigation : MonoBehaviour {

    [SerializeField]
    private AudioSource buttonClick;

    [SerializeField]
    private AudioSource MenuMusic;


    public void NewGameButton()
    {
        MenuMusic.Stop();
        buttonClick.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        MenuMusic.Stop();
        buttonClick.Play();
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void PlayAgain()
    {
        buttonClick.Play();
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        buttonClick.Play();
        SceneManager.LoadScene(4);
    }
}
