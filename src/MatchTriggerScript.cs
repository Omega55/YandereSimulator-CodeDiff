using System;
using UnityEngine;

public class MatchTriggerScript : MonoBehaviour
{
	public StudentScript Student;

	public bool Fireball;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student == null)
			{
				GameObject gameObject = other.gameObject.transform.root.gameObject;
				this.Student = gameObject.GetComponent<StudentScript>();
			}
			if (this.Student != null && (this.Student.Gas || this.Fireball))
			{
				this.Student.Combust();
				if (this.Fireball)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}
}
