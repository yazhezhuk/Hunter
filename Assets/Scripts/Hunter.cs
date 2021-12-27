using UnityEngine;

namespace Hunter.Scripts
{
	public class Hunter : MonoBehaviour
	{
		[SerializeField] private Vector3 speed;


		public void ApplyForce()
		{
			var hunterTransform = transform;
			hunterTransform.position += hunterTransform.forward * speed.magnitude;
		}



		private void Update ()
		{
			var distance = speed * Time.deltaTime;
			var hunterTransform = transform;

			if (Input.GetMouseButton(0))
				hunterTransform.position += (-hunterTransform.position + Camera.main!.ScreenToWorldPoint(Input.mousePosition)).normalized
				                            * distance.magnitude;

			if (Input.GetMouseButton(1)) //for firing
			{
				//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			}
		}



	}
}
