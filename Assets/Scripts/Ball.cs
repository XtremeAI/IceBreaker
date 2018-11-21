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

		_lastVelocityVector = _ballRigidBodyComponent.velocity;
	}

	private void OnCollisionEnter2D(Collision2D other) {

		if (_ballLaunched) {
			ballKnockSound.Play();
		}

		if (other.gameObject.name == "Paddle") {

			Vector2 contactPoint = other.GetContact(0).point;

			// Debug.Log("Contact point:     " + contactPoint);

			Vector2 colliderPosition = other.transform.TransformPoint(other.collider.offset);
			
			// Debug.Log("Collider position: " + colliderPosition);

			BoxCollider2D paddleCollider = (BoxCollider2D)other.collider;

			float paddleLength = paddleCollider.size.x;

			float collisionOffset = (contactPoint.x - colliderPosition.x) / paddleLength;

			// Debug.Log("Collision offset:  " + (collisionOffset * 100) + "%");

			Vector2 currentVelocity = _lastVelocityVector;

			// Debug.Log("Current velocity:  " + currentVelocity);

			Vector2 currentNormal = other.GetContact(0).normal;

			if (currentNormal.y == 1f) {

				// Debug.Log("Need adjustment!");

				// Debug.Log("Current direction:  " + currentVelocity.normalized);

				float currentSpeed = currentVelocity.magnitude;
				// Debug.Log("Current speed:      " + currentSpeed);

				// Debug.Log("Current normal:     " + currentNormal);

				Vector2 adjustedNormal = new Vector2(collisionOffset, currentNormal.y).normalized;
				// Debug.Log("Adjusted normal:    " + adjustedNormal);

				Vector2 adjustedDirection = Vector2.Reflect(currentVelocity.normalized, adjustedNormal);
				// Debug.Log("Adjusted direction: " + adjustedDirection);

				Vector2 adjustedVelocity = adjustedDirection * currentSpeed;
				// Debug.Log("Adjusted velocity:  " + adjustedVelocity);

				// Debug.Log("Adjusted speed:     " + adjustedVelocity.magnitude);

				_ballRigidBodyComponent.velocity = adjustedVelocity;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		PeventInfiniteLoops();
	}

  private void PeventInfiniteLoops()
  {
		// Debug.Log("Last Velocity:" + _lastVelocityVector);
		Vector2 currentVelVec = _ballRigidBodyComponent.velocity; 
		// Debug.Log("Current Velocity:" + currentVelVec);
    Vector2 resultantVector = currentVelVec + _lastVelocityVector;
		if (resultantVector == Vector2.zero) {
			Debug.Log("Prevent Infinite Loop logic processed!");
			bool isXhigherThanY = Math.Abs(currentVelVec.x) > Math.Abs(currentVelVec.y) ? true : false;
			float deviationValue = isXhigherThanY ? currentVelVec.x * 0.05f : currentVelVec.y * 0.05f;
			Vector2 deviationVelVec = isXhigherThanY 
				? new Vector2(-deviationValue, +deviationValue) 
				: new Vector2(+deviationValue, -deviationValue);
			_ballRigidBodyComponent.velocity += deviationVelVec;
		}
		// Debug.Log("New Velocity:" + _ballRigidBodyComponent.velocity);
		_lastVelocityVector = _ballRigidBodyComponent.velocity;
  }
}
