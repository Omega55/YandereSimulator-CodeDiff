using System;
using UnityEngine;

[Serializable]
public class JSHighlightingController : MonoBehaviour
{
	protected HighlightableObject ho;

	public virtual void Awake()
	{
		this.ho = (HighlightableObject)this.gameObject.AddComponent(typeof(HighlightableObject));
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			this.ho.ConstantSwitch();
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			this.ho.ConstantSwitchImmediate();
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			this.ho.Off();
		}
	}

	public virtual void Main()
	{
	}
}
