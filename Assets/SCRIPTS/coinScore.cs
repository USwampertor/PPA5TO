using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScore : MonoBehaviour {
    public Text scoreText;
    private int score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = "Agarre este alv";
	}
}
