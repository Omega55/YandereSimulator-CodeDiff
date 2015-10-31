using System;
using UnityEngine;

[Serializable]
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	public Transform[] Fireballs;

	public Transform Dracula;

	public int Direction;

	public float Speed;

	public float Timer;

	public virtual void Start()
	{
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
		if (this.Fireballs[1] != null)
		{
			float y = Mathf.MoveTowards(this.Fireballs[1].position.y, 7.5f, Time.deltaTime * this.Speed);
			Vector3 position = this.Fireballs[1].position;
			float num = position.y = y;
			Vector3 vector = this.Fireballs[1].position = position;
		}
		if (this.Fireballs[2] != null)
		{
			float y2 = Mathf.MoveTowards(this.Fireballs[2].position.y, 7.16666f, Time.deltaTime * this.Speed);
			Vector3 position2 = this.Fireballs[2].position;
			float num2 = position2.y = y2;
			Vector3 vector2 = this.Fireballs[2].position = position2;
		}
		if (this.Fireballs[3] != null)
		{
			float y3 = Mathf.MoveTowards(this.Fireballs[3].position.y, 6.83333f, Time.deltaTime * this.Speed);
			Vector3 position3 = this.Fireballs[3].position;
			float num3 = position3.y = y3;
			Vector3 vector3 = this.Fireballs[3].position = position3;
		}
		for (int i = 1; i < 4; i++)
		{
			if (this.Fireballs[i] != null)
			{
				float x = this.Fireballs[i].position.x + (float)this.Direction * Time.deltaTime * this.Speed;
				Vector3 position4 = this.Fireballs[i].position;
				float num4 = position4.x = x;
				Vector3 vector4 = this.Fireballs[i].position = position4;
			}
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)10)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
