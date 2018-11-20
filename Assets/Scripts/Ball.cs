using System;
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
	AudioSource ballKnockSound;
	Rigidbody2D _ballRigidBodyComponent;
  private float randomFactor = .1f;

	Vector2 _lastVelocityVector;

  // Use this for initialization
  void Start () {
		_vectorOffsetBallPaddle = transform.position - _gamePaddle.transform.position;
		ballKnockSound = GetComponent<AudioSource>();
		_ballRigidBodyComponent = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0) && !_ballLaunched) {
			_ballLaunched = true;
			_ballRigidBodyComponent.velocity = _ballLaunchVelocityVector;			
			_lastVelocityVector = _ballLaunchVelocityVector;
			Debug.Log("Fired!");
		}

		if (!_ballLaunched) {
			Vector2 paddlePosition = new Vector2(
				_gamePaddle.transform.position.x, 
				_gamePaddle.transform.position.y
			);
			transform.position = paddlePosition + _vectorOffsetBallPaddle;
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {

		if (_ballLaunched) {
			ballKnockSound.Play();
		}

		// if (other.gameObject.name == "Paddle") {
		// 	Debug.Log(other.contacts[0].point);

		// 	PolygonCollider2D paddleCollider = (PolygonCollider2D)other.collider;
			
		// 	Vector2[] colPoints = paddleCollider.points;

		// 	foreach (Vector2 point in colPoints) {
		// 		Debug.Log(other.transform.TransformPoint(point));
		// 	}
		// }
	}

	private void OnCollisionExit2D(Collision2D other) {
		PeventInfiniteLoops();
	}

  private void PeventInfiniteLoops()
  {
		Debug.Log("Last Velocity:" + _lastVelocityVector);
		Vector2 currentVelVec = _ballRigidBodyComponent.velocity; 
		Debug.Log("Current Velocity:" + currentVelVec);
    Vector2 resultantVector = currentVelVec + _lastVelocityVector;
		if (resultantVector == Vector2.zero) {
			bool isXhigherThanY = Math.Abs(currentVelVec.x) > Math.Abs(currentVelVec.y) ? true : false;
			float deviationValue = isXhigherThanY ? currentVelVec.x * 0.05f : currentVelVec.y * 0.05f;
			Vector2 deviationVelVec = isXhigherThanY 
				? new Vector2(-deviationValue, +deviationValue) 
				: new Vector2(+deviationValue, -deviationValue);
			_ballRigidBodyComponent.velocity += deviationVelVec;
		}
		Debug.Log("New Velocity:" + _ballRigidBodyComponent.velocity);
		_lastVelocityVector = _ballRigidBodyComponent.velocity;
  }
}
