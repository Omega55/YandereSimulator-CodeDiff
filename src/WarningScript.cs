using System;
using UnityEngine;

[Serializable]
public class WarningScript : MonoBehaviour
{
	public UIPanel Panel;

	public bool Display;

	public float Timer;

	public virtual void Start()
	{
		this.Panel.alpha = (float)0;
	}

	public virtual void Update()
	{
		if (!this.Display)
		{
			this.Panel.alpha = this.Panel.alpha - Time.deltaTime;
		}
		else
		{
			this.Panel.alpha = this.Panel.alpha + Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)4)
			{
				this.Display = false;
			}
		}
	}

	public virtual void Warn()
	{
		this.Display = true;
		this.Timer = (float)0;
	}

	public virtual void Main()
	{
	}
}
