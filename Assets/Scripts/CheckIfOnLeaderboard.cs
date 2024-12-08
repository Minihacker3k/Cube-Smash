using UnityEngine;

public class CheckIfOnLeaderboard : MonoBehaviour
{
	public bool onLeaderboard = false;
	public GameObject leaderBoard;


	void Update()
	{
		if (leaderBoard.activeSelf)
		{
			onLeaderboard = true;
		}
		else
		{
			onLeaderboard = false;
		}



	}
}
