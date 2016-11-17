using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public virtual void Update()
	{
		this.transform.Translate(this.transform.forward * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
