using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LeaderboardToggle : MonoBehaviour
{
	public TMP_InputField myInputField;
	private bool tabIsBeingPressed = false;

	public GameObject leaderBoard;

	public ScoreManager scoreManager;

	void Start()
	{

	}


	void Update()
	{
		if (Input.GetKey(KeyCode.Tab))
		{
			tabIsBeingPressed = true;
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			tabIsBeingPressed = false;
		}


		if (tabIsBeingPressed)
		{
			leaderBoard.SetActive(true);
			SelectInputField();

			if (Input.GetKeyDown(KeyCode.Return))
			{
				scoreManager.SubmitScore();
			}
		}

		if (!tabIsBeingPressed)
		{
			leaderBoard.SetActive(false);

		}

	}

	void SelectInputField()
	{
		// First make sure the input field is active and enabled
		if (myInputField != null && myInputField.gameObject.activeInHierarchy)
		{
			// Select the input field to begin typing
			myInputField.ActivateInputField();
			EventSystem.current.SetSelectedGameObject(myInputField.gameObject, null);
		}
		else
		{
			Debug.LogWarning("Input field not assigned or inactive!");
		}
	}



}
