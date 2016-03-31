using System;
using UnityEngine;

[Serializable]
public class FakeStudentSpawnerScript : MonoBehaviour
{
	public GameObject NewStudent;

	public GameObject FakeFemale;

	public GameObject FakeMale;

	public GameObject Student;

	public int CurrentFloor;

	public int CurrentRow;

	public int FloorLimit;

	public int RowLimit;

	public int Spawned;

	public int Height;

	public int NESW;

	public virtual void Spawn()
	{
		this.Student = this.FakeFemale;
		this.NESW = 1;
		while (this.Spawned < this.FloorLimit * 3)
		{
			if (this.NESW == 1)
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(21f, 19f)), Quaternion.identity);
			}
			else if (this.NESW == 2)
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
			}
			else if (this.NESW == 3)
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(-21f, -19f)), Quaternion.identity);
			}
			else if (this.NESW == 4)
			{
				this.NewStudent = (GameObject)UnityEngine.Object.Instantiate(this.Student, new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
			}
			((PlaceholderStudentScript)this.NewStudent.GetComponent(typeof(PlaceholderStudentScript))).NESW = this.NESW;
			this.CurrentFloor++;
			this.CurrentRow++;
			this.Spawned++;
			if (this.CurrentFloor == this.FloorLimit)
			{
				this.CurrentFloor = 0;
				this.Height += 4;
			}
			if (this.CurrentRow == this.RowLimit)
			{
				this.CurrentRow = 0;
				this.NESW++;
				if (this.NESW > 4)
				{
					this.NESW = 1;
				}
			}
			if (this.Student == this.FakeFemale)
			{
				this.Student = this.FakeMale;
			}
			else
			{
				this.Student = this.FakeFemale;
			}
		}
	}

	public virtual void Main()
	{
	}
}
