using UnityEngine;

public class Game : MonoBehaviour
{
	public int wolfCount;
	public int lamasGroupsCount;
	public int rabbitsCount;

	public GameObject wolfPrefab;
	public GameObject doePrefab;
	public GameObject rabbitPrefab;
	public GameObject groupPrefab;

	public void Awake()
	{
		var fieldPosition = GetComponent<Collider2D>().bounds.size;
		for (int i = 0; i < wolfCount; i++)
		{
			var randX = Random.Range(0, fieldPosition.x/2);
			var randY = Random.Range(0, fieldPosition.y/2);
			Instantiate(wolfPrefab, new Vector3(randX, randY, 0), default);
		}
		for (int i = 0; i < lamasGroupsCount; i++)
		{
			var randX = Random.Range(0, fieldPosition.x/2);
			var randY = Random.Range(0, fieldPosition.y/2);
			Instantiate(wolfPrefab, new Vector3(randX, randY, 0), default);
		}
	}


}
