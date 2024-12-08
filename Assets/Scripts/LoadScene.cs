using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public void SceneLoad(string nameOfScene)
	{
		SceneManager.LoadScene(nameOfScene);
	}
}
