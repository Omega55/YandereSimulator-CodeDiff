using System;
using UnityEngine;

[Serializable]
public class ShoeprintSpawnerScript : MonoBehaviour
{
	private GameObject NewShoeprint;

	public GameObject BloodyShoeprint;

	public Transform BloodParent;

	public bool Stepped;

	public bool Bloody;

	public bool LeftFoot;

	public int Steps;

	public virtual void Update()
	{
		if (this.Steps > 0)
		{
			if (!this.Stepped)
			{
				if (this.transform.position.y < 0.05f)
				{
					this.NewShoeprint = (GameObject)UnityEngine.Object.Instantiate(this.BloodyShoeprint, new Vector3(this.transform.position.x, 0.01f, this.transform.position.z), Quaternion.identity);
					this.NewShoeprint.transform.eulerAngles = this.transform.eulerAngles;
					int num = 0;
					Vector3 eulerAngles = this.NewShoeprint.transform.eulerAngles;
					float num2 = eulerAngles.x = (float)num;
					Vector3 vector = this.NewShoeprint.transform.eulerAngles = eulerAngles;
					this.NewShoeprint.transform.parent = this.BloodParent;
					if (this.LeftFoot)
					{
						float x = this.NewShoeprint.transform.localScale.x * (float)-1;
						Vector3 localScale = this.NewShoeprint.transform.localScale;
						float num3 = localScale.x = x;
						Vector3 vector2 = this.NewShoeprint.transform.localScale = localScale;
					}
					this.Stepped = true;
					this.Steps--;
				}
			}
			else if (this.transform.position.y > 0.05f)
			{
				this.Stepped = false;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Blood" && other.name != "BloodyShoeprint(Clone)")
		{
			this.Steps = 10;
		}
	}

	public virtual void Main()
	{
	}
}
