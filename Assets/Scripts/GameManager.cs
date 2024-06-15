using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> targets;
	[SerializeField] private float spawnRate = 1.0f;
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI gameOverText;
	[SerializeField] private Button restartButton;
	[SerializeField] private GameObject titleScreen;

	private float score;
	[SerializeField] private bool isGameActive;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator SpawnTarget()
	{
		while (isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			int randomIndex = Random.Range(0, targets.Count);
			Instantiate(targets[randomIndex]);

		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		isGameActive = false;
	}

	public bool GetIsGameActive()
	{
		return isGameActive;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StartGame(int difficulty)
	{
		isGameActive = true;
		spawnRate /= difficulty;
		
		scoreText.gameObject.SetActive(true);
		titleScreen.gameObject.SetActive(false);

		StartCoroutine(SpawnTarget());
		UpdateScore(0);
	}
}
