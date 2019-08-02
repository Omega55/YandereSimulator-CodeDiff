using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class FoodInstance : MonoBehaviour
	{
		public Food food;

		public Meter warmthMeter;

		public float timeToCool = 30f;

		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		private float heat;

		private void Start()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.spriteRenderer.sprite = this.food.smallSprite;
			this.heat = this.timeToCool;
		}

		private void Update()
		{
			this.heat -= Time.deltaTime;
			this.warmthMeter.SetFill(this.heat / this.timeToCool);
		}

		public void SetHeat(float newHeat)
		{
			this.heat = newHeat;
		}
	}
}
