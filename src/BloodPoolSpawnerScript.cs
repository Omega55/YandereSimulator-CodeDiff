using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodPoolSpawnerScript : MonoBehaviour
{
	public RagdollScript Ragdoll;

	public GameObject LastBloodPool;

	public GameObject BloodPool;

	public Transform BloodParent;

	public Transform Hips;

	public Collider MyCollider;

	public Collider GardenArea;

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

	public void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 9)
		{
			this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
			this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
			this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
			this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
			this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
		}
		this.BloodParent = GameObject.Find("BloodParent").transform;
		this.Positions = new Vector3[5];
		this.Positions[0] = Vector3.zero;
		this.Positions[1] = new Vector3(0.5f, 0.012f, 0f);
		this.Positions[2] = new Vector3(-0.5f, 0.012f, 0f);
		this.Positions[3] = new Vector3(0f, 0.012f, 0.5f);
		this.Positions[4] = new Vector3(0f, 0.012f, -0.5f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.LastBloodPool = other.gameObject;
			this.NearbyBlood++;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood--;
		}
	}

	private void Update()
	{
		if (this.MyCollider.enabled)
		{
			if (this.Timer > 0f)
			{
				this.Timer -= Time.deltaTime;
			}
			this.SetHeight();
			Vector3 position = base.transform.position;
			if (SceneManager.GetActiveScene().buildIndex == 9)
			{
				this.CanSpawn = (!this.GardenArea.bounds.Contains(position) && !this.NEStairs.bounds.Contains(position) && !this.NWStairs.bounds.Contains(position) && !this.SEStairs.bounds.Contains(position) && !this.SWStairs.bounds.Contains(position));
			}
			else
			{
				this.CanSpawn = true;
			}
			if (this.CanSpawn && position.y < this.Height + 0.333333343f)
			{
				if (this.NearbyBlood > 0 && this.LastBloodPool == null)
				{
					this.NearbyBlood--;
				}
				if (this.NearbyBlood < 1 && this.Timer <= 0f)
				{
					this.Timer = 0.1f;
					if (this.PoolsSpawned < 10)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
						gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
						gameObject.transform.parent = this.BloodParent;
						this.PoolsSpawned++;
					}
					else if (this.PoolsSpawned < 20)
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
						gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
						gameObject2.transform.parent = this.BloodParent;
						this.PoolsSpawned++;
						gameObject2.GetComponent<BloodPoolScript>().TargetSize = 1f - (float)(this.PoolsSpawned - 10) * 0.1f;
						if (this.PoolsSpawned == 20)
						{
							base.gameObject.SetActive(false);
						}
					}
				}
			}
		}
	}

	public void SpawnBigPool()
	{
		this.SetHeight();
		Vector3 a = new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z);
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, a + this.Positions[i], Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject.transform.parent = this.BloodParent;
		}
	}

	private void SpawnRow(Transform Location)
	{
		Vector3 position = Location.position;
		Vector3 forward = Location.forward;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
		gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2.5f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
		gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 3f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
	}

	public void SpawnPool(Transform Location)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, Location.position + Location.forward, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
	}

	private void SetHeight()
	{
		float y = base.transform.position.y;
		if (y < 4f)
		{
			this.Height = 0f;
		}
		else if (y < 8f)
		{
			this.Height = 4f;
		}
		else if (y < 12f)
		{
			this.Height = 8f;
		}
		else
		{
			this.Height = 12f;
		}
	}
}
