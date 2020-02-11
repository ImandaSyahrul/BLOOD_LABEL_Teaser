using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Dropdown resolutionDropdown;
	public Text resolutionText;
	public Text displayMode;

	Resolution[] resolutions;

	void Start()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currrentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			
			string option = resolutions[i].width + "x" + resolutions[i].height ;
			options.Add(option);
			

			if(resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currrentResolutionIndex = i;
			}
			
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currrentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void setResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void setMasterVolume(float vol)
	{
		audioMixer.SetFloat("master", vol);
	}

	public void setBGMVolume(float vol)
	{
		audioMixer.SetFloat("background", vol);
	}

	public void setSFXVolume(float vol)
	{
		audioMixer.SetFloat("effect", vol);
	}

	public void setCharacterVolume(float vol)
	{
		audioMixer.SetFloat("voice", vol);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
