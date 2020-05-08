using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text scoreText;

	private void Start(){
		scoreText.text = PlayerPrefs.GetInt ("StackScore").ToString();
	}

	public void ToGame(){
		SceneManager.LoadScene ("StackGame");
	}
}
