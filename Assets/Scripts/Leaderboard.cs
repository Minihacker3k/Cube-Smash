using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
	[SerializeField]
	private List<TextMeshProUGUI> names;
	[SerializeField]
	private List<TextMeshProUGUI> scores;

	private string publicLeaderboardKey = "bdb799d1ace773235f0522601017a2ed4563868e39702c3cdeab6981fce1fd6b";



	private void Start()
	{

		GetLeaderboard();
	}

	public void GetLeaderboard()
	{
		LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
		{
			int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;

			for (int i = 0; i < loopLength; ++i)
			{
				names[i].text = msg[i].Username;
				scores[i].text = FormatNumber(msg[i].Score);

			}


		}));
	}

	public void SetLeaderboardEntry(string username, int score)
	{



		// Truncate username only for display purposes
		if (username.Length > 10)
		{
			username = username.Substring(0, 10);
		}

		LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
		{
			// Log the truncated username for display
			Debug.Log(username);
			GetLeaderboard();
		}));
	}


	string FormatNumber(int num)
	{
		if (num >= 1000000)
		{
			return (num / 1000000.0).ToString("0.##") + " Mio"; // Division durch 1000000.0 als double
		}
		else if (num >= 1000)
		{
			return (num / 1000.0).ToString("0.##") + "K"; // Division durch 1000.0 als double
		}
		else
		{
			return num.ToString();
		}
	}


}
