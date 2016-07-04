using UnityEngine;
using System.Collections;

public class NoteActions : MonoBehaviour {

	[Range(0,100)]public float speed;
	public float outOfBounds;

	void Start () {
		transform.position = new Vector3 (-outOfBounds, transform.position.y, transform.position.z);
	}

	void Update () {
		if (transform.position.x < outOfBounds) {
			// move back to far right of screen
			transform.position = new Vector3 (-outOfBounds, transform.position.y, transform.position.z);
		} else {
			// keep moving from R to L
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
	}

}