using System;
using UnityEngine;

[Serializable]
public class PhoneCharmScript : MonoBehaviour
{
	public virtual void Update()
	{
		int num = 90;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.x = (float)num;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
	}

	public virtual void Main()
	{
	}
}
