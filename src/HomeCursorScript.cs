using System;
using UnityEngine;

public class HomeCursorScript : MonoBehaviour
{
	public GameObject Photograph;

	public Transform Highlight;

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.Photograph)
		{
			this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
			this.Photograph = null;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.name.Equals("SouthWall"))
		{
			this.Photograph = other.gameObject;
			this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
			this.Highlight.localPosition = this.Photograph.transform.localPosition;
		}
	}
}
