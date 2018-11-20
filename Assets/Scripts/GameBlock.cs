using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBlock : MonoBehaviour {

	[SerializeField] AudioClip blockBreakSound;
	[SerializeField] GameObject _blockVFX;
	[SerializeField] Sprite[] _blockSprites;

	Level _level; 
	GameState _gameState;

	[SerializeField] int currentHits = 0; 
	

	private void Start()
  {
    CountBreakableBlocks();
  }

  private void CountBreakableBlocks()
  {
    _level = FindObjectOfType<Level>();
    _gameState = GameState.Instance;

    if (tag == "Breakable")
    {
      _level.AddABreakableBlock();
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
		if (tag == "Breakable") {
			currentHits++;
			if (currentHits >= _blockSprites.Length) {
				AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
				Destroy(gameObject);
				_level.RemoveBreakableBlock();
				_gameState.ScoreBlock();
			}
			else {
				ShowNextHitSprite();
			}
		}
		else {
			TriggerVFX();
		}
	}

  private void ShowNextHitSprite()
  {
		var spriteIndex = currentHits;
		var sprite = GetComponent<SpriteRenderer>().sprite = _blockSprites[spriteIndex];
  }

  private void TriggerVFX() {
		GameObject effect = Instantiate(_blockVFX, transform.position, transform.rotation);
		Destroy(effect, 1f);
	}
}
