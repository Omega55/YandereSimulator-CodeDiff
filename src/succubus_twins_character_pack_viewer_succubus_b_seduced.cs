using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_succubus_b_seduced : MonoBehaviour
{
	public float wetingTime;

	public bool playFlg;

	public float time;

	public succubus_twins_character_pack_viewer_succubus_b_seduced()
	{
		this.wetingTime = 0.1f;
		this.playFlg = true;
	}

	public virtual void Update()
	{
		this.time += Time.deltaTime;
		this.GetComponent<Animation>().Play("succubus_b_death_lp");
		if (this.playFlg && this.time > this.wetingTime)
		{
			Vector3 position = GameObject.Find("Head_null").transform.position;
			UnityEngine.Object.Instantiate(Resources.Load("Samples/AddScriptToParticles Prefab/eff_succubus_seduced_00"), position, this.gameObject.transform.rotation);
			this.playFlg = false;
		}
	}

	public virtual void Main()
	{
	}
}
