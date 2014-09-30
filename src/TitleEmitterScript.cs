using System;
using UnityEngine;

[Serializable]
public class TitleEmitterScript : MonoBehaviour
{
	public Transform Head;

	public virtual void LateUpdate()
	{
		this.transform.position = this.Head.position;
	}

	public virtual void Main()
	{
	}
}
