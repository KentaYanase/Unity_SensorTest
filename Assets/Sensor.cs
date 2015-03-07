using UnityEngine;
using System.Collections;


public class Sensor : MonoBehaviour {

	[Tooltip("センサー情報を受け取るGameObjectを指定 [デフォルトは自身の親]")]
	[SerializeField]
	private Transform _receiver;

	public SendMessageOptions option = SendMessageOptions.DontRequireReceiver;

	private Collider _myCollider;
	private Collider2D _myCollider2D;

	public Transform receiver {
		get { 
			if (_receiver == null) {
				_receiver = transform.parent;
			}
			return _receiver;
		}
	}

	public Collider myCollider {
		get {
			if (_myCollider == null) {
				_myCollider = GetComponent<Collider> ();
				if (_myCollider == null) {
					Debug.LogError ("Colliderがありません");
				}
			}
			return _myCollider;
		}
	}

	public Collider2D myCollider2D {
		get {
			if (_myCollider2D == null) {
				_myCollider2D = GetComponent<Collider2D> ();
				if (_myCollider2D == null) {
					Debug.LogError ("Collider2Dがありません");
				}
			}
			return _myCollider2D;
		}
	}

	#region Collision 3D

	void OnCollisionEnter (Collision c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorEnter", new CollisionPair(myCollider, c), option);
	}

	void OnCollisionExit (Collision c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorExit", new CollisionPair(myCollider, c), option);
	}

	void OnCollisionStay (Collision c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorStay", new CollisionPair(myCollider, c), option);
	}
	#endregion

	#region Collision 2D

	void OnCollisionEnter2D (Collision2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorEnter2D", new Collision2DPair(myCollider2D, c), option);
	}

	void OnCollisionExit2D (Collision2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorExit2D", new Collision2DPair(myCollider2D, c), option);
	}

	void OnCollisionStay2D (Collision2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnCollisionSensorStay2D", new Collision2DPair(myCollider2D, c), option);
	}
	#endregion

	#region Trigger 3D

	void OnTriggerEnter (Collider c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorEnter", new ColliderPair(myCollider, c), option);
	}

	void OnTriggerExit (Collider c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorExit", new ColliderPair(myCollider, c), option);
	}

	void OnTriggerStay (Collider c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorStay", new ColliderPair(myCollider, c), option);
	}
	#endregion

	#region Trigger 2D

	void OnTriggerEnter2D (Collider2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorEnter2D", new Collider2DPair(myCollider2D, c), option);
	}

	void OnTriggerExit2D (Collider2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorExit2D", new Collider2DPair(myCollider2D, c), option);
	}

	void OnTriggerStay2D (Collider2D c) {
		if (receiver == null) return;
		receiver.SendMessage("OnTriggerSensorStay2D", new Collider2DPair(myCollider2D, c), option);
	}
	#endregion

	#region Pair

	public struct CollisionPair {
		public Collider sencsor;
		public Collision collision;

		public CollisionPair (Collider sencsor, Collision collision) {
			this.sencsor = sencsor;
			this.collision = collision; 
		}

		public override string ToString () {
			string sensorName = (sencsor != null) ? sencsor.name : "";
			string collisionName = (collision != null) ? collision.collider.name : "";
			return string.Format ("[CollisionPair] <{0},{1}>", sensorName, collisionName);
		}
	}

	public struct Collision2DPair {
		public Collider2D sencsor;
		public Collision2D collision;

		public Collision2DPair (Collider2D sencsor, Collision2D collision) {
			this.sencsor = sencsor;
			this.collision = collision; 
		}

		public override string ToString () {
			string sensorName = (sencsor != null) ? sencsor.name : "";
			string collisionName = (collision != null) ? collision.collider.name : "";
			return string.Format ("[CollisionPair] <{0},{1}>", sensorName, collisionName);
		}
	}

	public struct ColliderPair {
		public Collider sencsor;
		public Collider collider;

		public ColliderPair (Collider sencsor, Collider collider) {
			this.sencsor = sencsor;
			this.collider = collider; 
		}

		public override string ToString () {
			string sensorName = (sencsor != null) ? sencsor.name : "";
			string collisionName = (collider != null) ? collider.name : "";
			return string.Format ("[ColliderPair] <{0},{1}>", sensorName, collisionName);
		}
	}

	public struct Collider2DPair {
		public Collider2D sencsor;
		public Collider2D collider;

		public Collider2DPair (Collider2D sencsor, Collider2D collider) {
			this.sencsor = sencsor;
			this.collider = collider; 
		}

		public override string ToString () {
			string sensorName = (sencsor != null) ? sencsor.name : "";
			string collisionName = (collider != null) ? collider.name : "";
			return string.Format ("[Collider2DPair] <{0},{1}>", sensorName, collisionName);
		}
	}
	#endregion
}
