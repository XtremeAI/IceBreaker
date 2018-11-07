using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	float _viewSizeH; 

	// Use this for initialization
	void Start () {
		_viewSizeH = Camera.main.orthographicSize / Screen.height * Screen.width * 2;
		Debug.Log("Camera.main.orthographicSize: " + Camera.main.orthographicSize);
		Debug.Log("Screen.height" + Screen.height);
		Debug.Log("Screen.width" + Screen.width);
		Debug.Log("_viewSizeH" + _viewSizeH);
	}
	
	// Update is called once per frame
	void Update () {

		// applying mouse x position to the ball
		float mouseX = (Input.mousePosition.x / Screen.width - 0.5f) * _viewSizeH;
		float mouseXLimit = _viewSizeH / 2 - 1;
		if (Mathf.Abs(mouseX) > mouseXLimit) {
			mouseX = mouseXLimit * Mathf.Sign(mouseX);
		}
		Vector2 newPaddlePos = new Vector2(mouseX, transform.position.y);
		transform.position = newPaddlePos;
	}
}
