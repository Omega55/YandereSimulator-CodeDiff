using System;
using UnityEngine;

[Serializable]
public class SM_materialColorRandomizer : MonoBehaviour
{
	public Color color1;

	public Color color2;

	public bool unifiedColor;

	private float ColR;

	private float ColG;

	private float ColB;

	private float ColA;

	public SM_materialColorRandomizer()
	{
		this.color1 = new Color(0.6f, 0.6f, 0.6f, (float)1);
		this.color2 = new Color(0.4f, 0.4f, 0.4f, (float)1);
		this.unifiedColor = true;
	}

	public virtual void Start()
	{
		if (!this.unifiedColor)
		{
			this.ColR = UnityEngine.Random.Range(this.color1.r, this.color2.r);
			this.ColG = UnityEngine.Random.Range(this.color1.g, this.color2.g);
			this.ColB = UnityEngine.Random.Range(this.color1.b, this.color2.b);
			this.ColA = UnityEngine.Random.Range(this.color1.a, this.color2.a);
		}
		if (this.unifiedColor)
		{
			float value = UnityEngine.Random.value;
			this.ColR = Mathf.Min(this.color1.r, this.color2.r) + Mathf.Abs(this.color1.r - this.color2.r) * value;
			this.ColG = Mathf.Min(this.color1.g, this.color2.g) + Mathf.Abs(this.color1.g - this.color2.g) * value;
			this.ColB = Mathf.Min(this.color1.b, this.color2.b) + Mathf.Abs(this.color1.b - this.color2.b) * value;
		}
		this.renderer.material.color = new Color(this.ColR, this.ColG, this.ColB, this.ColA);
	}

	public virtual void Main()
	{
	}
}
