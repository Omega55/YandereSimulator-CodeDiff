using System;
using UnityEngine;

[Serializable]
public class GiggleScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Giggle;

	public StudentScript Student;

	public bool Distracted;

	public int Frame;

	public virtual void Start()
	{
		float x = (float)500 * ((float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		Vector3 localScale = this.transform.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.transform.localScale = localScale;
		float x2 = this.transform.localScale.x;
		Vector3 localScale2 = this.transform.localScale;
		float num2 = localScale2.z = x2;
		Vector3 vector2 = this.transform.localScale = localScale2;
	}

	public virtual void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		this.Frame++;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9 && !this.Distracted)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null && this.Student.Giggle == null && !this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following)
			{
				this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
				this.Giggle = (GameObject)UnityEngine.Object.Instantiate(this.EmptyGameObject, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z), Quaternion.identity);
				this.Student.Giggle = this.Giggle;
				if (this.Student.Pathfinding != null)
				{
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.InvestigationPhase = 0;
					this.Student.InvestigationTimer = (float)0;
					this.Student.Investigating = true;
					this.Student.DiscCheck = true;
					this.Student.Routine = false;
					this.Student.ReadPhase = 0;
				}
				this.Distracted = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
