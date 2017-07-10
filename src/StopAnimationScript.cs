using System;
using UnityEngine;

public class StopAnimationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform Yandere;

	private Animation Anim;

	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	private void Update()
	{
		if (this.StudentManager.DisableFarAnims)
		{
			if (Vector3.Distance(this.Yandere.position, base.transform.position) > 15f)
			{
				if (this.Anim.enabled)
				{
					this.Anim.enabled = false;
				}
			}
			else if (!this.Anim.enabled)
			{
				this.Anim.enabled = true;
			}
		}
		else if (!this.Anim.enabled)
		{
			this.Anim.enabled = true;
		}
	}
}
