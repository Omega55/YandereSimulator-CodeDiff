﻿using System;
using UnityEngine;

public class AboutScript : MonoBehaviour
{
	public Transform[] Labels;

	public bool[] SlideOut;

	public bool[] SlideIn;

	public UILabel LinkLabel;

	public UITexture Yuno1;

	public UITexture Yuno2;

	public int SlideID;

	public int ID;

	public float Timer;

	private void Start()
	{
		foreach (Transform transform in this.Labels)
		{
			Vector3 localPosition = transform.localPosition;
			localPosition.x = 2000f;
			transform.localPosition = localPosition;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.SlideID < this.Labels.Length)
			{
				this.SlideIn[this.SlideID] = true;
			}
			this.SlideID++;
		}
		if (this.SlideID < this.Labels.Length + 1)
		{
			this.ID = 0;
			while (this.ID < this.Labels.Length)
			{
				if (this.SlideIn[this.ID])
				{
					Transform transform = this.Labels[this.ID];
					Vector3 localPosition = transform.localPosition;
					localPosition.x = Mathf.Lerp(localPosition.x, 0f, Time.deltaTime);
					transform.localPosition = localPosition;
				}
				this.ID++;
			}
			return;
		}
		this.Timer += Time.deltaTime * 10f;
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			if (this.Timer > (float)this.ID)
			{
				this.SlideOut[this.ID] = true;
				Transform transform2 = this.Labels[this.ID];
				Vector3 localPosition2 = transform2.localPosition;
				if (localPosition2.x > 0f)
				{
					localPosition2.x = -0.1f;
					transform2.localPosition = localPosition2;
				}
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			if (this.SlideOut[this.ID])
			{
				Transform transform3 = this.Labels[this.ID];
				Vector3 localPosition3 = transform3.localPosition;
				localPosition3.x += localPosition3.x * 0.01f;
				transform3.localPosition = localPosition3;
			}
			this.ID++;
		}
		if (this.SlideID > this.Labels.Length + 1)
		{
			Color color = this.LinkLabel.color;
			color.a += Time.deltaTime;
			this.LinkLabel.color = color;
		}
		if (this.SlideID > this.Labels.Length + 2)
		{
			Color color2 = this.Yuno1.color;
			color2.a += Time.deltaTime;
			this.Yuno1.color = color2;
		}
		if (this.SlideID > this.Labels.Length + 3)
		{
			Color color3 = this.Yuno2.color;
			color3.a += Time.deltaTime;
			this.Yuno2.color = color3;
			Vector3 localScale = this.Yuno2.transform.localScale;
			localScale.x += Time.deltaTime * 0.1f;
			localScale.y += Time.deltaTime * 0.1f;
			this.Yuno2.transform.localScale = localScale;
		}
	}
}
