using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

	[SerializeField] int _breakableBlocks; // for debuging purposes

	SceneLoader _sceneLoader;

	private void Start() {
		_sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void AddABreakableBlock()
	{
		_breakableBlocks++;
	}

	public void RemoveBreakableBlock()
	{
		_breakableBlocks--;

		if (_breakableBlocks == 0) {
			_sceneLoader.LoadNextScene();
		}
	}

}
