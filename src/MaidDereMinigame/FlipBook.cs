using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class FlipBook : MonoBehaviour
	{
		private static FlipBook instance;

		public List<FlipBookPage> flipBookPages;

		private int curPage;

		private bool canGoBack;

		private bool stopInputs;

		public static FlipBook Instance
		{
			get
			{
				if (FlipBook.instance == null)
				{
					FlipBook.instance = UnityEngine.Object.FindObjectOfType<FlipBook>();
				}
				return FlipBook.instance;
			}
		}

		private void Awake()
		{
			base.StartCoroutine(this.OpenBook());
		}

		private IEnumerator OpenBook()
		{
			yield return new WaitForSeconds(1f);
			this.FlipToPage(1);
			yield break;
		}

		private void Update()
		{
			if (this.stopInputs)
			{
				return;
			}
			if (this.curPage > 1 && Input.GetButtonDown("B") && this.canGoBack)
			{
				this.FlipToPage(1);
			}
		}

		public void StopInputs()
		{
			this.stopInputs = true;
		}

		public void FlipToPage(int page)
		{
			base.StartCoroutine(this.FlipToPageRoutine(page));
		}

		private IEnumerator FlipToPageRoutine(int page)
		{
			bool forward = this.curPage < page;
			this.canGoBack = false;
			if (forward)
			{
				while (this.curPage < page)
				{
					this.flipBookPages[this.curPage++].Transition(forward);
				}
				yield return new WaitForSeconds(0.4f);
				this.flipBookPages[this.curPage].ObjectActive(true);
			}
			else
			{
				this.flipBookPages[this.curPage].ObjectActive(false);
				while (this.curPage > page)
				{
					this.flipBookPages[--this.curPage].Transition(forward);
				}
				yield return new WaitForSeconds(0.6f);
				this.flipBookPages[this.curPage].ObjectActive(true);
			}
			this.canGoBack = true;
			yield break;
		}
	}
}
