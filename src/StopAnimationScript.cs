using System;
using UnityEngine;

[Serializable]
public class StopAnimationScript : MonoBehaviour
{
	public Transform Yandere;

	private Animation Anim;

	public virtual void Start()
	{
		this.Anim = this.animation;
	}

	public virtual void Update()
	{
		if (Vector3.Distance(this.Yandere.position, this.transform.position) > (float)15)
		{
			this.Anim.enabled = false;
		}
		else
		{
			this.Anim.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
