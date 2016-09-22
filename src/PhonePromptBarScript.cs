using System;
using UnityEngine;

[Serializable]
public class PhonePromptBarScript : MonoBehaviour
{
	public bool Show;

	public virtual void Start()
	{
		int num = 630;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			if (this.transform.localPosition.y < (float)630)
			{
				float y = Mathf.Lerp(this.transform.localPosition.y, (float)631, 0.166666672f);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.y = y;
				Vector3 vector = this.transform.localPosition = localPosition;
			}
		}
		else
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, (float)530, 0.166666672f);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
		}
	}

	public virtual void Main()
	{
	}
}
