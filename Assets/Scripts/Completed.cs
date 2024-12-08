using UnityEngine;
using UnityEngine.UI;

public class Completed : MonoBehaviour
{
	public Image image;

	// Update is called once per frame
	void Update()
	{
		image = GetComponent<Image>();
		image.color = Color.green;
	}
}
