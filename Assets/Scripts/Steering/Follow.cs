using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Steering
{
	public class Follow : SteeringBehaviour
	{
		public float detectionRadius;
		public Transform targetPosition;
		public List<string> validToFollow;


		private void FindPrayInRadius()
		{
			var potentialTargets = Physics2D.OverlapCircleAll(transform.position, detectionRadius)
				.ToList();

			foreach (var potentialTarget in potentialTargets.ToList()) // deleting non followed types
			{
				if (!validToFollow.Contains(potentialTarget.tag))
					potentialTargets.Remove(potentialTarget);
			}

			if (potentialTargets.Count == 0)
			{
				return;
			}

			targetPosition = potentialTargets[0].transform;
		}


		public override Vector2 GetSteeringVelocity()
		{
			FindPrayInRadius();

			if (targetPosition == null)
			{
				return Vector2.zero;
			}

			var velocity = (targetPosition.position - source.transform.position).normalized * source.maxVelocity;
			targetPosition = null;

			return velocity;
		}
	}
}
