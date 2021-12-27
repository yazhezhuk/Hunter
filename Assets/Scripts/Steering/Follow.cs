using Steering;
using UnityEngine;

namespace Hunter.Scripts.Steering
{
	public class Follow : SteeringBehaviour
	{
		public Transform targetPosition;

		public override Vector2 GetSteeringVelocity()
		{
			return (source.transform.position - targetPosition.position).normalized * source.maxVelocity;
		}
	}
}
