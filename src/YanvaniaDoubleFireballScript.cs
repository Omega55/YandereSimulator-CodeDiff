using System;
using UnityEngine;

[Serializable]
public class YanvaniaDoubleFireballScript : MonoBehaviour
{
	public GameObject Lavaball;

	public GameObject FirstLavaball;

	public GameObject SecondLavaball;

	public GameObject LightningEffect;

	public Transform Dracula;

	public bool SpawnedFirst;

	public bool SpawnedSecond;

	public float FirstPosition;

	public float SecondPosition;

	public int Direction;

	public float Timer;

	public float Speed;

	public virtual void Start()
	{
		UnityEngine.Object.Instantiate(this.LightningEffect, new Vector3(this.transform.position.x, (float)8, (float)0), Quaternion.identity);
		if (this.Dracula.position.x > this.transform.position.x)
		{
			this.Direction = -1;
		}
		else
		{
			this.Direction = 1;
		}
	}

	public virtual void Update()
	{
		if (this.Timer > (float)1 && !this.SpawnedFirst)
		{
			UnityEngine.Object.Instantiate(this.LightningEffect, new Vector3(this.transform.position.x, (float)7, (float)0), Quaternion.identity);
			this.FirstLavaball = (GameObject)UnityEngine.Object.Instantiate(this.Lavaball, new Vector3(this.transform.position.x, (float)8, (float)0), Quaternion.identity);
			this.FirstLavaball.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			this.SpawnedFirst = true;
		}
		if (this.FirstLavaball != null)
		{
			this.FirstLavaball.transform.localScale = Vector3.Lerp(this.FirstLavaball.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.FirstPosition == (float)0)
			{
				this.FirstPosition += Time.deltaTime;
			}
			else
			{
				this.FirstPosition += this.FirstPosition * this.Speed;
			}
			float x = this.FirstLavaball.transform.position.x + this.FirstPosition * (float)this.Direction;
			Vector3 position = this.FirstLavaball.transform.position;
			float num = position.x = x;
			Vector3 vector = this.FirstLavaball.transform.position = position;
			float z = this.FirstLavaball.transform.eulerAngles.z - this.FirstPosition * (float)this.Direction * (float)36;
			Vector3 eulerAngles = this.FirstLavaball.transform.eulerAngles;
			float num2 = eulerAngles.z = z;
			Vector3 vector2 = this.FirstLavaball.transform.eulerAngles = eulerAngles;
		}
		if (this.Timer > (float)2 && !this.SpawnedSecond)
		{
			this.SecondLavaball = (GameObject)UnityEngine.Object.Instantiate(this.Lavaball, new Vector3(this.transform.position.x, (float)7, (float)0), Quaternion.identity);
			this.SecondLavaball.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			this.SpawnedSecond = true;
		}
		if (this.SecondLavaball != null)
		{
			this.SecondLavaball.transform.localScale = Vector3.Lerp(this.SecondLavaball.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			if (this.SecondPosition == (float)0)
			{
				this.SecondPosition += Time.deltaTime;
			}
			else
			{
				this.SecondPosition += this.SecondPosition * this.Speed;
			}
			float x2 = this.SecondLavaball.transform.position.x + this.SecondPosition * (float)this.Direction;
			Vector3 position2 = this.SecondLavaball.transform.position;
			float num3 = position2.x = x2;
			Vector3 vector3 = this.SecondLavaball.transform.position = position2;
			float z2 = this.SecondLavaball.transform.eulerAngles.z - this.SecondPosition * (float)this.Direction * (float)36;
			Vector3 eulerAngles2 = this.SecondLavaball.transform.eulerAngles;
			float num4 = eulerAngles2.z = z2;
			Vector3 vector4 = this.SecondLavaball.transform.eulerAngles = eulerAngles2;
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)10)
		{
			if (this.FirstLavaball != null)
			{
				UnityEngine.Object.Destroy(this.FirstLavaball);
			}
			if (this.SecondLavaball != null)
			{
				UnityEngine.Object.Destroy(this.SecondLavaball);
			}
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
