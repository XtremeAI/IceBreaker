using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	[Range(0.5f,10f)][SerializeField] float _gameSpeed = 1f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = _gameSpeed;
	}
}
