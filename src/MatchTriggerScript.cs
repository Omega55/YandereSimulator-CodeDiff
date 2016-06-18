using System;
using UnityEngine;

[Serializable]
public class MatchTriggerScript : MonoBehaviour
{
	public bool Fireball;

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null && (studentScript.Gas || (studentScript.StudentID == 7 && this.Fireball)))
			{
				studentScript.Combust();
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
