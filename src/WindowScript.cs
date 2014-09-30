using System;
using UnityEngine;

[Serializable]
public class WindowScript : MonoBehaviour
{
	public bool Show;

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void Update()
	{
		if (this.Show)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
	}

	public virtual void Main()
	{
	}
}
