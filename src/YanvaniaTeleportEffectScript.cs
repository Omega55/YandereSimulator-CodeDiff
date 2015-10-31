using System;
using UnityEngine;

[Serializable]
public class YanvaniaTeleportEffectScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public Transform SecondBeamParent;

	public Renderer SecondBeam;

	public Renderer FirstBeam;

	public bool InformedDracula;

	public float Timer;

	public virtual void Start()
	{
		int num = 0;
		Color color = this.FirstBeam.material.color;
		float num2 = color.a = (float)num;
		Color color2 = this.FirstBeam.material.color = color;
		int num3 = 0;
		Color color3 = this.SecondBeam.material.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.SecondBeam.material.color = color3;
		int num5 = 0;
		Vector3 localScale = this.FirstBeam.transform.localScale;
		float num6 = localScale.x = (float)num5;
		Vector3 vector = this.FirstBeam.transform.localScale = localScale;
		int num7 = 0;
		Vector3 localScale2 = this.FirstBeam.transform.localScale;
		float num8 = localScale2.z = (float)num7;
		Vector3 vector2 = this.FirstBeam.transform.localScale = localScale2;
		int num9 = 0;
		Vector3 localScale3 = this.SecondBeamParent.transform.localScale;
		float num10 = localScale3.y = (float)num9;
		Vector3 vector3 = this.SecondBeamParent.transform.localScale = localScale3;
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
