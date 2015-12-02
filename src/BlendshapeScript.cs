using System;
using UnityEngine;

[Serializable]
public class BlendshapeScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public float Happiness;

	public float Blink;

	public virtual void LateUpdate()
	{
		this.Happiness += Time.deltaTime * (float)10;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * (float)10;
		this.MyMesh.SetBlendShapeWeight(8, (float)100);
	}

	public virtual void Main()
	{
	}
}
