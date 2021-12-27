using Steering;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Steering
{
	public class Wander : SteeringBehaviour
	{
		public float maxAngleFluctuations;

		public override Vector2 GetSteeringVelocity()
		{

			var direction = Random.insideUnitCircle.normalized;
			if (Vector2.Angle(source.velocity.normalized,direction.normalized) > maxAngleFluctuations)
			{
				return source.velocity.normalized;
			}

			return direction.normalized;
		}
	}
}
