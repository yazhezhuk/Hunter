using System;
using System.Threading.Tasks;
using Steering;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hunter.Scripts.Steering
{
	public class Wander : SteeringComponent
	{
		[SerializeField]
		public float wanderRadius;
		[SerializeField]
		public float wanderSpeed;
		[SerializeField]
		public float maxAngleFluctuations;



		public override Vector2 GetSteeringVelocity(Transform desiredPosition)
		{

			var direction = Random.insideUnitCircle.normalized;
			if (Vector2.Angle(Wolf.speed.normalized,direction.normalized) >= maxAngleFluctuations)
			{
				return Wolf.speed.normalized;
			}

			return direction.normalized;
		}
	}
}
