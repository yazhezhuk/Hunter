using UnityEngine;

public abstract class SteeringObject : MonoBehaviour
{
	protected SteeringManager SteeringManager;

	public Vector2 velocity;
	public Vector2 acceleration;

	public float maxVelocity;
	public float minVelocity;
	public float maxSteeringForce;


	public void Awake()
	{
		SteeringManager = ScriptableObject.CreateInstance<SteeringManager>();
	}

	public void ApplyForce(Vector2 force)
	{
		acceleration += force;
	}

	public void ApplySteeringForces()
	{
		SteeringManager.ResolveSteeringComponents(this);
		var steeringForce = SteeringManager.GetResultingSteeringVelocity().normalized * maxSteeringForce;

		ApplyForce(steeringForce);
	}

	public void ApplyAcceleration()
	{
		velocity += acceleration;
		velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
	}

	public void ReduceSpeed()
	{
			velocity -= acceleration.normalized * 0.5f;
			if (velocity.magnitude < minVelocity)
				velocity = Vector2.ClampMagnitude(velocity, minVelocity);

	}

	public void UpdatePosition()
	{
		transform.position += (Vector3)velocity * Time.deltaTime;
	}

	public void ResetAcceleration()
	{
		acceleration = Vector2.zero;
	}

}
