using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour {

	[SerializeField] AudioClip blockBreadSound;

	private void OnCollisionEnter2D(Collision2D other) {
		AudioSource.PlayClipAtPoint(blockBreadSound, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
