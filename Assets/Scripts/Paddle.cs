using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	float _viewSizeH; 

	GameState _gameState;
	Ball _ball;

		// Use this for initialization
	void Start () {
		_viewSizeH = Camera.main.orthographicSize / Screen.height * Screen.width * 2;
		Debug.Log("Camera.main.orthographicSize: " + Camera.main.orthographicSize);
		Debug.Log("Screen.height" + Screen.height);
		Debug.Log("Screen.width" + Screen.width);
		Debug.Log("_viewSizeH" + _viewSizeH);
		_gameState = GameState.Instance;
		_ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

		// applying mouse x position to the ball
		Vector2 newPaddlePos = new Vector2(GetXPos(), transform.position.y);
		transform.position = newPaddlePos;
	}

	private float GetXPos(){
		if (_gameState.IsAutoPlayEnabled()) {
			return _ball.transform.position.x;
		}
		else {
      float mouseX = (Input.mousePosition.x / Screen.width - 0.5f) * _viewSizeH;
      float mouseXLimit = _viewSizeH / 2 - 1;
      if (Mathf.Abs(mouseX) > mouseXLimit)
      {
        mouseX = mouseXLimit * Mathf.Sign(mouseX);
      }
			return mouseX;
    }
	}
}
