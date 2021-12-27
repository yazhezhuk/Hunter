using UnityEngine;

namespace Hunter.Scripts
{

	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float maxVelocity;
		[SerializeField] private Vector2 velocity;


		private void Start()
		{
			velocity += (Vector2)transform.position.normalized * maxVelocity;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			var enemy = collision.gameObject;

			Destroy(enemy);
		}

		private void Update()
		{
			transform.position += (Vector3)velocity * Time.deltaTime;
		}
	}
}
