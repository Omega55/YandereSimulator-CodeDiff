using System;
using UnityEngine;

public class DumpScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public IncineratorScript Incinerator;

	public float Timer;

	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
