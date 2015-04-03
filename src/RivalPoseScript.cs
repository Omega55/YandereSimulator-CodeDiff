using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RivalPoseScript : MonoBehaviour
{
	public GameObject Character;

	public string[] AnimNames;

	public int ID;

	public RivalPoseScript()
	{
		this.ID = -1;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID > Extensions.get_length(this.AnimNames))
			{
				this.ID = 0;
			}
			this.Character.animation.Play(this.AnimNames[this.ID]);
		}
	}

	public virtual void Main()
	{
	}
}
