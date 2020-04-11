using System;
using UnityEngine;

public class PlaceholderStudentScript : MonoBehaviour
{
	public FakeStudentSpawnerScript FakeStudentSpawner;

	public GameObject EmptyGameObject;

	public bool ShootRaycasts;

	public Transform Target;

	public Transform Eyes;

	public int StudentID;

	public int Phase;

	public int NESW;

	private void Start()
	{
		this.Target = Object.Instantiate<GameObject>(this.EmptyGameObject).transform;
		this.ChooseNewDestination();
	}

	private void Update()
	{
		base.transform.LookAt(this.Target.position);
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Target.position, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Target.position) < 1f)
		{
			this.ChooseNewDestination();
		}
		if (Input.GetKeyDown("space"))
		{
			if (!this.ShootRaycasts)
			{
				this.ShootRaycasts = true;
			}
			else
			{
				this.Phase++;
			}
		}
		if (base.transform.position.y < 1f && this.ShootRaycasts)
		{
			if (this.Phase == 0)
			{
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
				Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
				return;
			}
			if (this.StudentID < this.FakeStudentSpawner.StudentID + 5 && this.StudentID > this.FakeStudentSpawner.StudentID - 5)
			{
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[0].transform.position, Color.red);
				}
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[1].transform.position, Color.red);
				}
				if (Vector3.Distance(base.transform.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position) < 5f)
				{
					Debug.DrawLine(this.Eyes.position, this.FakeStudentSpawner.SuspiciousObjects[2].transform.position, Color.red);
				}
			}
		}
	}

	private void ChooseNewDestination()
	{
		if (this.NESW == 1)
		{
			this.Target.position = new Vector3(Random.Range(-21f, 21f), base.transform.position.y, Random.Range(21f, 19f));
			return;
		}
		if (this.NESW == 2)
		{
			this.Target.position = new Vector3(Random.Range(19f, 21f), base.transform.position.y, Random.Range(29f, -37f));
			return;
		}
		if (this.NESW == 3)
		{
			this.Target.position = new Vector3(Random.Range(-21f, 21f), base.transform.position.y, Random.Range(-21f, -19f));
			return;
		}
		if (this.NESW == 4)
		{
			this.Target.position = new Vector3(Random.Range(-19f, -21f), base.transform.position.y, Random.Range(29f, -37f));
		}
	}
}
