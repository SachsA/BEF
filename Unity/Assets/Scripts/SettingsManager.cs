using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Toggle fullscreenToggle;

    public Dropdown resolutionDropdown;
    public Dropdown textureDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;

    public Slider volumeSlider;

    public Button applyButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureDropdown.onValueChanged.AddListener(delegate { OnTextureChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;

        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullScreen = fullscreenToggle.isOn;
        Screen.fullScreen = gameSettings.fullScreen;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureChange()
    {
        gameSettings.texture = textureDropdown.value;
        QualitySettings.masterTextureLimit = gameSettings.texture;
    }

    public void OnAntialiasingChange()
    {
        gameSettings.antialiasing = antialiasingDropdown.value;
        QualitySettings.antiAliasing = (int)Mathf.Pow(2f, antialiasingDropdown.value);
    }

    public void OnVSyncChange()
    {
        gameSettings.vSync = vSyncDropdown.value;
        QualitySettings.vSyncCount = gameSettings.vSync;
    }

    public void OnVolumeChange()
    {
        gameSettings.volume = volumeSlider.value;
        audioMixer.SetFloat("masterVolume", gameSettings.volume);
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        gameSettings.volume = volumeSlider.value;
        gameSettings.antialiasing = antialiasingDropdown.value;
        gameSettings.fullScreen = Screen.fullScreen = fullscreenToggle.isOn;
        gameSettings.texture = textureDropdown.value;
        gameSettings.resolutionIndex = resolutionDropdown.value;
        gameSettings.vSync = vSyncDropdown.value;

        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings.json", jsonData);
    }

    public void LoadSettings()
    {
        string jsonData;

        if (File.Exists(Application.persistentDataPath + "/gameSettings.json"))
        {
            jsonData = File.ReadAllText(Application.persistentDataPath + "/gameSettings.json");
            gameSettings = JsonUtility.FromJson<GameSettings>(jsonData);

            volumeSlider.value = gameSettings.volume;
            antialiasingDropdown.value = gameSettings.antialiasing;
            fullscreenToggle.isOn = gameSettings.fullScreen;
            textureDropdown.value = gameSettings.texture;
            resolutionDropdown.value = gameSettings.resolutionIndex;
            vSyncDropdown.value = gameSettings.vSync;

            resolutionDropdown.RefreshShownValue();
        }
    }

}