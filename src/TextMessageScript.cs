﻿using System;
using UnityEngine;

[Serializable]
public class TextMessageScript : MonoBehaviour
{
	public UILabel Label;

	public GameObject Image;

	public bool Attachment;

	public virtual void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.active = false;
		}
	}

	public virtual void Update()
	{
		this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
	}

	public virtual void Main()
	{
	}
}
