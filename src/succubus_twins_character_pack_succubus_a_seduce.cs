using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_succubus_a_seduce : MonoBehaviour
{
	public GameObject particleInstanceFile;

	public virtual void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.setParticle();
		}
		if (!this.GetComponent<Animation>().IsPlaying("succubus_a_charm_02"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_a_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_a_charm_02"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Once;
			this.GetComponent<Animation>().CrossFade("succubus_a_charm_02");
			UnityEngine.Object.Instantiate(this.particleInstanceFile, new Vector3((float)0, (float)0, (float)0), Quaternion.identity);
		}
	}

	public virtual void Main()
	{
	}
}
