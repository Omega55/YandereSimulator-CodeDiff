using System;
using UnityEngine;

[Serializable]
public class ClassTeacherScript : MonoBehaviour
{
	public Transform Spine0;

	public Transform Spine3;

	public virtual void LateUpdate()
	{
		this.Spine0.localScale = new Vector3(0.5f, (float)1, 0.5f);
		this.Spine3.localScale = new Vector3((float)2, (float)1, (float)2);
	}

	public virtual void Main()
	{
	}
}
