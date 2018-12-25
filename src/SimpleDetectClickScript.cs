using System;
using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
	public InventoryItemScript InventoryItem;

	public Collider MyCollider;

	public bool Clicked;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 100f) && raycastHit.collider == this.MyCollider)
			{
				this.Clicked = true;
			}
		}
	}
}
