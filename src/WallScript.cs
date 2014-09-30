using System;
using UnityEngine;

[Serializable]
public class WallScript : MonoBehaviour
{
	public Transform CoverHitboxes;

	public GameObject CoverHitbox;

	private GameObject NorthCoverHitbox;

	private GameObject SouthCoverHitbox;

	private GameObject EastCoverHitbox;

	private GameObject WestCoverHitbox;

	public bool Short;

	public float Size;

	public WallScript()
	{
		this.Size = 0.3333333f;
	}

	public virtual void Start()
	{
		this.NorthCoverHitbox = (GameObject)UnityEngine.Object.Instantiate(this.CoverHitbox, this.transform.position, this.transform.rotation);
		float y = this.NorthCoverHitbox.transform.position.y - (this.transform.localScale.y / (float)2 - this.Size / (float)2);
		Vector3 position = this.NorthCoverHitbox.transform.position;
		float num = position.y = y;
		Vector3 vector = this.NorthCoverHitbox.transform.position = position;
		float z = this.NorthCoverHitbox.transform.position.z + (this.transform.localScale.z / (float)2 + this.Size / (float)2);
		Vector3 position2 = this.NorthCoverHitbox.transform.position;
		float num2 = position2.z = z;
		Vector3 vector2 = this.NorthCoverHitbox.transform.position = position2;
		this.NorthCoverHitbox.transform.localScale = new Vector3(this.transform.localScale.x, this.Size, this.Size);
		this.SouthCoverHitbox = (GameObject)UnityEngine.Object.Instantiate(this.CoverHitbox, this.transform.position, this.transform.rotation);
		float y2 = this.SouthCoverHitbox.transform.position.y - (this.transform.localScale.y / (float)2 - this.Size / (float)2);
		Vector3 position3 = this.SouthCoverHitbox.transform.position;
		float num3 = position3.y = y2;
		Vector3 vector3 = this.SouthCoverHitbox.transform.position = position3;
		float z2 = this.SouthCoverHitbox.transform.position.z - (this.transform.localScale.z / (float)2 + this.Size / (float)2);
		Vector3 position4 = this.SouthCoverHitbox.transform.position;
		float num4 = position4.z = z2;
		Vector3 vector4 = this.SouthCoverHitbox.transform.position = position4;
		this.SouthCoverHitbox.transform.localScale = new Vector3(this.transform.localScale.x, this.Size, this.Size);
		int num5 = 180;
		Vector3 eulerAngles = this.SouthCoverHitbox.transform.eulerAngles;
		float num6 = eulerAngles.y = (float)num5;
		Vector3 vector5 = this.SouthCoverHitbox.transform.eulerAngles = eulerAngles;
		this.EastCoverHitbox = (GameObject)UnityEngine.Object.Instantiate(this.CoverHitbox, this.transform.position, this.transform.rotation);
		float y3 = this.EastCoverHitbox.transform.position.y - (this.transform.localScale.y / (float)2 - this.Size / (float)2);
		Vector3 position5 = this.EastCoverHitbox.transform.position;
		float num7 = position5.y = y3;
		Vector3 vector6 = this.EastCoverHitbox.transform.position = position5;
		float x = this.EastCoverHitbox.transform.position.x + (this.transform.localScale.x / (float)2 + this.Size / (float)2);
		Vector3 position6 = this.EastCoverHitbox.transform.position;
		float num8 = position6.x = x;
		Vector3 vector7 = this.EastCoverHitbox.transform.position = position6;
		this.EastCoverHitbox.transform.localScale = new Vector3(this.transform.localScale.z, this.Size, this.Size);
		int num9 = 90;
		Vector3 eulerAngles2 = this.EastCoverHitbox.transform.eulerAngles;
		float num10 = eulerAngles2.y = (float)num9;
		Vector3 vector8 = this.EastCoverHitbox.transform.eulerAngles = eulerAngles2;
		this.WestCoverHitbox = (GameObject)UnityEngine.Object.Instantiate(this.CoverHitbox, this.transform.position, this.transform.rotation);
		float y4 = this.WestCoverHitbox.transform.position.y - (this.transform.localScale.y / (float)2 - this.Size / (float)2);
		Vector3 position7 = this.WestCoverHitbox.transform.position;
		float num11 = position7.y = y4;
		Vector3 vector9 = this.WestCoverHitbox.transform.position = position7;
		float x2 = this.WestCoverHitbox.transform.position.x - (this.transform.localScale.x / (float)2 + this.Size / (float)2);
		Vector3 position8 = this.WestCoverHitbox.transform.position;
		float num12 = position8.x = x2;
		Vector3 vector10 = this.WestCoverHitbox.transform.position = position8;
		this.WestCoverHitbox.transform.localScale = new Vector3(this.transform.localScale.z, this.Size, this.Size);
		int num13 = -90;
		Vector3 eulerAngles3 = this.WestCoverHitbox.transform.eulerAngles;
		float num14 = eulerAngles3.y = (float)num13;
		Vector3 vector11 = this.WestCoverHitbox.transform.eulerAngles = eulerAngles3;
		if (this.Short)
		{
			this.NorthCoverHitbox.tag = "ShortCoverHitbox";
			this.SouthCoverHitbox.tag = "ShortCoverHitbox";
			this.EastCoverHitbox.tag = "ShortCoverHitbox";
			this.WestCoverHitbox.tag = "ShortCoverHitbox";
		}
		this.NorthCoverHitbox.transform.parent = this.CoverHitboxes;
		this.SouthCoverHitbox.transform.parent = this.CoverHitboxes;
		this.EastCoverHitbox.transform.parent = this.CoverHitboxes;
		this.WestCoverHitbox.transform.parent = this.CoverHitboxes;
	}

	public virtual void Main()
	{
	}
}
