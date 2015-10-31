using System;
using UnityEngine;

[Serializable]
public class succubus_twins_character_pack_viewer_right_hand_follow : MonoBehaviour
{
	public virtual void Update()
	{
		this.transform.position = GameObject.Find("RightHanditem_Null").transform.position;
	}

	public virtual void Main()
	{
	}
}
