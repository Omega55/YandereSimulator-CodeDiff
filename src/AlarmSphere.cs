using System;
using UnityEngine;

[Serializable]
public class AlarmSphere : MonoBehaviour
{
	public StudentScript Student;

	public int Frame;

	public virtual void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		this.Frame++;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null)
			{
				this.Student.Alarm = (float)200;
			}
		}
	}

	public virtual void Main()
	{
	}
}
