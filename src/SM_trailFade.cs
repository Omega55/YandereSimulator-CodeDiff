using System;
using UnityEngine;

[Serializable]
public class SM_trailFade : MonoBehaviour
{
	public float fadeInTime;

	public float stayTime;

	public float fadeOutTime;

	public TrailRenderer thisTrail;

	private float timeElapsed;

	private float timeElapsedLast;

	private float percent;

	public SM_trailFade()
	{
		this.fadeInTime = 0.1f;
		this.stayTime = (float)1;
		this.fadeOutTime = 0.7f;
	}

	public virtual void Start()
	{
		this.thisTrail.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, (float)1));
		if (this.fadeInTime < 0.01f)
		{
			this.fadeInTime = 0.01f;
		}
		this.percent = this.timeElapsed / this.fadeInTime;
	}

	public virtual void Update()
	{
		this.timeElapsed += Time.deltaTime;
		if (this.timeElapsed <= this.fadeInTime)
		{
			this.percent = this.timeElapsed / this.fadeInTime;
			this.thisTrail.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.percent));
		}
		if (this.timeElapsed > this.fadeInTime && this.timeElapsed < this.fadeInTime + this.stayTime)
		{
			this.thisTrail.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, (float)1));
		}
		if (this.timeElapsed >= this.fadeInTime + this.stayTime && this.timeElapsed < this.fadeInTime + this.stayTime + this.fadeOutTime)
		{
			this.timeElapsedLast += Time.deltaTime;
			this.percent = (float)1 - this.timeElapsedLast / this.fadeOutTime;
			this.thisTrail.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.percent));
		}
	}

	public virtual void Main()
	{
	}
}
