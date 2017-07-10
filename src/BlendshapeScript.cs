using System;
using UnityEngine;

public class BlendshapeScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public float Happiness;

	public float Blink;

	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}
}
