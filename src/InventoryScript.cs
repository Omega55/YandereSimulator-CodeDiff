using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	public SchemesScript Schemes;

	public bool ModifiedUniform;

	public bool DirectionalMic;

	public bool DuplicateSheet;

	public bool AnswerSheet;

	public bool MaskingTape;

	public bool RivalPhone;

	public bool LockPick;

	public bool Headset;

	public bool FakeID;

	public bool IDCard;

	public bool Book;

	public bool LethalPoison;

	public bool ChemicalPoison;

	public bool EmeticPoison;

	public bool RatPoison;

	public bool HeadachePoison;

	public bool Tranquilizer;

	public bool Sedative;

	public bool Cigs;

	public bool Ring;

	public bool Rose;

	public bool Sake;

	public bool Soda;

	public bool Bra;

	public bool CabinetKey;

	public bool CaseKey;

	public bool SafeKey;

	public bool ShedKey;

	public int MysteriousKeys;

	public int PantyShots;

	public bool[] ShrineCollectibles;

	public UILabel MoneyLabel;

	private void Start()
	{
		this.PantyShots = PlayerGlobals.PantyShots;
		this.UpdateMoney();
	}

	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
	}
}
