using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_my_destroy : MonoBehaviour
{
	public float waitingTime;

	private float time;

	public succubus_twins_character_pack_viewer_my_destroy()
	{
		this.waitingTime = 1f;
	}

	public virtual void Update()
	{
		this.time += Time.deltaTime;
		if (this.time > this.waitingTime)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
