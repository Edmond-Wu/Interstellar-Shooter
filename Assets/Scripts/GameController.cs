using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;
	public Vector3 spawn_value;
	public int num_asteroids;
	public float wait_spawn;
	public float begin_wait;
	public float between_waves;
	private int score;

	public GUIText score_display;
	public GUIText restart_display;
	public GUIText gameover_display;

	private bool game_over;
	private bool restart;

	void Start() {
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnAsteroids ());
		gameover_display.text = "";
		restart_display.text = "";
		game_over = false;
		restart = false;
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnAsteroids() {
		yield return new WaitForSeconds(begin_wait);
		while(true) {
			for (int i = 0; i < num_asteroids; i++) {
				Vector3 spawn_position = new Vector3 (Random.Range (-spawn_value.x, spawn_value.x), spawn_value.y, spawn_value.z);
				Quaternion spawn_rotation = Quaternion.identity;
				Instantiate (asteroid, spawn_position, spawn_rotation);
				yield return new WaitForSeconds(wait_spawn);
			}
			yield return new WaitForSeconds(between_waves);

			if (game_over) {
				restart_display.text = "Press R to Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore ();
	}

	void UpdateScore() {
		score_display.text = "" + score;
	}

	public void GameOver() {
		gameover_display.text = "Game Over";
		game_over = true;
		GetComponent<AudioSource>().Stop();
	}
}
