using System;
using UnityEngine;

[Serializable]
public class SM_UVScroller : MonoBehaviour
{
	public int targetMaterialSlot;

	public float speedY;

	public float speedX;

	private float timeWentX;

	private float timeWentY;

	public SM_UVScroller()
	{
		this.speedY = 0.5f;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		this.timeWentY += Time.deltaTime * this.speedY;
		this.timeWentX += Time.deltaTime * this.speedX;
		this.renderer.materials[this.targetMaterialSlot].SetTextureOffset("_MainTex", new Vector2(this.timeWentX, this.timeWentY));
	}

	public virtual void Main()
	{
	}
}
