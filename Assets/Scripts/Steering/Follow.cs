using System.Linq;
using Steering;
using UnityEngine;

namespace Hunter.Scripts.Steering
{
	public class Follow : SteeringBehaviour
	{
		public float detectionRadius;
		public Transform targetPosition;



		private void FindPrayInRadius()
		{
			 var potentialTargets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);


			if (potentialTargets.Length == 0)
			{
				return;
			}

			targetPosition = potentialTargets.FirstOrDefault(target =>
					target.gameObject.transform.position != gameObject.transform.position)
				?.gameObject.transform;
		}


		public override Vector2 GetSteeringVelocity()
		{
			FindPrayInRadius();

			if (targetPosition == null)
			{
				return Vector2.zero;
			}

			var velocity = (targetPosition.position - source.transform.position).normalized
			               * source.maxVelocity;
			targetPosition = null;

			return velocity;
		}
	}
}
