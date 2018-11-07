using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene() {
		int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
		int totalScenesInBuildSequence = SceneManager.sceneCountInBuildSettings;
		int sceneIdxToLoad = (currentSceneIdx + 1) % totalScenesInBuildSequence;
		SceneManager.LoadScene(sceneIdxToLoad);
	}
}
