using System;
using UnityEngine;

[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	public GameObject LastBloodPool;

	public GameObject BloodPool;

	public Transform BloodParent;

	public Transform Hips;

	public Collider MyCollider;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public Vector3[] Positions;

	public bool CanSpawn;

	public int PoolsSpawned;

	public int NearbyBlood;

	public float Height;

	public float Timer;

	public virtual void Start()
	{
		if (Application.loadedLevel != 3)
		{
			this.NEStairs = (Collider)GameObject.Find("NEStairs").GetComponent(typeof(Collider));
			this.NWStairs = (Collider)GameObject.Find("NWStairs").GetComponent(typeof(Collider));
			this.SEStairs = (Collider)GameObject.Find("SEStairs").GetComponent(typeof(Collider));
			this.SWStairs = (Collider)GameObject.Find("SWStairs").GetComponent(typeof(Collider));
		}
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
		if (this.MyCollider.enabled)
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
			if (Application.loadedLevel != 3)
			{
				if (this.NEStairs.bounds.Contains(this.transform.position) || this.NWStairs.bounds.Contains(this.transform.position) || this.SEStairs.bounds.Contains(this.transform.position) || this.SWStairs.bounds.Contains(this.transform.position))
				{
					this.CanSpawn = false;
				}
				else
				{
					this.CanSpawn = true;
				}
			}
			else
			{
				this.CanSpawn = true;
			}
			if (this.CanSpawn && this.transform.position.y < this.Height + 0.33333f)
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

	public virtual void SpawnRow(Transform Location)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 2f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 2.5f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 3f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
	}

	public virtual void Main()
	{
	}
}
