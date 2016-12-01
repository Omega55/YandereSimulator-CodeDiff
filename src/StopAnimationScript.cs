using System;
using UnityEngine;

[Serializable]
public class StopAnimationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Transform Yandere;

	private Animation Anim;

	public virtual void Start()
	{
		this.StudentManager = (StudentManagerScript)GameObject.Find("StudentManager").GetComponent(typeof(StudentManagerScript));
		this.Anim = this.animation;
	}

	public virtual void Update()
	{
		if (this.StudentManager.DisableFarAnims)
		{
			if (Vector3.Distance(this.Yandere.position, this.transform.position) > (float)15)
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

	public virtual void Main()
	{
	}
}
