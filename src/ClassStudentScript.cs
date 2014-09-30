using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ClassStudentScript : MonoBehaviour
{
	public int CurrentAnim;

	public int HairColor;

	public int Chance;

	public SkinnedMeshRenderer MyRenderer;

	public GameObject Character;

	public Texture[] Textures;

	public bool YandereChan;

	public virtual void Start()
	{
		if (!this.YandereChan)
		{
			this.HairColor = UnityEngine.Random.Range(0, Extensions.get_length(this.Textures) - 1);
			this.MyRenderer.materials[3].mainTexture = this.Textures[this.HairColor];
		}
		else
		{
			this.MyRenderer.materials[3].mainTexture = this.Textures[10];
		}
		this.Chance = UnityEngine.Random.Range(0, 2);
		if (this.Chance == 0)
		{
			this.Character.animation.Play("f02_sit_00");
			this.CurrentAnim = 0;
			this.Character.animation["f02_sit_00"].time = UnityEngine.Random.Range((float)0, this.Character.animation["f02_sit_00"].length);
		}
		else
		{
			this.Character.animation.Play("f02_sit_01");
			this.CurrentAnim = 1;
			this.Character.animation["f02_sit_01"].time = UnityEngine.Random.Range((float)0, this.Character.animation["f02_sit_01"].length);
		}
	}

	public virtual void Update()
	{
		this.Chance = UnityEngine.Random.Range(1, 1001);
		if (this.Chance == 1)
		{
			if (this.CurrentAnim == 0)
			{
				this.Character.animation.CrossFade("f02_sit_01", (float)1);
				this.CurrentAnim = 1;
			}
			else
			{
				this.Character.animation.CrossFade("f02_sit_00", (float)1);
				this.CurrentAnim = 0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
