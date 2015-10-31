using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_magic_particle_instance : MonoBehaviour
{
	public GameObject particle1;

	public GameObject particle2;

	public GameObject particle3;

	public float waitingTime1;

	public float waitingTime2;

	public string positionBoneName;

	private string rotationBoneName;

	private Transform rotationBone;

	private Transform positionBone;

	private float time;

	private int mode;

	public succubus_twins_character_pack_viewer_magic_particle_instance()
	{
		this.positionBoneName = "RightHanditem_Null";
		this.rotationBoneName = "succubus";
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		this.positionBone = GameObject.Find(this.positionBoneName).transform;
		this.rotationBone = GameObject.Find(this.rotationBoneName).transform;
		this.time += Time.deltaTime;
		if (this.mode == 0 && this.time > this.waitingTime1)
		{
			this.mode = 1;
			this.time = (float)0;
			UnityEngine.Object.Instantiate(this.particle1, this.positionBone.position, this.rotationBone.rotation);
		}
		if (this.mode == 1 && this.time > this.waitingTime2)
		{
			this.mode = 2;
			this.time = (float)0;
			UnityEngine.Object.Instantiate(this.particle2, this.positionBone.position, this.rotationBone.rotation);
			UnityEngine.Object.Instantiate(this.particle3, this.positionBone.position, this.rotationBone.rotation);
		}
		if (this.mode == 2)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
