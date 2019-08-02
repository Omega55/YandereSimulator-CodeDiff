using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class FlipBookPage : MonoBehaviour
	{
		[HideInInspector]
		public Animator animator;

		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		public GameObject objectToActivate;

		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		public void Transition(bool toOpen)
		{
			this.animator.SetTrigger((!toOpen) ? "ClosePage" : "OpenPage");
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(false);
			}
		}

		public void SwitchSort()
		{
			this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;
		}

		public void ObjectActive(bool toActive = true)
		{
			if (this.objectToActivate != null)
			{
				this.objectToActivate.SetActive(toActive);
			}
		}
	}
}
