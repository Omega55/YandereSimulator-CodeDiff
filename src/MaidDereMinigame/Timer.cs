using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class Timer : Meter
	{
		private GameStarter starter;

		private float gameTime;

		private bool isPaused;

		private void Awake()
		{
			this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			this.starter = Object.FindObjectOfType<GameStarter>();
			this.isPaused = true;
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			this.gameTime -= Time.deltaTime;
			base.SetFill(this.gameTime / GameController.Instance.activeDifficultyVariables.gameTime);
			this.starter.SetGameTime(this.gameTime);
		}
	}
}
