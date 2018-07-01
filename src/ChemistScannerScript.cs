using System;
using UnityEngine;

public class ChemistScannerScript : MonoBehaviour
{
	public StudentScript Student;

	public Renderer MyRenderer;

	public Texture AlarmedEyes;

	public Texture DeadEyes;

	public Texture[] Textures;

	public float Timer;

	public int PreviousID;

	public int ID;

	private void Update()
	{
		if (this.Student.Ragdoll.enabled)
		{
			this.MyRenderer.materials[1].mainTexture = this.DeadEyes;
			base.enabled = false;
		}
		else if (this.Student.WitnessedMurder || this.Student.WitnessedCorpse)
		{
			if (this.MyRenderer.materials[1].mainTexture != this.AlarmedEyes)
			{
				this.MyRenderer.materials[1].mainTexture = this.AlarmedEyes;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 2f)
			{
				while (this.ID == this.PreviousID)
				{
					this.ID = UnityEngine.Random.Range(0, this.Textures.Length);
				}
				this.MyRenderer.materials[1].mainTexture = this.Textures[this.ID];
				this.PreviousID = this.ID;
				this.Timer = 0f;
			}
		}
	}
}
