using System;
using UnityEngine;

[Serializable]
public class SenpaiPhotosScript : MonoBehaviour
{
	public int Photos;

	public int Used;

	public int ID;

	public GameObject[] Photo;

	public GameObject[] X;

	public virtual void Start()
	{
		this.UpdatePhotos();
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			this.UpdatePhotos();
		}
	}

	public virtual void UpdatePhotos()
	{
		this.ID = 0;
		while (this.ID < 5)
		{
			if (this.Photos < this.ID + 1)
			{
				this.Photo[this.ID].active = false;
			}
			else
			{
				this.Photo[this.ID].active = true;
			}
			if (this.Used < this.ID + 1)
			{
				this.X[this.ID].active = false;
			}
			else
			{
				this.X[this.ID].active = true;
			}
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
