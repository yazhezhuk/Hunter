using UnityEngine;

namespace Assets.Scripts.Steering
{
	public class Flocking : SteeringBehaviour
	{

		public float flockingRadius;
		public float maxVelocity;
		public float cohesionCoeff;
		public float Coeff;



		public override Vector2 GetSteeringVelocity()
		{
			return Cohesion() + Align() + Separation();
		}

		private Vector2 Separation()
		{
			var agentPosition = source.transform.position;
			Vector2 separationForce = Vector2.zero;
			int count = 0;

			foreach (Transform a in transform.parent)
			{
				float dist = Vector2.Distance(transform.position, a.position);

				if (dist > 0 && dist < flockingRadius)
				{

					Vector2 diff = agentPosition - a.position;
					diff.Normalize();
					diff /= dist;
					separationForce += diff;
					count++;
				}
				Debug.DrawLine(Vector2.zero,transform.position - a.position,Color.red);
			}

			if (count > 0) separationForce /= count;

			if (separationForce.magnitude > 0)
			{
				separationForce *= maxVelocity;
				separationForce = Vector3.ClampMagnitude(separationForce - GetComponent<SteeringObject>().velocity, maxVelocity);
				separationForce *= 5;
				return (separationForce);
			}

			return Vector2.zero;
		}

		private Vector2 Align()
		{
			var direction = Vector2.zero;
			var agentPosition = source.transform.position;
			var groupCenterPosition = transform.parent.position;
			float distToCenter = Vector2.Distance(agentPosition, groupCenterPosition);
			if (distToCenter > 0 && distToCenter < flockingRadius)
			{
				direction += transform.parent.GetComponent<SteeringObject>().velocity;
			}

			direction = direction.normalized * maxVelocity/2;
			return direction;
		}

		private Vector2 Cohesion()
		{
			var direction = Vector2.zero;
			var agentPosition = source.transform.position;
			var groupCenterPosition = transform.parent.position;

			float distanceToCenter = Vector2.Distance(groupCenterPosition, agentPosition);
			if (distanceToCenter > 0 && distanceToCenter < flockingRadius)
			{
					direction += (Vector2)( groupCenterPosition - agentPosition);
			}


			return direction.normalized * cohesionCoeff;
		}
	}
}
