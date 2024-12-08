using TMPro;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
	private GameObject[] cubes;
	public float currentMaxDistance = 0;
	public int roundedMaxDistance;
	public TextMeshProUGUI distanceText;

	private CheckIfOnLeaderboard leaderboardCheck;

	private void Start()
	{
		leaderboardCheck = GameObject.FindGameObjectWithTag("LeaderboardCheck").GetComponent<CheckIfOnLeaderboard>();
	}

	void Update()
	{
		cubes = GameObject.FindGameObjectsWithTag("Hitable");

		float currentMaxDistance = 0;
		foreach (GameObject cube in cubes)
		{
			float distance = Vector3.Distance(cube.transform.position, transform.position);
			if (distance >= currentMaxDistance)
			{
				currentMaxDistance = distance;
			}

		}

		roundedMaxDistance = Mathf.RoundToInt(currentMaxDistance);
		distanceText.text = "FarthestCube: " + FormatNumber(roundedMaxDistance);

		if (Input.GetKeyDown(KeyCode.C) && leaderboardCheck.onLeaderboard == false)
		{

			foreach (GameObject cube in cubes)
			{
				Destroy(cube);

			}



		}




	}


	string FormatNumber(float num)
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
