using System;
using UnityEngine;

public class ConstantRandomRotation : MonoBehaviour
{
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
