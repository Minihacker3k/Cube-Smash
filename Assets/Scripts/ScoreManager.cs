using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	DistanceCalculator distanceCalculator;
	private int score;
	[SerializeField]
	private TMP_InputField inputName;

	public UnityEvent<string, int> submitScoreEvent;

	public void SubmitScore()
	{
		distanceCalculator = GameObject.FindGameObjectWithTag("DistanceCalc").GetComponent<DistanceCalculator>();
		score = distanceCalculator.roundedMaxDistance;
		Debug.Log(score);
		submitScoreEvent.Invoke(inputName.text, score);
	}


	string FormatNumber(int num)
	{
		if (num >= 1000000)
		{
			return (num / 1000000).ToString("0.##") + " Mio";
		}
		else if (num >= 1000)
		{
			return (num / 1000).ToString("0.##") + "K";
		}
		else
		{
			return num.ToString();
		}
	}



}
