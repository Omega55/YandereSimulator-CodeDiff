using System;
using UnityEngine;

[Serializable]
public class TitleBookBagScript : MonoBehaviour
{
	public virtual void LateUpdate()
	{
		this.transform.LookAt(this.transform.position + Vector3.down * (float)10);
	}

	public virtual void Main()
	{
	}
}
