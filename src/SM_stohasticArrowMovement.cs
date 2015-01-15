using System;
using UnityEngine;

[Serializable]
public class SM_stohasticArrowMovement : MonoBehaviour
{
	public float rotSpeed;

	public float rotRandomPlus;

	public float rotTreshold;

	public float changeRotMin;

	public float changeRotMax;

	public float minSpeed;

	public float maxSpeed;

	public float changeSpeedMin;

	public float changeSpeedMax;

	private float speed;

	private float timeGoesX;

	private float timeGoesY;

	private float timeGoesSpeed;

	private float timeToChangeX;

	private float timeToChangeY;

	private float timeToChangeSpeed;

	private bool xDir;

	private bool yDir;

	private float curRotSpeedX;

	private float curRotSpeedY;

	private float lendX;

	private float lendY;

	public SM_stohasticArrowMovement()
	{
		this.rotSpeed = (float)3;
		this.rotRandomPlus = 0.5f;
		this.rotTreshold = (float)50;
		this.changeRotMin = (float)1;
		this.changeRotMax = (float)2;
		this.minSpeed = 0.5f;
		this.maxSpeed = (float)2;
		this.changeSpeedMin = 0.5f;
		this.changeSpeedMax = (float)2;
		this.timeToChangeX = 0.1f;
		this.timeToChangeY = 0.1f;
		this.timeToChangeSpeed = 0.1f;
		this.xDir = true;
		this.yDir = true;
	}

	public virtual void RandomizeSpeed()
	{
		this.speed = UnityEngine.Random.Range(this.minSpeed, this.maxSpeed);
	}

	public virtual void RandomizeXRot()
	{
		float num = UnityEngine.Random.value * this.rotRandomPlus;
		this.curRotSpeedX = this.rotSpeed * num;
	}

	public virtual void RandomizeYRot()
	{
		float num = UnityEngine.Random.value * this.rotRandomPlus;
		this.curRotSpeedY = this.rotSpeed * num;
	}

	public virtual void Start()
	{
		this.RandomizeSpeed();
		if (UnityEngine.Random.value > 0.5f)
		{
			this.xDir = !this.xDir;
		}
		if (UnityEngine.Random.value > 0.5f)
		{
			this.yDir = !this.yDir;
		}
		this.timeToChangeY = UnityEngine.Random.Range(this.changeRotMin, this.changeRotMax);
		this.timeToChangeX = UnityEngine.Random.Range(this.changeRotMin, this.changeRotMax);
		this.timeToChangeSpeed = UnityEngine.Random.Range(this.changeSpeedMin, this.changeSpeedMax);
		this.curRotSpeedX = UnityEngine.Random.Range(this.rotSpeed, this.rotSpeed + this.rotRandomPlus);
		this.curRotSpeedY = UnityEngine.Random.Range(this.rotSpeed, this.rotSpeed + this.rotRandomPlus);
	}

	public virtual void Update()
	{
		if (this.xDir)
		{
			this.lendX += Time.deltaTime * this.curRotSpeedX;
		}
		if (!this.xDir)
		{
			this.lendX -= Time.deltaTime * this.curRotSpeedX;
		}
		if (this.yDir)
		{
			this.lendY += Time.deltaTime * this.curRotSpeedY;
		}
		if (!this.yDir)
		{
			this.lendY -= Time.deltaTime * this.curRotSpeedY;
		}
		if (this.lendX > this.rotTreshold)
		{
			this.lendX = this.rotTreshold;
			this.xDir = !this.xDir;
		}
		if (this.lendX > this.rotTreshold)
		{
			this.lendX = -this.rotTreshold;
			this.xDir = !this.xDir;
		}
		if (this.lendY > this.rotTreshold)
		{
			this.lendY = this.rotTreshold;
			this.yDir = !this.yDir;
		}
		if (this.lendY > this.rotTreshold)
		{
			this.lendY = -this.rotTreshold;
			this.yDir = !this.yDir;
		}
		this.transform.Rotate(this.lendX * Time.deltaTime, this.lendY * Time.deltaTime, (float)0);
		this.transform.Translate((float)0, this.speed * Time.deltaTime, (float)0);
		this.timeGoesX += Time.deltaTime;
		this.timeGoesY += Time.deltaTime;
		this.timeGoesSpeed += Time.deltaTime;
		if (this.timeGoesX > this.timeToChangeX)
		{
			this.xDir = !this.xDir;
			this.timeGoesX -= this.timeGoesX;
			this.timeToChangeX = UnityEngine.Random.Range(this.changeRotMin, this.changeRotMax);
			this.curRotSpeedX = UnityEngine.Random.Range(this.rotSpeed, this.rotSpeed + this.rotRandomPlus);
		}
		if (this.timeGoesY > this.timeToChangeY)
		{
			this.yDir = !this.yDir;
			this.timeGoesY -= this.timeGoesY;
			this.timeToChangeY = UnityEngine.Random.Range(this.changeRotMin, this.changeRotMax);
			this.curRotSpeedY = UnityEngine.Random.Range(this.rotSpeed, this.rotSpeed + this.rotRandomPlus);
		}
		if (this.timeGoesSpeed > this.timeToChangeSpeed)
		{
			this.RandomizeSpeed();
			this.timeGoesSpeed -= this.timeGoesSpeed;
			this.timeToChangeSpeed = UnityEngine.Random.Range(this.changeSpeedMin, this.changeSpeedMax);
			Debug.Log("hejj");
		}
	}

	public virtual void Main()
	{
	}
}
