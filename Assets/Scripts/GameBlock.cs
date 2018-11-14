using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour {

	[SerializeField] AudioClip blockBreadSound;

	Level _level; 

	private void Start() {
		_level = FindObjectOfType<Level>();

		_level.AddABreakableBlock();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		AudioSource.PlayClipAtPoint(blockBreadSound, Camera.main.transform.position);
		Destroy(gameObject);
		_level.RemoveBreakableBlock();
	}
}
