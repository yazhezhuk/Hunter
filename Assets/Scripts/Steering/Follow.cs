using Steering;
using UnityEngine;

namespace Hunter.Scripts.Steering
{
	public class Follow : SteeringComponent
	{

		public override Vector2 GetSteeringVelocity(Transform desiredPosition)
		{
			return (desiredPosition.position - Wolf.transform.position).normalized * Wolf.maxSpeed;
		}
	}
}
