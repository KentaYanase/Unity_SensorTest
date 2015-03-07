using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	[SerializeField]
	private float power = 10;

	void Update () {
		float torque = -Input.GetAxis ("Horizontal") * power;

		GetComponent<Rigidbody2D> ().AddTorque (torque);
	}

	void OnCollisionSensorEnter2D (Sensor.Collision2DPair pair) {
		Debug.Log (pair);
	}
}