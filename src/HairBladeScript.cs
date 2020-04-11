using System;
using UnityEngine;

public class HairBladeScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public Vector3 PreviousPosition;

	public Collider MyCollider;

	public float Timer;

	public StudentScript Student;

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject.transform.root.gameObject;
		if (gameObject.GetComponent<StudentScript>() != null)
		{
			this.Student = gameObject.GetComponent<StudentScript>();
			if (this.Student.StudentID != 1 && this.Student.Alive)
			{
				this.Student.DeathType = DeathType.EasterEgg;
				Object.Instantiate<GameObject>(this.Student.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				this.Student.BecomeRagdoll();
				this.Student.Ragdoll.Dismember();
				base.GetComponent<AudioSource>().Play();
			}
		}
	}
}
