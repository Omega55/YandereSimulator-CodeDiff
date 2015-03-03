using System;
using UnityEngine;

[Serializable]
public class DumpScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyRenderer;

	public IncineratorScript Incinerator;

	public float Timer;

	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)5)
		{
			this.Incinerator.Corpses = this.Incinerator.Corpses + 1;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
