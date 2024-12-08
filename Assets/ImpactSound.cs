using UnityEngine;

public class ImpactSound : MonoBehaviour
{
	private AudioSource impactSound;
	public AudioClip normalHitSound;

	public AudioClip hardHitSound;



	private void Start()
	{
		impactSound = GameObject.FindGameObjectWithTag("ImpactSound").GetComponent<AudioSource>();


	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > 1 && collision.relativeVelocity.magnitude < 100)
		{
			impactSound.volume = collision.relativeVelocity.magnitude / 100;
			impactSound.clip = normalHitSound;
			impactSound.Play();
		}

		if (collision.relativeVelocity.magnitude > 100)
		{
			impactSound.volume = collision.relativeVelocity.magnitude / 100;
			impactSound.clip = hardHitSound;
			impactSound.Play();
		}

	}
}
