﻿using System;
using UnityEngine;

public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public Transform SecondBeamParent;

	public Renderer SecondBeam;

	public Renderer FirstBeam;

	public bool InformedDracula;

	public float Timer;

	private void Start()
	{
		this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
		this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
		this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
		this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
	}

	private void Update()
	{
	}
}
