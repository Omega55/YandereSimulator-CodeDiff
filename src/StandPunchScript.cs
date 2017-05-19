using System;
using UnityEngine;

[Serializable]
public class StandPunchScript : MonoBehaviour
{
	public Collider MyCollider;

	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript)) != null && ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript))).StudentID > 1)
		{
			((StudentScript)other.gameObject.GetComponent(typeof(StudentScript))).JojoReact();
		}
	}

	public virtual void Main()
	{
	}
}
