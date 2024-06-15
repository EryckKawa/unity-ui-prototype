using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
	[SerializeField] private int difficulty;
	private Button difficultyButton;
	private GameManager gameManager;
	// Start is called before the first frame update
	void Start()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

		difficultyButton = GetComponent<Button>();
		difficultyButton.onClick.AddListener(SetDifficulty);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SetDifficulty()
	{
		gameManager.StartGame(difficulty);
	}
}
