using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour {
    public Text scoreText;
    private int score;
    // Use this for initialization
    void Start () {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
