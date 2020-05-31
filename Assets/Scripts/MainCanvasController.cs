using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasController : Singleton<MainCanvasController>
{
	[SerializeField] private GameObject SettingMenu;
	[SerializeField] private GameObject GameOverMenu;

	/// <summary>
	/// Open Settin Menu
	/// </summary>
	public void SettingButon()
	{
		SettingMenu.SetActive(true);
	}

	/// <summary>
	/// Open Game Over Panel
	/// </summary>
	public void GameOver()
	{
		GameOverMenu.SetActive(true);
	}
}
