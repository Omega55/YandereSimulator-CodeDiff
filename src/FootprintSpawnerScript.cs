using System;
using UnityEngine;

[Serializable]
public class FootprintSpawnerScript : MonoBehaviour
{
	public GameObject BloodyFootprint;

	public Transform BloodParent;

	public Transform Yandere;

	public bool LeftFoot;

	public bool FootUp;

	public float Threshold;

	public float Height;

	public int Bloodiness;

	public virtual void Update()
	{
		if (!this.FootUp)
		{
			if (this.transform.position.y > this.Yandere.transform.position.y + 0.1f)
			{
				this.FootUp = true;
			}
		}
		else if (this.transform.position.y < this.Yandere.transform.position.y + this.Threshold)
		{
			this.FootUp = false;
			if (this.Bloodiness > 0)
			{
				if (this.transform.position.y > (float)-1 && this.transform.position.y < (float)1)
				{
					this.Height = (float)0;
				}
				else if (this.transform.position.y > (float)3 && this.transform.position.y < (float)5)
				{
					this.Height = (float)4;
				}
				else if (this.transform.position.y > (float)7 && this.transform.position.y < (float)9)
				{
					this.Height = (float)8;
				}
				else if (this.transform.position.y > (float)11 && this.transform.position.y < (float)13)
				{
					this.Height = (float)12;
				}
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodyFootprint, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
				float y = this.transform.eulerAngles.y;
				Vector3 eulerAngles = gameObject.transform.eulerAngles;
				float num = eulerAngles.y = y;
				Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
				gameObject.transform.parent = this.BloodParent;
				if (this.LeftFoot)
				{
					int num2 = -1;
					Vector3 localScale = gameObject.transform.localScale;
					float num3 = localScale.x = (float)num2;
					Vector3 vector2 = gameObject.transform.localScale = localScale;
				}
				this.Bloodiness--;
			}
		}
	}

	public virtual void Main()
	{
	}
}
