using System;
using UnityEngine;

[Serializable]
public class TestScript : MonoBehaviour
{
	public int Phase;

	public float Timer;

	public TestScript()
	{
		this.Phase = 1;
	}

	public virtual void Update()
	{
		if (this.Phase < 3)
		{
			this.transform.Translate(this.transform.right * Time.deltaTime);
		}
		if (this.Phase == 1)
		{
			if (Input.GetKeyDown("space"))
			{
				this.animation.CrossFade("Trip");
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				this.Phase++;
			}
		}
	}

	public virtual void Main()
	{
	}
}
