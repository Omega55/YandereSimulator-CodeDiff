using System;
using UnityEngine;

[Serializable]
public class NurseScript : MonoBehaviour
{
	public GameObject Character;

	public Transform SkirtCenter;

	public virtual void LateUpdate()
	{
		int num = -15;
		Vector3 localEulerAngles = this.SkirtCenter.localEulerAngles;
		float num2 = localEulerAngles.x = (float)num;
		Vector3 vector = this.SkirtCenter.localEulerAngles = localEulerAngles;
	}

	public virtual void Main()
	{
		this.Character.animation["f02_noBlink_00"].layer = 1;
		this.Character.animation.Blend("f02_noBlink_00");
	}
}
