using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	[SerializeField] Text _finalScoreTxtField;

	GameState _gameState;

	// Use this for initialization
	void Start () {
		_gameState = GameState.Instance;
		_finalScoreTxtField.text = _gameState.GetTotalScore();
	}
}
