using System;

[Serializable]
public class ClassSaveData
{
	public int biology;

	public int biologyBonus;

	public int biologyGrade;

	public int chemistry;

	public int chemistryBonus;

	public int chemistryGrade;

	public int language;

	public int languageBonus;

	public int languageGrade;

	public int physical;

	public int physicalBonus;

	public int physicalGrade;

	public int psychology;

	public int psychologyBonus;

	public int psychologyGrade;

	public ClassSaveData()
	{
		this.biology = 0;
		this.biologyBonus = 0;
		this.biologyGrade = 0;
		this.chemistry = 0;
		this.chemistryBonus = 0;
		this.chemistryGrade = 0;
		this.language = 0;
		this.languageBonus = 0;
		this.languageGrade = 0;
		this.physical = 0;
		this.physicalBonus = 0;
		this.physicalGrade = 0;
		this.psychology = 0;
		this.psychologyBonus = 0;
		this.psychologyGrade = 0;
	}

	public static ClassSaveData ReadFromGlobals()
	{
		return new ClassSaveData
		{
			biology = ClassGlobals.Biology,
			biologyBonus = ClassGlobals.BiologyBonus,
			biologyGrade = ClassGlobals.BiologyGrade,
			chemistry = ClassGlobals.Chemistry,
			chemistryBonus = ClassGlobals.ChemistryBonus,
			chemistryGrade = ClassGlobals.ChemistryGrade,
			language = ClassGlobals.Language,
			languageBonus = ClassGlobals.LanguageBonus,
			languageGrade = ClassGlobals.LanguageGrade,
			physical = ClassGlobals.Physical,
			physicalBonus = ClassGlobals.PhysicalBonus,
			physicalGrade = ClassGlobals.PhysicalGrade,
			psychology = ClassGlobals.Psychology,
			psychologyBonus = ClassGlobals.PsychologyBonus,
			psychologyGrade = ClassGlobals.PsychologyGrade
		};
	}

	public static void WriteToGlobals(ClassSaveData data)
	{
		ClassGlobals.Biology = data.biology;
		ClassGlobals.BiologyBonus = data.biologyBonus;
		ClassGlobals.BiologyGrade = data.biologyGrade;
		ClassGlobals.Chemistry = data.chemistry;
		ClassGlobals.ChemistryBonus = data.chemistryBonus;
		ClassGlobals.ChemistryGrade = data.chemistryGrade;
		ClassGlobals.Language = data.language;
		ClassGlobals.LanguageBonus = data.languageBonus;
		ClassGlobals.LanguageGrade = data.languageGrade;
		ClassGlobals.Physical = data.physical;
		ClassGlobals.PhysicalBonus = data.physicalBonus;
		ClassGlobals.PhysicalGrade = data.physicalGrade;
		ClassGlobals.Psychology = data.psychology;
		ClassGlobals.PsychologyBonus = data.psychologyBonus;
		ClassGlobals.PsychologyGrade = data.psychologyGrade;
	}
}
