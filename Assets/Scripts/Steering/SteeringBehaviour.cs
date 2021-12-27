using Hunter.Scripts;
using UnityEngine;

namespace Steering
{
	public abstract class SteeringBehaviour : MonoBehaviour
	{
		public int priority;
		public SteeringObject source;
		public float maxSteeringForce;

		void Start()
		{
			source = GetComponent<SteeringObject>();
		}

		public abstract Vector2 GetSteeringVelocity();
	}
}
