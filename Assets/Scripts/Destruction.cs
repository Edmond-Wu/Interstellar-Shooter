using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

	public GameObject explosion;
	public GameObject player_destruction;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Borders") {
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (player_destruction, other.transform.position, other.transform.rotation);
		}
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
