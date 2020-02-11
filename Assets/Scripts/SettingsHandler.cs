using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingsHandler : MonoBehaviour
{
	public GameObject[] settingPanels;
	public AudioMixer audioMixer;
	public AudioMixerGroup[] mixerGroups;
	
	private int currIndex;

	Resolution[] resolutions;
	int currentResolutionIndex;

	[SerializeField] private Text viewToggle;
	[SerializeField] private Text viewValues;
	[SerializeField] private Text[] groupValues;
	private float[] mixerValues;

	List<string> optionsResolution;


	// Start is called before the first frame update
	void Start()
    {
		currIndex = 0;
		mixerValues = new float[3] {0.0f, 0.0f, 0.0f};

		for (int i = 0; i < settingPanels.Length; i++)
		{
			settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
		}

		optionsResolution = new List<string>();

		resolutions = Screen.resolutions;

		currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{

			string option = resolutions[i].width + "x" + resolutions[i].height;
			optionsResolution.Add(option);


			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}

		}

		viewValues.text = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
		viewToggle.text = (Screen.fullScreen) ? "Fullscreen" : "Windowed";
		for(int i = 0; i < mixerValues.Length; i++)
		{
			groupValues[i].text = ((int)(mixerValues[i]+80.0f)).ToString();
		}
		
		

	}

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < settingPanels.Length; i++)
		{
			if (i == currIndex) settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 3.0f);
			else settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			currIndex -= 1;
			if (currIndex < 0) currIndex = 4;
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			currIndex += 1;
			if (currIndex > 4) currIndex = 0;
		}

		if (currIndex < 2)
		{
			if (currIndex == 0)
			{
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					if (currentResolutionIndex > 0)
					{
						currentResolutionIndex -= 1;
						Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, Screen.fullScreen);
						viewValues.text = optionsResolution[currentResolutionIndex];
					}
				}
				else if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					if (currentResolutionIndex < resolutions.Length)
					{
						currentResolutionIndex += 1;
						Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, Screen.fullScreen);
						viewValues.text = optionsResolution[currentResolutionIndex];
					}
				}
			}
			else if (currIndex == 1)
			{
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					if (Screen.fullScreen)
					{
						Screen.fullScreen = false;
						viewToggle.text = "Windowed";
					}
				}
				
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					if (!Screen.fullScreen)
					{
						Screen.fullScreen = true;
						viewToggle.text = "Fullscreen";
					}
				}
			}
		}
		else
		{
			string groupName = mixerGroups[currIndex-2].ToString();
			//Debug.Log(groupName);
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				mixerValues[currIndex - 2] -= 2.0f;
				if (mixerValues[currIndex - 2] < -80.0f) mixerValues[currIndex - 2] = -80.0f;
				groupValues[currIndex - 2].text = ((int)(mixerValues[currIndex - 2] + 80.0f)).ToString();
				//setVolume(groupName, mixerValues[currIndex - 2]);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				mixerValues[currIndex - 2] += 2.0f;
				if (mixerValues[currIndex - 2] > 20.0f) mixerValues[currIndex - 2] = 20.0f;
				groupValues[currIndex - 2].text = ((int)(mixerValues[currIndex - 2] + 80.0f)).ToString();
				//setVolume(groupName, mixerValues[currIndex - 2]);
			}
		}
		
			
		
	}

	public void setResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void setVolume(string groupName,float vol)
	{
		audioMixer.SetFloat(groupName, vol);
	}

	

}
