using System;
using UnityEngine;

[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	public Transform BloodParent;

	public GameObject LastBloodPool;

	public GameObject BloodPool;

	public int PoolsSpawned;

	public int NearbyBlood;

	public float Height;

	public float Timer;

	public virtual void Start()
	{
		this.BloodParent = GameObject.Find("BloodParent").transform;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.LastBloodPool = other.gameObject;
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
		if (this.Timer > (float)0)
		{
			this.Timer -= Time.deltaTime;
		}
		if (this.transform.position.y < (float)4)
		{
			this.Height = (float)0;
		}
		else if (this.transform.position.y < (float)8)
		{
			this.Height = (float)4;
		}
		else if (this.transform.position.y < (float)12)
		{
			this.Height = (float)8;
		}
		else
		{
			this.Height = (float)12;
		}
		if (this.transform.position.y < this.Height + 0.33333f)
		{
			if (this.NearbyBlood > 0 && this.LastBloodPool == null)
			{
				this.NearbyBlood--;
			}
			if (this.NearbyBlood < 1 && this.Timer <= (float)0)
			{
				this.Timer = 0.1f;
				if (this.PoolsSpawned < 10)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
					gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
					gameObject.transform.parent = this.BloodParent;
					this.PoolsSpawned++;
				}
				else if (this.PoolsSpawned < 20)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
					gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
					gameObject.transform.parent = this.BloodParent;
					this.PoolsSpawned++;
					((BloodPoolScript)gameObject.GetComponent(typeof(BloodPoolScript))).TargetSize = (float)1 - (float)(this.PoolsSpawned - 10) * 0.1f;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
