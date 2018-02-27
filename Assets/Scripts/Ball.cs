using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
					
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (0f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D trigger) {
		Vector2 tweak = new Vector2(Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
				
		if (hasStarted && !trigger.gameObject.CompareTag("Breakable")){
			print (tweak);
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
