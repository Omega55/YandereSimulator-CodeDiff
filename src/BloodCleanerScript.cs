using System;
using UnityEngine;

[Serializable]
public class BloodCleanerScript : MonoBehaviour
{
	public Transform BloodParent;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public GameObject Lens;

	public UILabel Label;

	public float Distance;

	public float Blood;

	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(11, 15, true);
	}

	public virtual void Update()
	{
		if (this.Blood < (float)100 && this.BloodParent.childCount > 0)
		{
			this.Pathfinding.target = this.BloodParent.GetChild(0);
			if (this.Pathfinding.target.position.y < (float)4)
			{
				this.Label.text = "1";
			}
			else if (this.Pathfinding.target.position.y < (float)8)
			{
				this.Label.text = "2";
			}
			else if (this.Pathfinding.target.position.y < (float)12)
			{
				this.Label.text = "3";
			}
			else
			{
				this.Label.text = "R";
			}
			if (this.Pathfinding.target != null)
			{
				this.Distance = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.Distance < 0.45f)
				{
					this.Pathfinding.speed = (float)0;
					if (this.BloodParent.GetChild(0).GetComponent("BloodPoolScript") != null)
					{
						float x = this.BloodParent.GetChild(0).localScale.x - Time.deltaTime;
						Vector3 localScale = this.BloodParent.GetChild(0).localScale;
						float num = localScale.x = x;
						Vector3 vector = this.BloodParent.GetChild(0).localScale = localScale;
						float y = this.BloodParent.GetChild(0).localScale.y - Time.deltaTime;
						Vector3 localScale2 = this.BloodParent.GetChild(0).localScale;
						float num2 = localScale2.y = y;
						Vector3 vector2 = this.BloodParent.GetChild(0).localScale = localScale2;
						this.Blood += Time.deltaTime;
						if (this.Blood >= (float)100)
						{
							this.Lens.active = true;
						}
						if (this.BloodParent.GetChild(0).transform.localScale.x < 0.1f)
						{
							UnityEngine.Object.Destroy(this.BloodParent.GetChild(0).gameObject);
						}
					}
					else
					{
						UnityEngine.Object.Destroy(this.BloodParent.GetChild(0).gameObject);
					}
				}
				else
				{
					this.Pathfinding.speed = (float)1;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
