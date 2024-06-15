using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	private const string BAD = "Bad";
	private GameManager gameManager;
	private Rigidbody targetRb;
	private float minSpeed = 12;
	private float maxSpeed = 16;
	private float maxTorque = 10;
	private float xRange = 4;
	private float yRange = 2;

	[SerializeField] private int pointsTarget;
	[SerializeField] private ParticleSystem explosionParticle;
	// Start is called before the first frame update
	void Start()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		targetRb = GetComponent<Rigidbody>();

		targetRb.AddForce(AddRandomForce(), ForceMode.Impulse);
		targetRb.AddTorque(AddRandomTorque(), AddRandomTorque(), AddRandomTorque(), ForceMode.Impulse);

		transform.position = RandomSpawnPosition();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnMouseDown()
	{
		if (gameManager.GetIsGameActive())
		{
			Destroy(gameObject);
			Instantiate(explosionParticle, transform.position, transform.rotation);
			gameManager.UpdateScore(pointsTarget);

		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);

		if (!gameObject.CompareTag(BAD))
		{
			gameManager.GameOver();
		}
	}

	Vector3 AddRandomForce()
	{
		return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}

	Vector3 RandomSpawnPosition()
	{
		return new Vector3(Random.Range(-xRange, xRange), -yRange);
	}

	float AddRandomTorque()
	{
		return Random.Range(-maxTorque, maxTorque);
	}
}
