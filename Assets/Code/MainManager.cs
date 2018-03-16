using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

	public void CardCollectionButton()
    {
        //SceneManager.LoadScene();
    }
    public void PlayGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene(2);
    }
}
