using System;
using UnityEngine;

[Serializable]
public class HairBladeScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public Vector3 PreviousPosition;

	public Collider MyCollider;

	public float Timer;

	public StudentScript Student;

	public virtual void Update()
	{
		this.MyCollider.enabled = false;
		if (Vector3.Distance(this.transform.position, this.PreviousPosition) > 0.5f)
		{
			this.MyCollider.enabled = true;
		}
		this.PreviousPosition = this.transform.position;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript)) != null)
		{
			this.Student = (StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student.StudentID != 1 && !this.Student.Dead)
			{
				this.Student.Dead = true;
				if (!this.Student.Male)
				{
					UnityEngine.Object.Instantiate(this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				}
				else
				{
					UnityEngine.Object.Instantiate(this.MaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				}
				this.Student.BecomeRagdoll();
				this.Student.Ragdoll.Dismember();
				this.audio.Play();
			}
		}
	}

	public virtual void Main()
	{
	}
}
