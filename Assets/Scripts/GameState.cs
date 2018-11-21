using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	private static GameState _instance;

	public static GameState Instance {get { return _instance;} }

	private void Awake() {
		if (_instance != this && _instance != null) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}
  [Range(0.5f,10f)][SerializeField] float _gameSpeed;
	[SerializeField] int _scoreTotal;
	[SerializeField] int _scorePerBlock;

	[SerializeField] Text _scoreText;

  [SerializeField] bool _isAutoPlayEnabled;

  private void Start() {
		_scoreText.text = GetTotalScore();
	}	
	// Update is called once per frame
	void Update () {
		Time.timeScale = _gameSpeed;
	}

	public void ScoreBlock(){
		_scoreTotal += _scorePerBlock;
		_scoreText.text = GetTotalScore();
	}

	public bool IsAutoPlayEnabled() { 
		return _isAutoPlayEnabled;
	}

  public string GetTotalScore()
  {
    return _scoreTotal.ToString();
  }
}
