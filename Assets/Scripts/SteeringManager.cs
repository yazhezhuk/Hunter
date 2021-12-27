using System.Collections.Generic;
using System.Linq;
using Steering;
using UnityEngine;

public class SteeringManager : ScriptableObject
{
	public List<SteeringBehaviour> SteeringComponents { get; } = new List<SteeringBehaviour>();

	public void ResolveSteeringComponents(MonoBehaviour script)
	{
		SteeringComponents.AddRange(script.GetComponents<SteeringBehaviour>());
		SortByPriority();
	}

	public Vector2 GetResultingSteeringVelocity()
	{
		var resultVector = new Vector2();
		foreach (var component in SteeringComponents.ToList())
		{
			resultVector += GetComponentImpact(component);
			SteeringComponents.Remove(component);
		}

		return resultVector;
	}

	private Vector2 GetComponentImpact(SteeringBehaviour component) =>
		component.GetSteeringVelocity() * component.source.maxSteeringForce * (1 / Mathf.Pow(2, component.priority));

	private void SortByPriority()
	{
		SteeringComponents.Sort((c1,c2) =>
			c1.priority.CompareTo(c2.priority));
	}
}
