using System;
using UnityEngine;

[Serializable]
public class ExclamationScript : MonoBehaviour
{
	public Renderer Graphic;

	public float Alpha;

	public float Timer;

	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, (float)0));
	}

	public virtual void Update()
	{
		this.Timer -= Time.deltaTime;
		if (this.Timer > (float)0)
		{
			this.transform.LookAt(Camera.main.transform);
			if (this.Timer > 1.5f)
			{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * (float)10);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
			}
			else
			{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				this.Alpha = Mathf.Lerp(this.Alpha, (float)0, Time.deltaTime * (float)10);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
			}
		}
	}

	public virtual void Main()
	{
	}
}
