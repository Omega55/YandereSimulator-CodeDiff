using System;
using UnityEngine;

public class GraphUpdaterScript : MonoBehaviour
{
	public AstarPath Graph;

	public int Frames;

	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}
}
