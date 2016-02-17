using System;
using UnityEngine;

[Serializable]
public class RainbowScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public Color[] Colors;

	public int ID;

	public virtual void Start()
	{
		this.Colors[0] = new Color((float)1, (float)0, (float)0, (float)1);
		this.Colors[1] = new Color((float)1, (float)1, (float)0, (float)1);
		this.Colors[2] = new Color((float)0, (float)1, (float)0, (float)1);
		this.Colors[3] = new Color((float)0, (float)1, (float)1, (float)1);
		this.Colors[4] = new Color((float)0, (float)0, (float)1, (float)1);
		this.Colors[5] = new Color((float)1, (float)0, (float)1, (float)1);
		this.MyRenderer.material.color = this.Colors[0];
	}

	public virtual void Update()
	{
		this.MyRenderer.material.color = Vector4.MoveTowards(this.MyRenderer.material.color, this.Colors[this.ID], Time.deltaTime);
		if (this.MyRenderer.material.color == this.Colors[this.ID])
		{
			this.ID++;
			if (this.ID > this.Colors.Length - 1)
			{
				this.ID = 0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
