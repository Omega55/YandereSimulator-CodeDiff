using System;
using UnityEngine;

public class ExpressionMaskScript : MonoBehaviour
{
	public Renderer Mask;

	public int ID;

	private void Update()
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
			switch (this.ID)
			{
			case 0:
				this.Mask.material.mainTextureOffset = Vector2.zero;
				break;
			case 1:
				this.Mask.material.mainTextureOffset = new Vector2(0f, 0.5f);
				break;
			case 2:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0f);
				break;
			case 3:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
				break;
			}
		}
	}
}
