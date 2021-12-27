using Steering;
using UnityEngine;

namespace Hunter.Scripts.Steering
{
	public class Flee : SteeringBehaviour
	{
		public Transform aggressorPosition;

		public override Vector2 GetSteeringVelocity()
		{
			return -(transform.position - aggressorPosition.transform.position).normalized * source.maxVelocity;

		}
	}

}
