using System;
using UnityEngine;

[Serializable]
public class GloveScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider MyCollider;

	public Projector Blood;

	public virtual void Start()
	{
		YandereScript yandereScript = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		Physics.IgnoreCollision(yandereScript.collider, this.MyCollider);
	}

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.transform.parent = this.Prompt.Yandere.transform;
			this.transform.localPosition = new Vector3((float)0, (float)1, 0.25f);
			this.Prompt.Yandere.Gloves = this;
			this.Prompt.Yandere.WearGloves();
			this.active = false;
		}
		if (this.Prompt.Yandere.Schoolwear == 1)
		{
			this.Prompt.HideButton[0] = false;
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	public virtual void Main()
	{
	}
}
