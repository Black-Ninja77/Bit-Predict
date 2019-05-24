using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public string mainGameScene1;
    public string mainGameScene2;
    public string mainGameScene3;


    public void startgame()
	{
		SceneManager.LoadScene(mainGameScene1);
	}

    public void startgame2()
    {
        SceneManager.LoadScene(mainGameScene2);
    }

    public void startgame3()
    {
        SceneManager.LoadScene(mainGameScene3);
    }

    public void quitgame()
	{
		Application.Quit();
	}



}
