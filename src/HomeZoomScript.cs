using System;
using UnityEngine;

[Serializable]
public class HomeZoomScript : MonoBehaviour
{
	public Transform YandereDestination;

	public bool Zoom;

	public virtual void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			if (!this.Zoom)
			{
				this.Zoom = true;
				this.audio.Play();
			}
			else
			{
				this.Zoom = false;
			}
		}
		if (this.Zoom)
		{
			float y = Mathf.MoveTowards(this.transform.localPosition.y, 1.5f, Time.deltaTime * 0.033333f);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
			this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-1.5f, 1.5f, (float)1), Time.deltaTime * 0.033333f);
			this.audio.volume = this.audio.volume + Time.deltaTime * 0.01f;
		}
		else
		{
			float y2 = Mathf.MoveTowards(this.transform.localPosition.y, (float)1, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
			this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-2.271312f, (float)2, 3.5f), Time.deltaTime * (float)10);
			this.audio.volume = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
