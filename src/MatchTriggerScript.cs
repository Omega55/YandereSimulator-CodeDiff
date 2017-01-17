using System;
using UnityEngine;

[Serializable]
public class MatchTriggerScript : MonoBehaviour
{
	public StudentScript Student;

	public bool Fireball;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student == null)
			{
				this.Student = (StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
			}
			if (this.Student != null && (this.Student.Gas || this.Fireball))
			{
				this.Student.Combust();
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
