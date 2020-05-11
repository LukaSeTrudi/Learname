using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManagaer : MonoBehaviour
{
    public Text _score;
    public Text _highScore;

    public void SetScore(int score, int highScore){
        _score.text = "Score: " + score.ToString();
        _highScore.text = "Highscore: " + highScore;
    }
}
