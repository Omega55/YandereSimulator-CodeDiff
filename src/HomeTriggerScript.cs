using System;
using UnityEngine;

[Serializable]
public class HomeTriggerScript : MonoBehaviour
{
	public HomeYandereScript Yandere;

	public GameObject Label;

	public bool Grow;

	public int ID;

	public virtual void Update()
	{
		if (this.Grow)
		{
			this.Label.transform.localScale = Vector3.Lerp(this.Label.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else
		{
			this.Label.transform.localScale = Vector3.Lerp(this.Label.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void OnTriggerEnter()
	{
		this.Yandere.CurrentTrigger = this;
		this.Grow = true;
	}

	public virtual void OnTriggerExit()
	{
		this.Yandere.CurrentTrigger = null;
		this.Grow = false;
	}

	public virtual void Main()
	{
	}
}
