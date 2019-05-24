using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public string mainmenu;


	public void mainmenufunction()
	{
		SceneManager.LoadScene(mainmenu);
	}



}
