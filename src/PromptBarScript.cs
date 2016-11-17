using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PromptBarScript : MonoBehaviour
{
	public UISprite[] Button;

	public UILabel[] Label;

	public UIPanel Panel;

	public bool Show;

	public int ID;

	public virtual void Start()
	{
		int num = -627;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
		while (this.ID < Extensions.get_length(this.Label))
		{
			this.Label[this.ID].text = string.Empty;
			this.ID++;
		}
		this.UpdateButtons();
	}

	public virtual void Update()
	{
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				float y = Mathf.Lerp(this.transform.localPosition.y, (float)-628, 0.166666672f);
				Vector3 localPosition = this.transform.localPosition;
				float num = localPosition.y = y;
				Vector3 vector = this.transform.localPosition = localPosition;
				if (this.transform.localPosition.y < (float)-627)
				{
					int num2 = -628;
					Vector3 localPosition2 = this.transform.localPosition;
					float num3 = localPosition2.y = (float)num2;
					Vector3 vector2 = this.transform.localPosition = localPosition2;
					if (this.Panel != null)
					{
						this.Panel.enabled = false;
					}
				}
			}
		}
		else
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, (float)-527, 0.166666672f);
			Vector3 localPosition3 = this.transform.localPosition;
			float num4 = localPosition3.y = y2;
			Vector3 vector3 = this.transform.localPosition = localPosition3;
		}
	}

	public virtual void UpdateButtons()
	{
		if (this.Panel != null)
		{
			this.Panel.enabled = true;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Label))
		{
			if (this.Label[this.ID].text == string.Empty)
			{
				this.Button[this.ID].enabled = false;
			}
			else
			{
				this.Button[this.ID].enabled = true;
			}
			this.ID++;
		}
	}

	public virtual void ClearButtons()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Label))
		{
			this.Label[this.ID].text = string.Empty;
			this.Button[this.ID].enabled = false;
			this.ID++;
		}
	}

	public virtual void Main()
	{
	}
}
