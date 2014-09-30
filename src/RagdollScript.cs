using System;
using UnityEngine;

[Serializable]
public class RagdollScript : MonoBehaviour
{
	public BlackScript Black;

	public GameObject Character;

	public Transform Neck;

	public Transform Head;

	public Transform Torso;

	public Transform LeftArm;

	public Transform RightArm;

	public Transform LeftLeg;

	public Transform RightLeg;

	public GameObject HeadObject;

	public GameObject TorsoObject;

	public GameObject LeftArmObject;

	public GameObject RightArmObject;

	public GameObject LeftLegObject;

	public GameObject RightLegObject;

	public int Frames;

	public string AnimName;

	public float AnimTime;

	public RagdollScript()
	{
		this.AnimName = string.Empty;
	}

	public virtual void Start()
	{
		this.Black = (BlackScript)GameObject.Find("ChopUpBlack").GetComponent(typeof(BlackScript));
		if (this.AnimName != string.Empty)
		{
			this.Character.animation.Play(this.AnimName);
			this.Character.animation[this.AnimName].time = this.AnimTime;
			this.Character.animation[this.AnimName].speed = (float)0;
		}
	}

	public virtual void LateUpdate()
	{
		if (this.Frames > 0)
		{
			this.Character.animation.Stop();
		}
		this.Frames++;
	}

	public virtual void ChopUp()
	{
		UnityEngine.Object.Instantiate(this.TorsoObject, this.Torso.position, this.Torso.rotation);
		UnityEngine.Object.Instantiate(this.HeadObject, this.Head.position, this.Head.rotation);
		UnityEngine.Object.Instantiate(this.LeftArmObject, this.LeftArm.position, this.LeftArm.rotation);
		UnityEngine.Object.Instantiate(this.RightArmObject, this.RightArm.position, this.RightArm.rotation);
		UnityEngine.Object.Instantiate(this.LeftLegObject, this.LeftLeg.position, this.LeftLeg.rotation);
		UnityEngine.Object.Instantiate(this.RightLegObject, this.RightLeg.position, this.RightLeg.rotation);
		this.Black.FadeIn = true;
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public virtual void Main()
	{
	}
}
