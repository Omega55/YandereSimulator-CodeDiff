using System;
using UnityEngine;

[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	public Transform BloodParent;

	public GameObject BloodPool;

	public int NearbyBlood;

	public virtual void Start()
	{
		this.BloodParent = GameObject.Find("Blood").transform;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood++;
		}
	}

	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood--;
		}
	}

	public virtual void Update()
	{
		this.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
		if (this.transform.position.y < 0.33333f && this.NearbyBlood < 1)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, 0.012f, this.transform.position.z), Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
			gameObject.transform.parent = this.BloodParent;
		}
	}

	public virtual void Main()
	{
	}
}
