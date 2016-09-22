using System;
using UnityEngine;

[Serializable]
public class KittenScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Character;

	public string[] AnimationNames;

	public Transform Target;

	public Transform Head;

	public string CurrentAnim;

	public string IdleAnim;

	public bool Wait;

	public float Timer;

	public KittenScript()
	{
		this.CurrentAnim = string.Empty;
		this.IdleAnim = string.Empty;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void PickRandomAnim()
	{
	}

	public virtual void LateUpdate()
	{
		if (!this.Yandere.Aiming)
		{
			if (this.Yandere.Head.transform.position.x < this.transform.position.x)
			{
				this.Target.position = Vector3.Lerp(this.Target.position, this.Yandere.Head.transform.position, Time.deltaTime * (float)5);
			}
			else
			{
				this.Target.position = Vector3.Lerp(this.Target.position, this.transform.position + this.transform.forward * (float)1 + this.transform.up * 0.139854f, Time.deltaTime * (float)5);
			}
			this.Head.transform.LookAt(this.Target);
		}
		else
		{
			this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
		}
	}

	public virtual void Main()
	{
	}
}
