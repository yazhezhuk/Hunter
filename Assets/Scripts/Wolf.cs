using System.Collections.Generic;
using System.Linq;
using Hunter.Scripts.Steering;
using Steering;
using UnityEngine;

namespace Hunter.Scripts
{
	public class Wolf : MonoBehaviour
	{
		public Vector2 speed;
		public Vector2 acceleration;

		[SerializeField] public float maxSpeed;

		[SerializeField] public float wanderingSpeed;

		[SerializeField] public float detectionRadius;

		[SerializeField] public float accelerationReduction;


		public void Start()
		{
			speed = new Vector2(wanderingSpeed/2,wanderingSpeed/2);
		}

		public void ApplyForce(Vector2 force)
		{
			acceleration += force;
		}

		public void ProcessSteeringComponents()
		{
			var components = GetComponents<SteeringComponent>();

			if (components == null)
			{
				return;
			}

			components.ToList().Sort(
				(c1,c2) => c1.priority.CompareTo(c2.priority));

			var prioritizedComponent = components[0];

			ApplyForce(prioritizedComponent.GetSteeringVelocity(default));
			foreach (SteeringComponent steeringComponent in components.Skip(1))
			{

			}
		}





		private void Update()
		{
			ProcessSteeringComponents();
			UpdateSpeed();
			UpdatePosition();


			acceleration = Vector2.zero;


			void UpdateSpeed()
			{
				speed += acceleration;
				speed = Vector2.ClampMagnitude(speed, maxSpeed);
			}

			void UpdatePosition()
			{
				gameObject.transform.position  += ((Vector3)speed * Time.deltaTime);
			}
		}

	}
}
