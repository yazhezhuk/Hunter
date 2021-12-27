using System.Collections.Generic;
using System.Linq;
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


		private void OnTriggerEnter2D(Collider2D collider)
		{

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
