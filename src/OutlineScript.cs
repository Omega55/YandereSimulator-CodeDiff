using System;
using HighlightingSystem;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Highlighter h;

	public Color color = new Color(1f, 1f, 1f, 1f);

	public void Awake()
	{
		this.h = base.GetComponent<Highlighter>();
		if (this.h == null)
		{
			this.h = base.gameObject.AddComponent<Highlighter>();
		}
	}

	private void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}
}
