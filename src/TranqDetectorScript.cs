using System;
using UnityEngine;

[Serializable]
public class TranqDetectorScript : MonoBehaviour
{
	public YandereScript Yandere;

	public TranqCaseScript TranqCase;

	public DoorScript Door;

	public Collider MyCollider;

	public virtual void Update()
	{
		if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
		{
			if (this.Yandere.Follower != null)
			{
				if (this.MyCollider.bounds.Contains(this.Yandere.Follower.transform.position))
				{
					if (!this.Door.Open)
					{
						if (!this.TranqCase.Occupied)
						{
							if (this.Yandere.Armed)
							{
								if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 3)
								{
									if (this.Yandere.PossessTranq && PlayerPrefs.GetInt("BiologyGrade") > 1)
									{
										this.Yandere.CanTranq = true;
										if (this.Yandere.Attacking)
										{
											this.Door.Prompt.enabled = false;
										}
									}
								}
								else
								{
									this.Yandere.CanTranq = false;
								}
							}
							else
							{
								this.Yandere.CanTranq = false;
							}
						}
						else
						{
							this.Yandere.CanTranq = false;
						}
					}
					else
					{
						this.Yandere.CanTranq = false;
					}
				}
				else
				{
					this.Yandere.CanTranq = false;
				}
			}
			else
			{
				this.Yandere.CanTranq = false;
			}
		}
		else
		{
			this.Yandere.CanTranq = false;
		}
	}

	public virtual void Main()
	{
	}
}
