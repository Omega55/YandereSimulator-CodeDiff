using System;
using UnityEngine;

[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	private GameObject NewBlood;

	public GameObject BloodPool;

	public Transform BloodParent;

	public int NearbyBloodPools;

	public virtual void Start()
	{
		this.BloodParent = GameObject.Find("Blood").transform;
	}

	public virtual void Update()
	{
		if (this.transform.position.y < 0.25f && this.NearbyBloodPools == 0)
		{
			this.NewBlood = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, 0.01f, this.transform.position.z), Quaternion.identity);
			int num = 90;
			Vector3 eulerAngles = this.NewBlood.transform.eulerAngles;
			float num2 = eulerAngles.x = (float)num;
			Vector3 vector = this.NewBlood.transform.eulerAngles = eulerAngles;
			int num3 = UnityEngine.Random.Range(0, 360);
			Vector3 eulerAngles2 = this.NewBlood.transform.eulerAngles;
			float num4 = eulerAngles2.y = (float)num3;
			Vector3 vector2 = this.NewBlood.transform.eulerAngles = eulerAngles2;
			this.NewBlood.transform.parent = this.BloodParent;
		}
		this.transform.eulerAngles = new Vector3((float)0, (float)0, (float)0);
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Blood")
		{
			this.NearbyBloodPools++;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.tag == "Blood")
		{
			this.NearbyBloodPools--;
		}
	}

	public virtual void Main()
	{
	}
}
