using System;
using UnityEngine;

[Serializable]
public class BucketScript : MonoBehaviour
{
	public YandereScript Yandere;

	public float Distance;

	public RaycastHit hit;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		this.Distance = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
		if (this.Distance < (float)1)
		{
			if (this.Yandere.Bucket == null)
			{
				if (this.transform.position.y > this.Yandere.transform.position.y - 0.1f && this.transform.position.y < this.Yandere.transform.position.y + 0.1f && Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out this.hit) && this.hit.collider.gameObject == this.Yandere.gameObject)
				{
					this.Yandere.Bucket = this;
				}
			}
			else
			{
				if (Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up * (float)1, out this.hit) && this.hit.collider.gameObject != this.Yandere.gameObject)
				{
					this.Yandere.Bucket = null;
				}
				if (this.transform.position.y < this.Yandere.transform.position.y - 0.1f || this.transform.position.y > this.Yandere.transform.position.y + 0.1f)
				{
					this.Yandere.Bucket = null;
				}
			}
		}
		else if (this.Yandere.Bucket == this)
		{
			this.Yandere.Bucket = null;
		}
		if (this.Yandere.Bucket == this && this.Yandere.Dipping)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.55f, Time.deltaTime * (float)10);
			Quaternion to = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, Time.deltaTime * (float)10);
		}
	}

	public virtual void Main()
	{
	}
}
