using Hunter.Scripts;
using UnityEngine;

namespace Steering
{
	public abstract class SteeringComponent : MonoBehaviour
	{
		[SerializeField] public int priority;
		protected Wolf Wolf;

		void Start()
		{
			Wolf = GetComponent<Wolf>();
		}

		public abstract Vector2 GetSteeringVelocity(Transform desiredPosition);
	}
}
