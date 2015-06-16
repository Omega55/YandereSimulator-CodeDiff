using System;
using UnityEngine;

[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	public Transform Target;

	public UITexture Tex;

	public virtual void Start()
	{
		this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3((float)1, (float)0, (float)1);
		this.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		int num = 0;
		Color color = this.Tex.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Tex.color = color;
	}

	public virtual void Update()
	{
		if (this.Tex.color.a > (float)0)
		{
			this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
		}
	}

	public virtual void Main()
	{
	}
}
