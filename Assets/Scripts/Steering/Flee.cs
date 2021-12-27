using System.Collections.Generic;
using System.Linq;
using Hunter.Scripts;
using UnityEngine;

namespace Steering
{
	public class Flee : SteeringBehaviour
	{
		public List<Transform> aggressorsPosition;
		public float detectionRadius;

		private void FindAggressorsInRadius()
		{
			var potentialTargets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

			var aggressors = potentialTargets
				.Where(target =>
					target.GetComponent<Hunter.Scripts.Hunter>() != target.GetComponent<Wolf>())
				.Select(target => target.transform)
				.ToList();

			aggressorsPosition = aggressors;
		}

		Vector2 ProcessSteeringVelocity(Transform targetPosition)
		{
			return (source.transform.position - targetPosition.position).normalized;
		}


		public override Vector2 GetSteeringVelocity()
		{
			FindAggressorsInRadius();

			if (aggressorsPosition == null)
			{
				return Vector2.zero;
			}

			var desiredVelocity = Vector2.zero;

			foreach (var aggressor in aggressorsPosition)
			{
				desiredVelocity += ProcessSteeringVelocity(aggressor);
			}

			desiredVelocity *= source.maxVelocity;
			aggressorsPosition = null;

			return desiredVelocity;
		}

	}
}
