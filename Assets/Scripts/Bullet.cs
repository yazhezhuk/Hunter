using UnityEngine;

namespace Assets.Scripts
{

	public class Bullet : MonoBehaviour
	{
		[SerializeField] public float maxVelocity;
		[SerializeField] public Vector2 direction;

		public void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.gameObject.CompareTag("Field"))
			{
				Destroy(col.gameObject);
				Destroy(gameObject);
			}
		}

		private void Update()
		{
			transform.position += (Vector3)direction * maxVelocity * Time.deltaTime;
			maxVelocity -= Time.deltaTime;

			if (maxVelocity <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
