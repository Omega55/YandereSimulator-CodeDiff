using System;
using UnityEngine;

[Serializable]
public class ColoredOutlineScript : MonoBehaviour
{
	protected HighlightableObject ho;

	public Color color;

	public ColoredOutlineScript()
	{
		this.color = Color.white;
	}

	public virtual void Awake()
	{
		this.ho = (HighlightableObject)this.gameObject.AddComponent(typeof(HighlightableObject));
	}

	public virtual void Update()
	{
		this.ho.ConstantOnImmediate(this.color);
	}

	public virtual void Main()
	{
	}
}
