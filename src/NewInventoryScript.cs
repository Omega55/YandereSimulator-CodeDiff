using System;
using UnityEngine;

[Serializable]
public class NewInventoryScript : MonoBehaviour
{
	public GameObject Character;

	public GameObject InverseSkirt;

	public Transform RightGrid;

	public Transform LeftGrid;

	public bool Open;

	public NewInventoryScript()
	{
		this.Open = true;
	}

	public virtual void Start()
	{
		this.RightGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		this.LeftGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
	}

	public virtual void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.Open)
			{
				this.Open = false;
			}
			else
			{
				this.Open = true;
			}
		}
		if (this.Open)
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime);
			float z = Mathf.Lerp(this.transform.position.z, 0.5f, Time.deltaTime * 2.5f);
			Vector3 position = this.transform.position;
			float num = position.z = z;
			Vector3 vector = this.transform.position = position;
			this.Character.animation["f02_inventory_00"].speed = (float)1;
			this.InverseSkirt.animation["InverseSkirtOpen"].speed = (float)1;
		}
		else
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
			float z2 = Mathf.Lerp(this.transform.position.z, (float)1, Time.deltaTime * 2.5f);
			Vector3 position2 = this.transform.position;
			float num2 = position2.z = z2;
			Vector3 vector2 = this.transform.position = position2;
			this.Character.animation["f02_inventory_00"].speed = (float)-1;
			this.InverseSkirt.animation["InverseSkirtOpen"].speed = (float)-1;
		}
		if (this.Character.animation["f02_inventory_00"].time > this.Character.animation["f02_inventory_00"].length)
		{
			this.Character.animation["f02_inventory_00"].time = this.Character.animation["f02_inventory_00"].length;
		}
		if (this.Character.animation["f02_inventory_00"].time < (float)0)
		{
			this.Character.animation["f02_inventory_00"].time = (float)0;
		}
		if (this.InverseSkirt.animation["InverseSkirtOpen"].time > this.InverseSkirt.animation["InverseSkirtOpen"].length)
		{
			this.InverseSkirt.animation["InverseSkirtOpen"].time = this.InverseSkirt.animation["InverseSkirtOpen"].length;
		}
		if (this.InverseSkirt.animation["InverseSkirtOpen"].time < (float)0)
		{
			this.InverseSkirt.animation["InverseSkirtOpen"].time = (float)0;
		}
	}

	public virtual void Main()
	{
	}
}
