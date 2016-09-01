using System;
using UnityEngine;

[Serializable]
public class KittenScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Character;

	public string[] AnimationNames;

	public Transform Head;

	public string CurrentAnim;

	public string IdleAnim;

	public float Timer;

	public bool Wait;

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
		if (this.Wait)
		{
			if (!this.Yandere.Aiming)
			{
				this.Head.transform.LookAt(this.Yandere.Head);
			}
			else
			{
				this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
			}
		}
	}

	public virtual void Main()
	{
	}
}
