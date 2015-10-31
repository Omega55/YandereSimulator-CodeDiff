using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_seduce_particle_instance : MonoBehaviour
{
	public GameObject particle;

	public float wetingTime;

	private Transform playerBone;

	private Transform followBone;

	private float time;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		this.time += Time.deltaTime;
		if (this.time > this.wetingTime)
		{
			this.followBone = GameObject.Find("b_lip_center").transform;
			this.playerBone = GameObject.Find("succubus").transform;
			UnityEngine.Object.Instantiate(this.particle, this.followBone.position, this.playerBone.rotation);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
