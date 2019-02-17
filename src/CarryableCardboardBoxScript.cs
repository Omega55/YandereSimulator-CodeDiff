using System;
using UnityEngine;

public class CarryableCardboardBoxScript : MonoBehaviour
{
	public WeaponScript MyCutter;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public MeshFilter MyRenderer;

	public Mesh ClosedMesh;

	public bool Closed;

	private void Update()
	{
		if (!this.Closed)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Insert Box Cutter";
				this.MyRenderer.mesh = this.ClosedMesh;
				this.Prompt.HideButton[0] = true;
				this.Closed = true;
			}
		}
		else if (this.MyCutter == null)
		{
			this.Prompt.HideButton[0] = true;
			if (this.Prompt.Yandere.Armed)
			{
				if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 5 && !this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
				{
					this.Prompt.HideButton[0] = false;
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						this.MyCutter = this.Prompt.Yandere.EquippedWeapon;
						Physics.IgnoreCollision(base.GetComponent<Collider>(), this.MyCutter.MyCollider);
						this.Prompt.Yandere.DropTimer[this.Prompt.Yandere.Equipped] = 0.5f;
						this.Prompt.Yandere.DropWeapon(this.Prompt.Yandere.Equipped);
						this.MyCutter.MyRigidbody.useGravity = false;
						this.MyCutter.MyRigidbody.isKinematic = true;
						this.MyCutter.MyCollider.isTrigger = true;
						this.MyCutter.transform.parent = base.transform;
						this.MyCutter.transform.localPosition = new Vector3(0f, 0.24f, 0f);
						this.MyCutter.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
						this.MyCutter.Prompt.Hide();
						this.MyCutter.Prompt.enabled = false;
						this.MyCutter.enabled = false;
						this.MyCutter.gameObject.SetActive(true);
						this.Prompt.HideButton[0] = true;
						this.Prompt.HideButton[3] = false;
						this.PickUp.StuckBoxCutter = this.MyCutter;
						this.PickUp.enabled = true;
					}
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		else if (this.MyCutter.transform.parent != base.transform)
		{
			this.MyCutter = null;
		}
	}
}
