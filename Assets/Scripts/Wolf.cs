using System.Collections.Generic;
using System.Linq;
using Hunter.Scripts.Steering;
using Steering;
using UnityEngine;

namespace Hunter.Scripts
{
	public class Wolf : SteeringObject
	{

		[SerializeField] public float wanderingSpeed;

		[SerializeField] public float detectionRadius;

		public void Start()
		{
			velocity = new Vector2(wanderingSpeed/2,wanderingSpeed/2);
		}


		public override void ApplyForce(Vector2 force)
		{
			acceleration += force;
		}

		private void Update()
		{
			ApplySteeringForces();
			ApplyAcceleration();
			UpdatePosition();
			ReduceSpeed();
			ResetAcceleration();
		}

	}
}
