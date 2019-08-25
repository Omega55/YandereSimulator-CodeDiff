using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class Menu : MonoBehaviour
	{
		public List<MenuButton> mainMenuButtons;

		[HideInInspector]
		public FlipBook flipBook;

		private MenuButton activeMenuButton;

		private bool prevVertical;

		private bool cancelInputs;

		private float PreviousFrameVertical;

		private void Start()
		{
			for (int i = 0; i < this.mainMenuButtons.Count; i++)
			{
				int index = i;
				this.mainMenuButtons[i].Init();
				this.mainMenuButtons[i].index = index;
				this.mainMenuButtons[i].spriteRenderer.enabled = false;
				this.mainMenuButtons[i].menu = this;
			}
			this.flipBook = FlipBook.Instance;
			this.SetActiveMenuButton(0);
		}

		private void Update()
		{
			if (this.cancelInputs)
			{
				return;
			}
			if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("A")) && this.activeMenuButton != null)
			{
				this.activeMenuButton.DoClick();
			}
			float num = Input.GetAxisRaw("Vertical") * -1f;
			if (Input.GetKeyDown("up") || Input.GetAxis("DpadY") > 0.5f)
			{
				num = -1f;
			}
			else if (Input.GetKeyDown("down") || Input.GetAxis("DpadY") < -0.5f)
			{
				num = 1f;
			}
			if (num != 0f && this.PreviousFrameVertical == 0f)
			{
				SFXController.PlaySound(SFXController.Sounds.MenuSelect);
			}
			this.PreviousFrameVertical = num;
			if (num != 0f)
			{
				if (!this.prevVertical)
				{
					this.prevVertical = true;
					if (num < 0f)
					{
						int num2 = this.mainMenuButtons.IndexOf(this.activeMenuButton);
						if (num2 == 0)
						{
							this.SetActiveMenuButton(this.mainMenuButtons.Count - 1);
						}
						else
						{
							this.SetActiveMenuButton(num2 - 1);
						}
					}
					else
					{
						int num3 = this.mainMenuButtons.IndexOf(this.activeMenuButton);
						this.SetActiveMenuButton((num3 + 1) % this.mainMenuButtons.Count);
					}
				}
			}
			else
			{
				this.prevVertical = false;
			}
		}

		public void SetActiveMenuButton(int index)
		{
			if (this.activeMenuButton != null)
			{
				this.activeMenuButton.spriteRenderer.enabled = false;
			}
			this.activeMenuButton = this.mainMenuButtons[index];
			this.activeMenuButton.spriteRenderer.enabled = true;
		}

		public void StopInputs()
		{
			this.cancelInputs = true;
			this.flipBook.StopInputs();
		}
	}
}
