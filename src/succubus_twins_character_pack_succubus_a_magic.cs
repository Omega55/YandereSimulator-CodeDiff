using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_succubus_a_magic : MonoBehaviour
{
	public GameObject particleInstanceFile;

	private float time;

	private float weitingTime;

	public succubus_twins_character_pack_succubus_a_magic()
	{
		this.weitingTime = 3.5f;
	}

	public virtual void Update()
	{
		this.time += Time.deltaTime;
		if (Input.GetMouseButtonDown(0))
		{
			this.setParticle();
		}
		if (this.time > this.weitingTime)
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_a_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_a_magic_01"))
		{
			this.time = (float)0;
			this.GetComponent<Animation>().wrapMode = WrapMode.ClampForever;
			this.GetComponent<Animation>().CrossFade("succubus_a_magic_01");
			UnityEngine.Object.Instantiate(this.particleInstanceFile, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
		}
	}

	public virtual void Main()
	{
	}
}
