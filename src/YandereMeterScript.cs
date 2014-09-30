using System;
using UnityEngine;

[Serializable]
public class YandereMeterScript : MonoBehaviour
{
	public UISprite Meter;

	public YandereScript Yandere;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		this.Meter.fillAmount = Mathf.Lerp(this.Meter.fillAmount, this.Yandere.YandereMeter / (float)100, Time.deltaTime * (float)10);
	}

	public virtual void Main()
	{
	}
}
