using System;
using UnityEngine;

public class FootprintSpawnerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject BloodyFootprint;

	public AudioClip[] Footsteps;

	public Transform BloodParent;

	public Collider GardenArea;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public bool Debugging;

	public bool CanSpawn;

	public bool FootUp;

	public float DownThreshold;

	public float UpThreshold;

	public float Height;

	public int Bloodiness;

	public int Collisions;

	private void Start()
	{
		this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
		this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
		this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
		this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
		this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
	}

	private void Update()
	{
		if (this.Debugging)
		{
			Debug.Log(string.Concat(new string[]
			{
				"UpThreshold: ",
				(this.Yandere.transform.position.y + this.UpThreshold).ToString(),
				" | DownThreshold: ",
				(this.Yandere.transform.position.y + this.DownThreshold).ToString(),
				" | CurrentHeight: ",
				base.transform.position.y.ToString()
			}));
		}
		this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			if (this.Yandere.Stance != StanceType.Crouching && this.Yandere.Stance != StanceType.Crawling && this.Yandere.CanMove && Input.GetButton("LB") && this.FootUp)
			{
				AudioSource component = base.GetComponent<AudioSource>();
				component.clip = this.Footsteps[UnityEngine.Random.Range(0, this.Footsteps.Length)];
				component.Play();
			}
			this.FootUp = false;
			if (this.CanSpawn && this.Bloodiness > 0)
			{
				if (base.transform.position.y > -1f && base.transform.position.y < 1f)
				{
					this.Height = 0f;
				}
				else if (base.transform.position.y > 3f && base.transform.position.y < 5f)
				{
					this.Height = 4f;
				}
				else if (base.transform.position.y > 7f && base.transform.position.y < 9f)
				{
					this.Height = 8f;
				}
				else if (base.transform.position.y > 11f && base.transform.position.y < 13f)
				{
					this.Height = 12f;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
				gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
				gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
				gameObject.transform.parent = this.BloodParent;
				this.Bloodiness--;
			}
		}
	}
}
