using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace
{

	public class Wolf : SteeringObject
	{
		private float canBeAlive;

		public void Start()
		{
			canBeAlive= Random.Range(4000, 600000);
		}

		public void OnTriggerEnter2D(Collider2D col)
		{

			if (!col.gameObject.CompareTag("Bullet")
			    && !col.gameObject.CompareTag("Wolf")
			    && !col.gameObject.CompareTag("Field"))
			{
				Destroy(col.gameObject);
				canBeAlive += 100000;
				NotificationManager.Instance.PostMessage("Wolf eaten " + col.gameObject.tag);
			}else if (col.gameObject.CompareTag("Bullet"))
			{
				Destroy(col.gameObject);
				Destroy(gameObject);
			}

		}

		private new void Update()
		{
			base.Update();
			canBeAlive -= Time.deltaTime;

			if (canBeAlive <= 0)
			{
				Destroy(this);
				NotificationManager.Instance.PostMessage(name + " died because of starvation");
			}
		}

	}
}
