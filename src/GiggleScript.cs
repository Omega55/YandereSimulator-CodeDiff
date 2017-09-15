using System;
using UnityEngine;

public class GiggleScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Giggle;

	public StudentScript Student;

	public bool Distracted;

	public int Frame;

	private void Start()
	{
		float num = 500f * (2f - SchoolGlobals.SchoolAtmosphere * 0.01f);
		base.transform.localScale = new Vector3(num, base.transform.localScale.y, num);
	}

	private void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9 && !this.Distracted)
		{
			this.Student = other.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && this.Student.Giggle == null && !this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && this.Student.Routine)
			{
				this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.IdleAnim);
				this.Giggle = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z), Quaternion.identity);
				this.Student.Giggle = this.Giggle;
				if (this.Student.Pathfinding != null && !this.Student.Nemesis)
				{
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.InvestigationPhase = 0;
					this.Student.InvestigationTimer = 0f;
					this.Student.Investigating = true;
					this.Student.DiscCheck = true;
					this.Student.Routine = false;
					this.Student.ReadPhase = 0;
					this.Student.OccultBook.SetActive(false);
					this.Student.SmartPhone.SetActive(false);
					this.Student.Phone.SetActive(false);
					this.Student.Pen.SetActive(false);
				}
				this.Distracted = true;
			}
		}
	}
}
