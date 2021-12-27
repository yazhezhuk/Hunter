using UnityEngine;

public class SteeringObject : MonoBehaviour
{
	protected SteeringManager SteeringManager;

	public Vector2 velocity;
	public Vector2 acceleration;
	public Vector2 Position => transform.position;
	public Vector2 FuturePosition => (Vector2)transform.position + velocity * Time.deltaTime;

	public float maxVelocity;
	public float minVelocity;


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
		var steeringForce = SteeringManager.GetResultingSteeringVelocity();

		ApplyForce(steeringForce);
	}

	public void ApplyAcceleration()
	{
		velocity += acceleration;
		velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
	}

	public void ReduceSpeed()
	{
			velocity -= velocity.normalized * Time.deltaTime;
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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var enemy = collision.gameObject;

		Destroy(enemy);
		Destroy(gameObject);
	}

	public void Update()
	{
		ApplySteeringForces();
		ApplyAcceleration();
		UpdatePosition();
		ReduceSpeed();
		ResetAcceleration(); }
}
