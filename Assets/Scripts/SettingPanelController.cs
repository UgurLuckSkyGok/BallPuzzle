using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Setting Menu Panel 
/// </summary>
public class SettingPanelController : MonoBehaviour
{
	[SerializeField]
	private GameObject settingMenuPanel;
	[SerializeField]
	private GameObject soundButton;
	[SerializeField]
	private Sprite soundOnSprite;
	[SerializeField]
	private Sprite soundOffSprite;
	[SerializeField]
	private GameObject vibrateButton;
	[SerializeField]
	private Sprite vibrateOnSprite;
	[SerializeField]
	private Sprite vibrateOffSprite;
	[SerializeField]
	private Button settingBackGround;

	public string appStoreAppID = "";
	public string googleAppID = "";

	public string appStoreURL = "";
	public string googlePlayURL = "";

	private bool isMusicActive = true;
	private bool isHapticActive = true;

	private void Awake()
	{
		if (PlayerPrefs.GetInt("Sound", 1) == 0)
		{
			AudioListener.volume = 0;
			soundButton.GetComponent<Image>().sprite = soundOffSprite;
			isMusicActive = false;
		}
		else
		{
			AudioListener.volume = 1;
			soundButton.GetComponent<Image>().sprite = soundOnSprite;
			isMusicActive = true;
		}

		settingBackGround.onClick.AddListener(() =>
		{
			Time.timeScale = 1;
			settingMenuPanel.SetActive(false);
		});

	}

	#region SettingMenuPanelButtons

	public void VibrateButton()
	{
		// Vibration On/Off
	}

	public void RateButton()
	{
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + googleAppID);
#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/" + appStoreAppID);
#endif
	}

	public void SoundButton()
	{
		if (isMusicActive)
		{
			soundButton.GetComponent<Image>().sprite = soundOffSprite;
			AudioListener.volume = 0;
			isMusicActive = !isMusicActive;
			PlayerPrefs.SetInt("Sound", 0);
		}
		else
		{
			soundButton.GetComponent<Image>().sprite = soundOnSprite;
			AudioListener.volume = 1;
			isMusicActive = !isMusicActive;
			PlayerPrefs.SetInt("Sound", 1);
		}
	}

	public void ClosePopUpButton()
	{
		Time.timeScale = 1;

		settingMenuPanel.SetActive(false);
	}

	public void Restart()
	{
		SceneManager.LoadScene("Main");
	}

	public void ExitButton()
	{
		Application.Quit();
	}

	#endregion


}
