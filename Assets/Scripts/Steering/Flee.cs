using Steering;
using UnityEngine;

namespace Hunter.Scripts.Steering
{
	public class Flee : SteeringComponent
	{

		public override Vector2 GetSteeringVelocity(Transform desiredPosition)
		{
			return -(transform.position - desiredPosition.transform.position).normalized * Wolf.maxSpeed;

		}
	}

}
