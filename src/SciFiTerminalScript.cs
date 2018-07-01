using System;
using UnityEngine;

public class SciFiTerminalScript : MonoBehaviour
{
	public StudentScript Student;

	public RobotArmScript RobotArms;

	public Transform OtherFinger;

	public bool Updated;

	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
		}
		else
		{
			this.RobotArms = this.Student.StudentManager.RobotArms;
		}
	}

	private void Update()
	{
		if (this.RobotArms.TerminalTarget != null)
		{
			if ((double)Vector3.Distance(this.RobotArms.TerminalTarget.position, base.transform.position) < 0.3 || (double)Vector3.Distance(this.RobotArms.TerminalTarget.position, this.OtherFinger.position) < 0.3)
			{
				if (!this.Updated)
				{
					this.Updated = true;
					if (!this.RobotArms.On[0])
					{
						this.RobotArms.ActivateArms();
					}
					else
					{
						this.RobotArms.ToggleWork();
					}
				}
			}
			else
			{
				this.Updated = false;
			}
		}
	}
}
