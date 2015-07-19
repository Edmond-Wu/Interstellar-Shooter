using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;
	public Vector3 spawn_value;
	public int num_asteroids;
	public float wait_spawn;
	public float begin_wait;
	public float between_waves;

	void Start() {
		StartCoroutine(SpawnAsteroids ());
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
		}
	}
}
