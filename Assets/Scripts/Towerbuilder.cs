using UnityEngine;
using TMPro;

public class TowerBuilder : MonoBehaviour
{
	public int towerHeight = 10;
	public int towerWidth = 5;
	public int towerDepth = 5;

	public bool isHolding1 = false;
	public bool isHolding2 = false;
	public bool isHolding3 = false;


	public GameObject cube;

	public Transform rayStartPoint;
	public float raycastDistance = 10f;

	public TextMeshProUGUI towerHeightText;
	public TextMeshProUGUI towerWidthText;
	public TextMeshProUGUI towerDepthText;

	private CheckIfOnLeaderboard leaderboardCheck;

	private void Start()
	{
		leaderboardCheck = GameObject.FindGameObjectWithTag("LeaderboardCheck").GetComponent<CheckIfOnLeaderboard>();
	}

	/*private void Start()
	{
		for (int y = 0; y < towerHeight; y++)  // Loop f�r die H�he des Turms
		{
			for (int x = 0; x < towerWidth; x++)  // Loop f�r die Breite (x-Achse)
			{
				for (int z = 0; z < towerWidth; z++)  // Loop f�r die Breite (z-Achse)
				{
					// Erstelle einen neuen W�rfel und setze den TowerBuilder (this) als Parent
					GameObject cubeObj = Instantiate(cube, transform);

					// Setze die lokale Position relativ zum Parent (TowerBuilder)
					cubeObj.transform.localPosition = new Vector3(x * 1.1f, y * 1.1f, z * 1.1f);
				}
			}
		}
	}*/

	private void Update()
	{
		if (leaderboardCheck.onLeaderboard == true)
		{
			return;
		}

		#region IncreaseHeight      
		if (Input.GetKeyDown(KeyCode.Alpha1)) { isHolding1 = true; }
		if (Input.GetKeyUp(KeyCode.Alpha1)) { isHolding1 = false; }

		if (isHolding1 && Input.GetKeyDown(KeyCode.E)) { IncreaseWidth(); }
		if (isHolding1 && Input.GetKeyDown(KeyCode.Q)) { DecreaseWidth(); }

		#endregion

		#region IncreaseWidth     
		if (Input.GetKeyDown(KeyCode.Alpha2)) { isHolding2 = true; }
		if (Input.GetKeyUp(KeyCode.Alpha2)) { isHolding2 = false; }

		if (isHolding2 && Input.GetKeyDown(KeyCode.E)) { IncreaseHeight(); }
		if (isHolding2 && Input.GetKeyDown(KeyCode.Q)) { DecreaseHeight(); }

		#endregion

		#region IncreaseDepth      
		if (Input.GetKeyDown(KeyCode.Alpha3)) { isHolding3 = true; }
		if (Input.GetKeyUp(KeyCode.Alpha3)) { isHolding3 = false; }

		if (isHolding3 && Input.GetKeyDown(KeyCode.E)) { IncreaseDepth(); }
		if (isHolding3 && Input.GetKeyDown(KeyCode.Q)) { DecreaseDepth(); }

		#endregion


		if (towerHeight <= 1) { towerHeight = 1; }
		if (towerWidth <= 1) { towerWidth = 1; }
		if (towerDepth <= 1) { towerDepth = 1; }



		if (Input.GetKeyDown(KeyCode.B))
		{
			Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
			RaycastHit hit;

			// Pr�fen, ob der Ray etwas trifft
			if (Physics.Raycast(ray, out hit, raycastDistance))
			{
				// Die Position, an der der Ray getroffen hat, in der Konsole ausgeben
				Debug.Log("Raycast hat getroffen an Position: " + hit.point);

				// Speichere die Trefferposition
				Vector3 hitPosition = hit.point;
				hitPosition = new Vector3(hitPosition.x, hitPosition.y + 1f, hitPosition.z);

				// Baue den Turm relativ zur Trefferposition
				for (int y = 0; y < towerHeight; y++)  // Loop f�r die H�he des Turms
				{
					for (int x = 0; x < towerWidth; x++)  // Loop f�r die Breite (x-Achse)
					{
						for (int z = 0; z < towerDepth; z++)  // Loop f�r die Breite (z-Achse)
						{
							// Erstelle einen neuen W�rfel
							GameObject cubeObj = Instantiate(cube, transform);

							// Setze die Position des W�rfels relativ zur Trefferposition
							cubeObj.transform.position = hitPosition + new Vector3(x * 1.1f, y * 1.1f, z * 1.1f);
						}
					}
				}
			}
		}

		towerHeightText.text = "Y: " + towerHeight.ToString();
		towerWidthText.text = "X: " + towerWidth.ToString();
		towerDepthText.text = "Z: " + towerDepth.ToString();


	}


	private void IncreaseHeight()
	{
		towerHeight++;
	}
	private void DecreaseHeight()
	{
		towerHeight--;
	}

	private void IncreaseWidth()
	{
		towerWidth++;
	}
	private void DecreaseWidth()
	{
		towerWidth--;
	}

	private void IncreaseDepth()
	{
		towerDepth++;
	}
	private void DecreaseDepth()
	{
		towerDepth--;
	}


}
