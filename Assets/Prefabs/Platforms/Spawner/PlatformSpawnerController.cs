using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawnerController : MonoBehaviour {

	public float spawn_frequency_seconds = 1;
	public GameObject small_platform_prefab;
	public GameObject medium_platform_prefab;
	public GameObject large_platform_prefab;

	public GameObject score_controller;
	public Text score_text;

	public float vertical_platform_spacing = 2;
	public int number_of_platform_positions = 3;
	private LinkedList<int> possible_platform_positions = new LinkedList<int>();

	private int previous_cell_position = -1;

	// Use this for initialization
	void Start () {
		for (int possible_position = 0; possible_position < number_of_platform_positions; possible_position++) {
			possible_platform_positions.AddLast(possible_position); 
		}
		InvokeRepeating ("spawnPlatform", 0f, spawn_frequency_seconds);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void spawnPlatform(){
		ScoreController.increment_score (10);
		score_text.text = "Score: " + ScoreController.getScore().ToString();
		GameObject platform = Instantiate(
			generateRandomPlatformSizePrefab(),
			generateRandomPlatformPosition(),
			Quaternion.identity
		);
	}

	void OnDrawGizmos(){
		Gizmos.color = new Color(0, 1, 0, 0.5F);
		for (int possible_cell = 0; possible_cell < number_of_platform_positions; possible_cell++) {
			Gizmos.DrawCube(
				this.transform.position + new Vector3 (0, vertical_platform_spacing * (float) possible_cell, 0),
				new Vector3(1, 1, 1));
		}
	}

	Vector3 generateRandomPlatformPosition(){
		Vector3 platform_position;
		if (previous_cell_position == -1) {
			int position_cell = Random.Range (0, number_of_platform_positions);
			platform_position = transform.position + new Vector3 (0, vertical_platform_spacing * position_cell, 0);
			previous_cell_position = position_cell;
		} else {
			int[] new_possible_platform_positions = new int[number_of_platform_positions - 1];
			int new_possible_index = 0;
			for (int possible_position = 0; possible_position < number_of_platform_positions; possible_position++) {
				if (possible_position != previous_cell_position) {
					new_possible_platform_positions[new_possible_index] = possible_position;
					new_possible_index++;
				}
			}
			int position_cell_selector = Random.Range (0, number_of_platform_positions - 1);
			int position_cell = new_possible_platform_positions [position_cell_selector];

			platform_position = transform.position + new Vector3 (0, vertical_platform_spacing * position_cell, 0);
			previous_cell_position = position_cell;
		}
		return platform_position;
	}

	GameObject generateRandomPlatformSizePrefab(){
		int random_size_determiner = Random.Range(0,3);
		if (random_size_determiner <= 1) {
			return small_platform_prefab;
		} else if (random_size_determiner <= 2) {
			return medium_platform_prefab;
		} else {
			return large_platform_prefab;
		}
	}
}
