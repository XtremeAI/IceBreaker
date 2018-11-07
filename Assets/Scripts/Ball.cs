using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Consts 

	// Serialized
	[SerializeField] Paddle _gamePaddle;
	[SerializeField] Vector2 _ballLaunchVelocityVector;

	bool _ballLaunched = false;
	Vector2 _vectorOffsetBallPaddle;

	// Use this for initialization
	void Start () {
		_vectorOffsetBallPaddle = transform.position - _gamePaddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			_ballLaunched = true;
			GetComponent<Rigidbody2D>().velocity = _ballLaunchVelocityVector;
		}

		if (!_ballLaunched) {
			Vector2 paddlePosition = new Vector2(
				_gamePaddle.transform.position.x, 
				_gamePaddle.transform.position.y
			);
			transform.position = paddlePosition + _vectorOffsetBallPaddle;
		}
	}
}
