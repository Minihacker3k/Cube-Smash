using UnityEngine;
using TMPro;

public class InfiniteRebound : MonoBehaviour
{

	public Transform stayPoint;
	public Transform throwPoint;

	public float pullForce = 10000f;
	public float throwForce = 1000f;
	public TextMeshProUGUI throwForceText;


	public GameObject grabbedObject;
	public Rigidbody grabbedRigidbody;

	private CheckIfOnLeaderboard leaderboardCheck;

	private void Start()
	{
		leaderboardCheck = GameObject.FindGameObjectWithTag("LeaderboardCheck").GetComponent<CheckIfOnLeaderboard>();
	}
	private void Update()
	{
		Vector3 pullDirection = (stayPoint.position - grabbedObject.transform.position).normalized;
		grabbedRigidbody.AddForce(pullDirection * pullForce * Time.deltaTime, ForceMode.Force);
		Vector3 throwDirection = (throwPoint.transform.position - grabbedObject.transform.position).normalized;

		if (Input.GetMouseButtonDown(0) && leaderboardCheck.onLeaderboard == false)
		{

			Vector3 objDir = (grabbedObject.transform.position - transform.position).normalized;

			grabbedRigidbody.AddForce(-throwDirection * throwForce, ForceMode.Impulse);



		}

		if (Input.GetKeyDown(KeyCode.R) && leaderboardCheck.onLeaderboard == false)
		{
			grabbedRigidbody.linearVelocity = Vector3.zero;
			grabbedObject.transform.position = stayPoint.transform.position;
		}

		if (Input.GetKeyDown(KeyCode.P) && leaderboardCheck.onLeaderboard == false)
		{
			throwForce += 100;
		}
		if (Input.GetKeyDown(KeyCode.O) && leaderboardCheck.onLeaderboard == false)
		{
			throwForce -= 100;
		}
		throwForce = throwForce <= 100 ? 100 : throwForce;
		throwForceText.text = "ThrowForce: " + throwForce.ToString();

	}
}
