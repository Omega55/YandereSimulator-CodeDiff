using System;
using UnityEngine;

[Serializable]
public class TitleKnifeScript : MonoBehaviour
{
	public TitleSenpaiScript Senpai;

	public GameObject BloodEffect;

	public Transform BloodEffects;

	public virtual void Update()
	{
		if (this.transform.position.y < -0.5f)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodEffect, this.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.BloodEffects;
			this.Senpai.Stabbed();
		}
	}

	public virtual void Main()
	{
	}
}
