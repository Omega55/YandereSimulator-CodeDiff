using System;
using HighlightingSystem;
using UnityEngine;

[Serializable]
public class OutlineScript : MonoBehaviour
{
	public Highlighter h;

	public Color color;

	public OutlineScript()
	{
		this.color = new Color((float)1, (float)1, (float)1, (float)1);
	}

	public virtual void Awake()
	{
		this.h = (Highlighter)this.GetComponent(typeof(Highlighter));
		if (this.h == null)
		{
			this.h = (Highlighter)this.gameObject.AddComponent(typeof(Highlighter));
		}
	}

	public virtual void Update()
	{
		this.h.ConstantOnImmediate(this.color);
	}
}
