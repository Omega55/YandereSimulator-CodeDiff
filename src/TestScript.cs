using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public Mesh Schoolwear;

	public Mesh BaldNude;

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (this.MyRenderer.sharedMesh == this.Schoolwear)
			{
				this.MyRenderer.sharedMesh = this.BaldNude;
			}
			else
			{
				this.MyRenderer.sharedMesh = this.Schoolwear;
			}
		}
	}

	public virtual void Main()
	{
	}
}
