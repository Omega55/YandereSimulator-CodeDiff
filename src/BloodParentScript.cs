using System;
using UnityEngine;

public class BloodParentScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Bloodpool;

	public GameObject Footprint;

	public Vector3[] FootprintPositions;

	public Vector3[] BloodPositions;

	public Vector3[] FootprintRotations;

	public Vector3[] BloodRotations;

	public float[] BloodSizes;

	public int FootprintID;

	public int PoolID;

	public void RecordAllBlood()
	{
		this.PoolID = 0;
		this.FootprintID = 0;
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			BloodPoolScript component = transform.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				this.PoolID++;
				if (this.PoolID < 100)
				{
					this.BloodPositions[this.PoolID] = transform.position;
					this.BloodRotations[this.PoolID] = transform.eulerAngles;
					this.BloodSizes[this.PoolID] = component.TargetSize;
				}
			}
			else
			{
				this.FootprintID++;
				if (this.FootprintID < 100)
				{
					this.FootprintPositions[this.FootprintID] = transform.position;
					this.FootprintRotations[this.FootprintID] = transform.eulerAngles;
				}
			}
		}
	}

	public void RestoreAllBlood()
	{
		while (this.PoolID > 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Bloodpool, this.BloodPositions[this.PoolID], Quaternion.identity);
			gameObject.GetComponent<BloodPoolScript>().TargetSize = this.BloodSizes[this.PoolID];
			gameObject.transform.eulerAngles = this.BloodRotations[this.PoolID];
			gameObject.transform.parent = base.transform;
			this.PoolID--;
		}
		while (this.FootprintID > 0)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Footprint, this.FootprintPositions[this.FootprintID], Quaternion.identity);
			gameObject2.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
			gameObject2.transform.eulerAngles = this.FootprintRotations[this.FootprintID];
			gameObject2.transform.parent = base.transform;
			this.FootprintID--;
		}
	}
}
