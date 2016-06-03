using System;
using UnityEngine;

[Serializable]
public class InfoChanWindowScript : MonoBehaviour
{
	public Transform DropPoint;

	public GameObject[] Drops;

	public int[] ItemsToDrop;

	public int Orders;

	public int ID;

	public float Rotation;

	public float Timer;

	public bool Dropped;

	public bool Drop;

	public bool Open;

	public bool Test;

	public InfoChanWindowScript()
	{
		this.Open = true;
	}

	public virtual void Update()
	{
		if (this.Drop)
		{
			if (this.Open)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, (float)-90, Time.deltaTime * (float)10);
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			}
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.transform.localEulerAngles;
			float num = localEulerAngles.y = rotation;
			Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				if (this.Orders > 0)
				{
					UnityEngine.Object.Instantiate(this.Drops[this.ItemsToDrop[this.Orders]], this.DropPoint.position, Quaternion.identity);
					this.Timer = (float)0;
					this.Orders--;
				}
				else
				{
					this.Open = false;
					if (this.Timer > (float)3)
					{
						int num2 = 0;
						Vector3 localEulerAngles2 = this.transform.localEulerAngles;
						float num3 = localEulerAngles2.y = (float)num2;
						Vector3 vector2 = this.transform.localEulerAngles = localEulerAngles2;
						this.Drop = false;
					}
				}
			}
		}
		if (this.Test)
		{
			this.DropObject();
		}
	}

	public virtual void DropObject()
	{
		this.Rotation = (float)0;
		this.Timer = (float)0;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	public virtual void Main()
	{
	}
}
