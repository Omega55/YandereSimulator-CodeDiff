using System;
using UnityEngine;

[Serializable]
public class ClothingScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject FoldedUniform;

	public bool CanPickUp;

	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	public virtual void Update()
	{
		if (this.CanPickUp)
		{
			if (this.Yandere.Bloodiness == (float)0)
			{
				this.CanPickUp = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Yandere.Bloodiness > (float)0)
		{
			this.CanPickUp = true;
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Yandere.Bloodiness = (float)0;
			this.Prompt.Yandere.UpdateBlood();
			UnityEngine.Object.Instantiate(this.FoldedUniform, this.transform.position + Vector3.up * (float)1, Quaternion.identity);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
