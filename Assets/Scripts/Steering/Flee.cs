using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Steering
{
	public class Flee : SteeringBehaviour
	{
		public List<string> runFromTags;
		public List<Transform> aggressorsPosition;
		public float detectionRadius;

		private void FindAggressorsInRadius()
		{
			var potentialTargets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

			var aggressors = new List<Transform>();

			foreach (var target in potentialTargets)
			{
				var entity = target.gameObject;
				if (runFromTags.Contains(entity.tag))
				{
					aggressors.Add(entity.transform);
				}
			}

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
