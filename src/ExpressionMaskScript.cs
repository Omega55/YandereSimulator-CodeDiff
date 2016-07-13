using System;
using UnityEngine;

[Serializable]
public class ExpressionMaskScript : MonoBehaviour
{
	public Renderer Mask;

	public int ID;

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (this.ID < 3)
			{
				this.ID++;
			}
			else
			{
				this.ID = 0;
			}
			int id = this.ID;
			if (id == 0)
			{
				this.Mask.material.mainTextureOffset = new Vector2((float)0, (float)0);
			}
			else if (id == 1)
			{
				this.Mask.material.mainTextureOffset = new Vector2((float)0, 0.5f);
			}
			else if (id == 2)
			{
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, (float)0);
			}
			else if (id == 3)
			{
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			}
		}
	}

	public virtual void Main()
	{
	}
}
