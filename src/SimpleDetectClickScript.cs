using System;
using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
	public InventoryItemScript InventoryItem;

	public Collider MyCollider;

	public bool Clicked;

	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
		{
			this.Clicked = true;
		}
	}
}
