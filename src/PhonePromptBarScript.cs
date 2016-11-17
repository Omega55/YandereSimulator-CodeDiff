using System;
using UnityEngine;

[Serializable]
public class PhonePromptBarScript : MonoBehaviour
{
	public UIPanel Panel;

	public bool Show;

	public virtual void Start()
	{
		int num = 630;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
		this.Panel.enabled = false;
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				float y = Mathf.Lerp(this.transform.localPosition.y, (float)631, 0.166666672f);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.y = y;
				Vector3 vector = this.transform.localPosition = localPosition;
				if (this.transform.localPosition.y < (float)630)
				{
					int num2 = 631;
					Vector3 localPosition2 = this.transform.localPosition;
					float num3 = localPosition2.y = (float)num2;
					Vector3 vector2 = this.transform.localPosition = localPosition2;
					this.Panel.enabled = false;
				}
			}
		}
		else
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, (float)530, 0.166666672f);
			Vector3 localPosition3 = this.transform.localPosition;
			float num4 = localPosition3.y = y2;
			Vector3 vector3 = this.transform.localPosition = localPosition3;
		}
	}

	public virtual void Main()
	{
	}
}
