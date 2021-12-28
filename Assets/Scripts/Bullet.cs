using DefaultNamespace.Managers;
using UnityEngine;

namespace Assets.Scripts
{

	public class Bullet : MonoBehaviour
	{
		[SerializeField] public float maxVelocity;
		[SerializeField] public Vector2 direction;

		public void OnCollisionEnter2D(Collision2D col)
		{
			if (col.gameObject.CompareTag("Field")) return;

			NotificationManager.Instance.PostMessage("You killed" + col.gameObject.name + ", great job!");

			Destroy(col.gameObject);
			Destroy(gameObject);
		}

		private void Update()
		{
			transform.position += (Vector3)direction * maxVelocity * Time.deltaTime;
			maxVelocity -= Time.deltaTime * 10;

			if (maxVelocity <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
