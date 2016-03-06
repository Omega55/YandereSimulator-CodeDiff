using System;
using UnityEngine;

[Serializable]
public class ObstacleDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject ControllerX;

	public GameObject KeyboardX;

	public int Obstacles;

	public virtual void Start()
	{
		this.ControllerX.active = false;
		this.KeyboardX.active = false;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 1 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			this.Obstacles++;
			if (this.Yandere.Container != null)
			{
				this.ControllerX.active = true;
				this.KeyboardX.active = true;
			}
			Debug.Log("I am colliding with " + other.name);
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer != 1 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			this.Obstacles--;
			if (this.Obstacles == 0)
			{
				this.ControllerX.active = false;
				this.KeyboardX.active = false;
			}
			Debug.Log("I am no longer colliding with " + other.name);
		}
	}

	public virtual void UpdateX()
	{
		if (this.Obstacles > 0)
		{
			this.ControllerX.active = true;
			this.KeyboardX.active = true;
		}
	}

	public virtual void Main()
	{
	}
}
