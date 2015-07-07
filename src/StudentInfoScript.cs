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
	internal sealed class $UpdateInfo$1420 : GenericGenerator<WWW>
	{
		internal StudentInfoScript $self_$1424;

		public $UpdateInfo$1420(StudentInfoScript self_)
		{
			this.$self_$1424 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new StudentInfoScript.$UpdateInfo$1420.$(this.$self_$1424);
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
		return new StudentInfoScript.$UpdateInfo$1420(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
