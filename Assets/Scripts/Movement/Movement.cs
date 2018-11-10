using UnityEngine;

public abstract class Movement : MonoBehaviour {
	protected Vector2 direction;

	[SerializeField]
	protected float movementSpeed;

	public void SetDirection(Vector2 direction) {
		this.direction = direction;
	}

	public virtual void OnTriggerExit2D(Collider2D collider) {
		if (!GetComponent<Collider2D> ().enabled)
			return;
		if (collider.CompareTag ("DespawnBoundary")) {
			Destroy (gameObject);
		}
	}
}
