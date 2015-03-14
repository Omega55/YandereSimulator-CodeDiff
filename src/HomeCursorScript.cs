using System;
using UnityEngine;

[Serializable]
public class HomeCursorScript : MonoBehaviour
{
	public GameObject Photograph;

	public Transform Highlight;

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.Photograph)
		{
			int num = 100;
			Vector3 position = this.Highlight.position;
			float num2 = position.y = (float)num;
			Vector3 vector = this.Highlight.position = position;
			this.Photograph = null;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		this.Photograph = other.gameObject;
		this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
		this.Highlight.localPosition = this.Photograph.transform.localPosition;
	}

	public virtual void Main()
	{
	}
}
