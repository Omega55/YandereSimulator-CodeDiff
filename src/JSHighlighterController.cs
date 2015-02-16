using System;
using HighlightingSystem;
using UnityEngine;

[Serializable]
public class JSHighlighterController : MonoBehaviour
{
	protected Highlighter h;

	public virtual void Awake()
	{
		this.h = (Highlighter)this.GetComponent(typeof(Highlighter));
		if (this.h == null)
		{
			this.h = (Highlighter)this.gameObject.AddComponent(typeof(Highlighter));
		}
	}

	public virtual void Start()
	{
		this.h.FlashingOn(new Color(1f, 1f, (float)0, (float)0), new Color(1f, 1f, (float)0, 1f), 2f);
	}
}
