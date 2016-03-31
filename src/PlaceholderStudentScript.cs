using System;
using UnityEngine;

[Serializable]
public class PlaceholderStudentScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public Transform Target;

	public int NESW;

	public virtual void Start()
	{
		this.Target = ((GameObject)UnityEngine.Object.Instantiate(this.EmptyGameObject)).transform;
		this.ChooseNewDestination();
	}

	public virtual void Update()
	{
		this.transform.LookAt(this.Target.position);
		this.transform.position = Vector3.MoveTowards(this.transform.position, this.Target.position, Time.deltaTime);
		if (Vector3.Distance(this.transform.position, this.Target.position) < (float)1)
		{
			this.ChooseNewDestination();
		}
	}

	public virtual void ChooseNewDestination()
	{
		if (this.NESW == 1)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), this.transform.position.y, UnityEngine.Random.Range(21f, 19f));
		}
		else if (this.NESW == 2)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(19f, 21f), this.transform.position.y, UnityEngine.Random.Range(29f, -37f));
		}
		else if (this.NESW == 3)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-21f, 21f), this.transform.position.y, UnityEngine.Random.Range(-21f, -19f));
		}
		else if (this.NESW == 4)
		{
			this.Target.position = new Vector3(UnityEngine.Random.Range(-19f, -21f), this.transform.position.y, UnityEngine.Random.Range(29f, -37f));
		}
	}

	public virtual void Main()
	{
	}
}
