using System;
using UnityEngine;

public class SithBeamScript : MonoBehaviour
{
	public GameObject BloodEffect;

	public Collider MyCollider;

	public float Damage = 10f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				component.Health -= this.Damage;
				component.HealthBar.transform.parent.gameObject.SetActive(true);
				component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
				if (component.Health <= 0f)
				{
					component.DeathType = DeathType.EasterEgg;
					component.HealthBar.transform.parent.gameObject.SetActive(false);
					component.BecomeRagdoll();
					Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
					rigidbody.isKinematic = false;
				}
				else
				{
					component.CharacterAnimation[component.SithReactAnim].time = 0f;
					component.CharacterAnimation.Play(component.SithReactAnim);
					component.Pathfinding.canSearch = false;
					component.Pathfinding.canMove = false;
					component.HitReacting = true;
					component.Routine = false;
					component.Fleeing = false;
				}
			}
		}
	}
}
