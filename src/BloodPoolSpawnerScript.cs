using System;
using UnityEngine;

[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	public Transform BloodParent;

	public GameObject LastBloodPool;

	public GameObject BloodPool;

	public Transform Hips;

	public Vector3[] Positions;

	public int PoolsSpawned;

	public int NearbyBlood;

	public float Height;

	public float Timer;

	public virtual void Start()
	{
		this.BloodParent = GameObject.Find("BloodParent").transform;
		this.Positions = new Vector3[5];
		this.Positions[1] = new Vector3(0.5f, 0.012f, (float)0);
		this.Positions[2] = new Vector3(-0.5f, 0.012f, (float)0);
		this.Positions[3] = new Vector3((float)0, 0.012f, 0.5f);
		this.Positions[4] = new Vector3((float)0, 0.012f, -0.5f);
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

	public virtual void SpawnBigPool()
	{
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.Hips.position.x, GameObject.Find("YandereChan").transform.position.y, this.Hips.position.z) + this.Positions[i], Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
			gameObject.transform.parent = this.BloodParent;
		}
	}

	public virtual void Main()
	{
	}
}
