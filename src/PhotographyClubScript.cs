using System;
using UnityEngine;

public class PhotographyClubScript : MonoBehaviour
{
	public GameObject CrimeScene;

	public GameObject InvestigationPhotos;

	public GameObject ArtsyPhotos;

	public GameObject StraightTables;

	public GameObject CrookedTables;

	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			this.InvestigationPhotos.SetActive(true);
			this.ArtsyPhotos.SetActive(false);
			this.CrimeScene.SetActive(true);
			this.StraightTables.SetActive(true);
			this.CrookedTables.SetActive(false);
			return;
		}
		this.InvestigationPhotos.SetActive(false);
		this.ArtsyPhotos.SetActive(true);
		this.CrimeScene.SetActive(false);
		this.StraightTables.SetActive(false);
		this.CrookedTables.SetActive(true);
	}
}
