using Assets.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Hunter.Scripts
{
	public class Hunter : MonoBehaviour
	{
		[SerializeField] private Vector2 velocity;
		[SerializeField] private GameObject bulletPrefab;
		[SerializeField] private Vector2 acceleration;
		[SerializeField] private float playerSpeed;



		public void ApplyForce()
		{
			velocity += acceleration * Time.deltaTime;
			velocity = Vector2.ClampMagnitude(velocity, playerSpeed);
		}

		public void UpdatePosition()
		{
			transform.position += (Vector3)velocity * Time.deltaTime;
		}

		public void AddForce(Vector2 force)
		{
			acceleration += force;
		}

		public void ReduceSpeed()
		{
			velocity -= velocity.normalized * Time.deltaTime;
		}

		private void OnCollisionEnter2D(Collision2D collider)
		{
			Destroy(gameObject);
		}

		private void Update()
		{

			var hunterTransform = transform;
			var mousePosition = (Vector2)Camera.main!.ScreenToWorldPoint(Input.mousePosition);
			var playerPosition = (Vector2)transform.position;
			var movePosition = (mousePosition - playerPosition).normalized;
			if (Input.GetMouseButton(0))
			{
				movePosition = (mousePosition - playerPosition).normalized;
				AddForce(movePosition * playerSpeed) ;
				ApplyForce();
				UpdatePosition();

			}

			if (Input.GetMouseButtonDown(1)) //for firing
			{
				movePosition = (mousePosition - playerPosition).normalized;
				var bullet = Instantiate(bulletPrefab,
					(Vector2)transform.position + movePosition.normalized * 2,
					Quaternion.Euler(movePosition.normalized));
				bullet.GetComponent<Bullet>().direction = movePosition.normalized;
			}

			ReduceSpeed();
			acceleration = Vector2.zero;


		}



	}
}
