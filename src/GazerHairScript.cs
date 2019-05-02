using System;
using UnityEngine;

public class GazerHairScript : MonoBehaviour
{
	public SkinnedMeshRenderer MyMesh;

	public float[] TargetWeight;

	public float[] Weight;

	public float Strength = 100f;

	public int ID;

	private void Update()
	{
		this.ID = 0;
		while (this.ID < this.Weight.Length)
		{
			this.Weight[this.ID] = Mathf.MoveTowards(this.Weight[this.ID], this.TargetWeight[this.ID], Time.deltaTime * this.Strength);
			if (this.Weight[this.ID] == this.TargetWeight[this.ID])
			{
				this.TargetWeight[this.ID] = UnityEngine.Random.Range(0f, 100f);
			}
			this.MyMesh.SetBlendShapeWeight(this.ID, this.Weight[this.ID]);
			this.ID++;
		}
	}
}
