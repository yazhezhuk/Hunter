using UnityEngine;

namespace Hunter.Scripts
{

	public class BulletObject : ScriptableObject
	{
		private const float Speed = 25;
		private Vector3 direction;
		private GameObject entity;

		public BulletObject(Vector3 direction, GameObject bulletEntity)
		{
			this.direction = direction;
			entity = bulletEntity;
		}

	}
}
