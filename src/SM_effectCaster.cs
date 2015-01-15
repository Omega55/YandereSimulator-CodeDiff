using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SM_effectCaster : MonoBehaviour
{
	public GameObject moveThis;

	public RaycastHit hit;

	public GameObject[] createThis;

	public float cooldown;

	public float changeCooldown;

	public int selected;

	public GUIText writeThis;

	private float rndNr;

	private GameObject effect;

	public virtual void Start()
	{
		this.selected = Extensions.get_length(this.createThis) - 1;
		this.writeThis.text = this.selected.ToString() + " " + this.createThis[this.selected].name;
	}

	public virtual void Update()
	{
		if (this.cooldown > (float)0)
		{
			this.cooldown -= Time.deltaTime;
		}
		if (this.changeCooldown > (float)0)
		{
			this.changeCooldown -= Time.deltaTime;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out this.hit))
		{
			this.moveThis.transform.position = this.hit.point;
			if (Input.GetMouseButton(0) && this.cooldown <= (float)0)
			{
				this.effect = (GameObject)UnityEngine.Object.Instantiate(this.createThis[this.selected], this.moveThis.transform.position, this.moveThis.transform.rotation);
				if (this.effect.tag == "explosion" || this.effect.tag == "missile" || this.effect.tag == "breath")
				{
					float y = this.effect.transform.position.y + 1.5f;
					Vector3 position = this.effect.transform.position;
					float num = position.y = y;
					Vector3 vector = this.effect.transform.position = position;
				}
				if (this.effect.tag == "shield")
				{
					float y2 = this.effect.transform.position.y + 0.5f;
					Vector3 position2 = this.effect.transform.position;
					float num2 = position2.y = y2;
					Vector3 vector2 = this.effect.transform.position = position2;
				}
				this.cooldown = 0.15f;
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && this.changeCooldown <= (float)0)
		{
			this.selected++;
			if (this.selected > Extensions.get_length(this.createThis) - 1)
			{
				this.selected = 0;
			}
			this.writeThis.text = this.selected.ToString() + " " + this.createThis[this.selected].name;
			this.changeCooldown = 0.1f;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && this.changeCooldown <= (float)0)
		{
			this.selected--;
			if (this.selected < 0)
			{
				this.selected = Extensions.get_length(this.createThis) - 1;
			}
			this.writeThis.text = this.selected.ToString() + " " + this.createThis[this.selected].name;
			this.changeCooldown = 0.1f;
		}
	}

	public virtual void Main()
	{
	}
}
