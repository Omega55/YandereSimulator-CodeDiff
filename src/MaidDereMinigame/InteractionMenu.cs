using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class InteractionMenu : MonoBehaviour
	{
		public enum AButtonText
		{
			ChoosePlate,
			GrabPlate,
			KitchenMenu,
			PlaceOrder,
			TakeOrder,
			TossPlate,
			GiveFood,
			None
		}

		private static InteractionMenu instance;

		public GameObject interactObject;

		public GameObject backObject;

		public GameObject moveObject;

		public SpriteRenderer[] aButtons;

		public SpriteRenderer[] aButtonSprites;

		public SpriteRenderer[] backButtons;

		public SpriteRenderer[] moveButtons;

		public static InteractionMenu Instance
		{
			get
			{
				if (InteractionMenu.instance == null)
				{
					InteractionMenu.instance = UnityEngine.Object.FindObjectOfType<InteractionMenu>();
				}
				return InteractionMenu.instance;
			}
		}

		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		public static void SetAButton(InteractionMenu.AButtonText text)
		{
			for (int i = 0; i < InteractionMenu.Instance.aButtonSprites.Length; i++)
			{
				if (i == (int)text)
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(true);
				}
				else
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(false);
				}
			}
			foreach (SpriteRenderer spriteRenderer in InteractionMenu.Instance.aButtons)
			{
				spriteRenderer.gameObject.SetActive(text != InteractionMenu.AButtonText.None);
			}
		}

		public static void SetBButton(bool on)
		{
			foreach (SpriteRenderer spriteRenderer in InteractionMenu.Instance.backButtons)
			{
				spriteRenderer.gameObject.SetActive(on);
			}
		}

		public static void SetADButton(bool on)
		{
			foreach (SpriteRenderer spriteRenderer in InteractionMenu.Instance.moveButtons)
			{
				spriteRenderer.gameObject.SetActive(on);
			}
		}
	}
}
