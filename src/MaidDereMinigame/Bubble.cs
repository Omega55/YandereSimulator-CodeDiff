using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class Bubble : MonoBehaviour
	{
		[HideInInspector]
		public Food food;

		public SpriteRenderer foodRenderer;

		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		public void Pause(bool toPause)
		{
			if (toPause)
			{
				base.GetComponent<SpriteRenderer>().enabled = false;
				this.foodRenderer.gameObject.SetActive(false);
			}
			else
			{
				base.GetComponent<SpriteRenderer>().enabled = true;
				this.foodRenderer.gameObject.SetActive(true);
			}
		}

		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
