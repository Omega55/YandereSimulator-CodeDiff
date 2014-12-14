using System;
using UnityEngine;

[Serializable]
public class GraphUpdaterScript : MonoBehaviour
{
	public AstarPath Graph;

	public int Frames;

	public virtual void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan();
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	public virtual void Main()
	{
	}
}
