using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
	public GameObject[] levels;
	public int currentLevelIndex;
	public int previousLevelIndex;

	private GameObject previousLevelObj;


	public int GetIndexOfObject(GameObject targetObject)
	{
		for (int i = 0; i < levels.Length; i++)
		{

			if (levels[i] == targetObject)
			{

				return i; // Gibt den Index des Objekts zurück
			}
		}


		return -1; // Gibt -1 zurück, wenn das Objekt nicht gefunden wurde
	}


	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{


	}

	public void LevelCompleted()
	{
		gameObject.AddComponent<Completed>();
		Image image = GetComponent<Image>();
		image.color = Color.green;

	}


	public void CheckIfUnlockedAndStartLevel(GameObject thisObject)
	{
		currentLevelIndex = GetIndexOfObject(thisObject);
		Debug.Log(currentLevelIndex);

		previousLevelIndex = currentLevelIndex - 1;


		if (previousLevelIndex <= 0)
		{
			previousLevelIndex = 0;
			previousLevelObj = levels[0];
		}
		else
		{
			previousLevelObj = levels[previousLevelIndex];
		}
		Debug.Log(previousLevelIndex);

		if (currentLevelIndex == 0)
		{
			Debug.Log("SceneLoaded");
			SceneManager.LoadScene(currentLevelIndex + 1);
		}
		else if (previousLevelObj.GetComponent<Completed>() == true)
		{
			SceneManager.LoadScene(currentLevelIndex + 1);
		}

	}



}

