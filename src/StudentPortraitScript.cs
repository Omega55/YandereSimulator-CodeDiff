using System;
using UnityEngine;

[Serializable]
public class StudentPortraitScript : MonoBehaviour
{
	public GameObject DeathShadow;

	public GameObject PrisonBars;

	public GameObject Panties;

	public GameObject Friend;

	public UITexture Portrait;

	public virtual void Start()
	{
		this.DeathShadow.active = false;
		this.PrisonBars.active = false;
		this.Panties.active = false;
		this.Friend.active = false;
	}

	public virtual void Main()
	{
	}
}
