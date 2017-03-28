using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MirrorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public string[] Idles;

	public int ID;

	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			this.ID++;
			if (this.ID == Extensions.get_length(this.Idles))
			{
				this.ID = 0;
			}
			this.Prompt.Yandere.IdleAnim = this.Idles[this.ID];
		}
	}

	public virtual void Main()
	{
	}
}
