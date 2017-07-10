using System;
using UnityEngine;

public class InventoryTestScript : MonoBehaviour
{
	public GameObject Character;

	public GameObject InverseSkirt;

	public Transform RightGrid;

	public Transform LeftGrid;

	public bool Open = true;

	private void Start()
	{
		this.RightGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		this.LeftGrid.localScale = new Vector3(0.7f, 0.7f, 0.7f);
	}

	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Open = !this.Open;
		}
		AnimationState animationState = this.Character.GetComponent<Animation>()["f02_inventory_00"];
		AnimationState animationState2 = this.InverseSkirt.GetComponent<Animation>()["InverseSkirtOpen"];
		if (this.Open)
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 0.5f, Time.deltaTime * 2.5f));
			animationState.speed = 1f;
			animationState2.speed = 1f;
		}
		else
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 1f, Time.deltaTime * 2.5f));
			animationState.speed = -1f;
			animationState2.speed = -1f;
		}
		if (animationState.time > animationState.length)
		{
			animationState.time = animationState.length;
		}
		if (animationState.time < 0f)
		{
			animationState.time = 0f;
		}
		if (animationState2.time > animationState2.length)
		{
			animationState2.time = animationState2.length;
		}
		if (animationState2.time < 0f)
		{
			animationState2.time = 0f;
		}
	}
}
