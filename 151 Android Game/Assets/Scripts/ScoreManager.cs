using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //UI Text stuff
    public Text scoreText;
    string start = "Score: ";

    //Actual score number
    private float score = 0;
    private int scoreRound = 0;

	void Start ()
    {
        scoreText.text = start + 0;

	}
	
	void Update ()
    {
        score += Time.deltaTime * 50;
        scoreRound = Mathf.RoundToInt(score);
        scoreText.text = start + scoreRound;

    }

}
