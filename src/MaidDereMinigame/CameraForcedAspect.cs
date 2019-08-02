using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		public Vector2 targetAspect = new Vector2(16f, 9f);

		private Camera cam;

		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		private void Start()
		{
			float num = this.targetAspect.x / this.targetAspect.y;
			float num2 = (float)Screen.width / (float)Screen.height;
			float num3 = num2 / num;
			if (num3 < 1f)
			{
				Rect rect = this.cam.rect;
				rect.width = 1f;
				rect.height = num3;
				rect.x = 0f;
				rect.y = (1f - num3) / 2f;
				this.cam.rect = rect;
			}
			else
			{
				Rect rect2 = this.cam.rect;
				float num4 = 1f / num3;
				rect2.width = num4;
				rect2.height = 1f;
				rect2.x = (1f - num4) / 2f;
				rect2.y = 0f;
				this.cam.rect = rect2;
			}
		}
	}
}
