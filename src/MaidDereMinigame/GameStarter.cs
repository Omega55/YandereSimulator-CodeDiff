using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class GameStarter : MonoBehaviour
	{
		public List<Sprite> numbers;

		public SpriteRenderer whiteFadeOutPost;

		public Sprite timeUp;

		public TipPage tipPage;

		private AudioSource audioSource;

		private SpriteRenderer spriteRenderer;

		private int timeToStart = 3;

		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		public void SetGameTime(float gameTime)
		{
			if (gameTime > 3f)
			{
				return;
			}
			int index = Mathf.CeilToInt(gameTime);
			switch (index)
			{
			case 1:
			case 2:
			case 3:
				this.spriteRenderer.sprite = this.numbers[index];
				break;
			default:
				this.EndGame();
				break;
			}
		}

		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
		}

		private IEnumerator CountdownToStart()
		{
			yield return new WaitForSeconds(GameController.Instance.activeDifficultyVariables.transitionTime);
			while (this.timeToStart > 0)
			{
				yield return new WaitForSeconds(1f);
				this.timeToStart--;
				this.spriteRenderer.sprite = this.numbers[this.timeToStart];
			}
			yield return new WaitForSeconds(1f);
			GameController.SetPause(false);
			this.spriteRenderer.sprite = null;
			yield break;
		}

		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}
	}
}
