using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class StudentInfoScript : MonoBehaviour
{
	[CompilerGenerated]
	[Serializable]
	internal sealed class $UpdateInfo$1201 : GenericGenerator<WWW>
	{
		internal StudentInfoScript $self_$1205;

		public $UpdateInfo$1201(StudentInfoScript self_)
		{
			this.$self_$1205 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new StudentInfoScript.$UpdateInfo$1201.$(this.$self_$1205);
		}
	}

	public StudentScript Student;

	public UITexture Portrait;

	public UILabel NameLabel;

	public UILabel ClubLabel;

	public UILabel PersonaLabel;

	public UILabel CrushLabel;

	public Texture DefaultPortrait;

	public virtual IEnumerator UpdateInfo()
	{
		return new StudentInfoScript.$UpdateInfo$1201(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
