using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	[Range(0.5f,10f)][SerializeField] float _gameSpeed = 1f;
	[SerializeField] int _scoreTotal = 0;
	[SerializeField] int _scorePerBlock = 5;

	[SerializeField] Text _scoreText;

	private void Start() {
		_scoreText.text = _scoreTotal.ToString();
	}	
	// Update is called once per frame
	void Update () {
		Time.timeScale = _gameSpeed;
	}

	public void ScoreBlock(){
		_scoreTotal += _scorePerBlock;
		_scoreText.text = _scoreTotal.ToString();
	}
}
