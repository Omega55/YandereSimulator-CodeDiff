using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_succubus_b_damage : MonoBehaviour
{
	public GameObject particleFile;

	public virtual void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.setParticle();
		}
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_damage_l"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
			this.GetComponent<Animation>().CrossFade("succubus_b_idle_01");
		}
	}

	public virtual void setParticle()
	{
		if (!this.GetComponent<Animation>().IsPlaying("succubus_b_damage_l"))
		{
			this.GetComponent<Animation>().wrapMode = WrapMode.Once;
			this.GetComponent<Animation>().CrossFade("succubus_b_damage_l");
			Vector3 position = GameObject.Find("Head").transform.position;
			UnityEngine.Object.Instantiate(this.particleFile, position, this.gameObject.transform.rotation);
		}
	}

	public virtual void Main()
	{
	}
}
