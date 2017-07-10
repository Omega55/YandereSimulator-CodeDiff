﻿using System;
using UnityEngine;

public class KittenScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Character;

	public string[] AnimationNames;

	public Transform Target;

	public Transform Head;

	public string CurrentAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public bool Wait;

	public float Timer;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void PickRandomAnim()
	{
	}

	private void LateUpdate()
	{
		if (!this.Yandere.Aiming)
		{
			Vector3 b = (this.Yandere.Head.transform.position.x >= base.transform.position.x) ? (base.transform.position + base.transform.forward + base.transform.up * 0.139854f) : this.Yandere.Head.transform.position;
			this.Target.position = Vector3.Lerp(this.Target.position, b, Time.deltaTime * 5f);
			this.Head.transform.LookAt(this.Target);
		}
		else
		{
			this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
		}
	}
}
