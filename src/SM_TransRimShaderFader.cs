using System;
using UnityEngine;

[Serializable]
public class SM_TransRimShaderFader : MonoBehaviour
{
	public float startStr;

	public float speed;

	private float timeGoes;

	private float currStr;

	public SM_TransRimShaderFader()
	{
		this.startStr = (float)2;
		this.speed = (float)3;
	}

	public virtual void Update()
	{
		this.timeGoes += Time.deltaTime * this.speed * this.startStr;
		this.currStr = this.startStr - this.timeGoes;
		this.renderer.material.SetFloat("_AllPower", this.currStr);
	}

	public virtual void Main()
	{
	}
}
