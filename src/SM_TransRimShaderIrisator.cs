using System;
using UnityEngine;

[Serializable]
public class SM_TransRimShaderIrisator : MonoBehaviour
{
	public float topStr;

	public float botStr;

	public float minSpeed;

	public float maxSpeed;

	private float speed;

	private float timeGoes;

	private bool timeGoesUp;

	public SM_TransRimShaderIrisator()
	{
		this.topStr = (float)2;
		this.botStr = (float)1;
		this.minSpeed = (float)1;
		this.maxSpeed = (float)1;
		this.timeGoesUp = true;
	}

	public virtual void RandomizeSpeed()
	{
		this.speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}

	public virtual void Start()
	{
		this.timeGoes = this.botStr;
		this.speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}

	public virtual void Update()
	{
		if (this.timeGoes > this.topStr)
		{
			this.timeGoesUp = false;
			this.RandomizeSpeed();
		}
		if (this.timeGoes < this.botStr)
		{
			this.timeGoesUp = true;
			this.RandomizeSpeed();
		}
		if (this.timeGoesUp)
		{
			this.timeGoes += Time.deltaTime * this.speed;
		}
		if (!this.timeGoesUp)
		{
			this.timeGoes -= Time.deltaTime * this.speed;
		}
		float value = this.timeGoes;
		this.renderer.material.SetFloat("_AllPower", value);
	}

	public virtual void Main()
	{
	}
}
