using System;
using UnityEngine;

public class DemonArmScript : MonoBehaviour
{
	public GameObject DismembermentCollider;

	public Collider ClawCollider;

	public bool Attacking;

	public bool Attacked;

	public bool Rising = true;

	public string IdleAnim = "DemonArmIdle";

	public AudioClip Whoosh;

	private void Update()
	{
		Animation component = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			if (!this.Attacking)
			{
				component.CrossFade(this.IdleAnim);
			}
			else if (!this.Attacked)
			{
				if (component["DemonArmAttack"].time >= component["DemonArmAttack"].length * 0.25f)
				{
					this.ClawCollider.enabled = true;
					this.Attacked = true;
				}
			}
			else if (component["DemonArmAttack"].time >= component["DemonArmAttack"].length)
			{
				component.CrossFade(this.IdleAnim);
				this.Attacking = false;
				this.Attacked = false;
			}
		}
		else if (component["DemonArmRise"].time > component["DemonArmRise"].length)
		{
			this.Rising = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			AudioSource component2 = base.GetComponent<AudioSource>();
			component2.clip = this.Whoosh;
			component2.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
			component2.Play();
			base.GetComponent<Animation>().CrossFade("DemonArmAttack");
			this.Attacking = true;
		}
	}
}
