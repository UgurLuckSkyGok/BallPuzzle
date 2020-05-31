using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private int stageCount;

	/// <summary>
	/// Kaçınıcı levelde olduğunu çekerek Level Manager'a gönderir
	/// </summary>
	private void Awake()
	{
		int level = PlayerPrefs.GetInt("Level", 1);
		Debug.Log("Start Level : " + level);
		if (level > 5)
		{
			LevelManager.instance.LoadLevel(1);
			PlayerPrefs.SetInt("Level", 1);
		}
		else
			LevelManager.instance.LoadLevel(level);
	}

	/// <summary>
	/// Açtığı kapı sayısını sayarak 2. kapıdan sonra renk birleşimine izin verir
	/// </summary>
	public void IncrementStageCount()
	{
		stageCount++;
		if (stageCount == 2)
			PlayerController.instance.SetColorMix(true);
	}

	public void GameWin()
	{
		PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
		LevelLoader.instance.NextScene("Main");
	}

	public void GameOver()
	{
		MainCanvasController.instance.GameOver();
	}
}
