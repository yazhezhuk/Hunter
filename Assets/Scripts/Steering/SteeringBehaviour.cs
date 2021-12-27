using Hunter.Scripts;
using UnityEngine;

namespace Steering
{
	public abstract class SteeringBehaviour : MonoBehaviour
	{
		[SerializeField] public int priority;
		public SteeringObject source;

		void Start()
		{
			source = GetComponent<SteeringObject>();
		}

		public abstract Vector2 GetSteeringVelocity();
	}
}