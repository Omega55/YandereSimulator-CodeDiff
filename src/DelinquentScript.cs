using System;
using UnityEngine;

[Serializable]
public class DelinquentScript : MonoBehaviour
{
	public virtual void Main()
	{
		this.animation["f02_angryFace_00"].layer = 1;
		this.animation.Play("f02_angryFace_00");
	}
}
