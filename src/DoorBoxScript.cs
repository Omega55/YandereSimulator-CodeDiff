using System;
using UnityEngine;

[Serializable]
public class DoorBoxScript : MonoBehaviour
{
	public UILabel Label;

	public bool Show;

	public virtual void Update()
	{
		if (this.Show)
		{
			float y = Mathf.Lerp(this.transform.localPosition.y, (float)-530, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		else
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, (float)-630, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
		}
	}

	public virtual void Main()
	{
	}
}
