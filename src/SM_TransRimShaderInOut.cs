using System;
using UnityEngine;

[Serializable]
public class SM_TransRimShaderInOut : MonoBehaviour
{
	public float str;

	public float fadeIn;

	public float stay;

	public float fadeOut;

	private float timeGoes;

	private float currStr;

	public SM_TransRimShaderInOut()
	{
		this.str = (float)1;
		this.fadeIn = (float)1;
		this.stay = (float)1;
		this.fadeOut = (float)1;
	}

	public virtual void Start()
	{
		this.renderer.material.SetFloat("_AllPower", this.currStr);
	}

	public virtual void Update()
	{
		this.timeGoes += Time.deltaTime;
		if (this.timeGoes < this.fadeIn)
		{
			this.currStr = this.timeGoes * this.str * ((float)1 / this.fadeIn);
		}
		if (this.timeGoes > this.fadeIn && this.timeGoes < this.fadeIn + this.stay)
		{
			this.currStr = this.str;
		}
		if (this.timeGoes > this.fadeIn + this.stay)
		{
			this.currStr = this.str - (this.timeGoes - (this.fadeIn + this.stay)) * ((float)1 / this.fadeOut);
		}
		this.renderer.material.SetFloat("_AllPower", this.currStr);
	}

	public virtual void Main()
	{
	}
}
