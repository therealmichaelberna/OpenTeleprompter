using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    [SerializeField]
    private SettingsUpdater settingsUpdater;

    [SerializeField]
    private Toggle autoScrollCheckbox;

    [Header("Scroll Settings")]
    private bool autoScrollTempSetting;

    [SerializeField]
    public bool autoScrollActiveSetting;

    private char scrollSpeedTempSetting;

    [SerializeField]
    public char scrollSpeedActiveSetting;

    [SerializeField]
    private GameObject scrollSpeedSliderContainerGO;

    [SerializeField]
    private Slider scrollSpeedSlider;

    [Header("Font Settings")]

    [SerializeField]
    private Slider fontSizeSlider;

    [SerializeField]
    private Text fontSizeDisplayText;

    private short fontSizeTempSetting;
    
    [SerializeField]
    public short fontSizeActiveSetting;

    [SerializeField]
    private InputField textPreview;

    const string prefFile = "settings.txt";

    public void InitializeSettings()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + prefFile))
        {
            Debug.Log("settings file exists, loading");
            LoadSettingsFromFile();
        }
        else //set defaults
        {
            Debug.Log("settings file doesn't exist, setting defaults");
            autoScrollActiveSetting = true;
            scrollSpeedActiveSetting = (char)10;
            fontSizeActiveSetting = 12;
        }

        autoScrollCheckbox.isOn = autoScrollActiveSetting;
        scrollSpeedSlider.value = scrollSpeedActiveSetting;

        fontSizeSlider.value = textPreview.placeholder.GetComponent<Text>().fontSize = textPreview.textComponent.fontSize = fontSizeActiveSetting;
        fontSizeDisplayText.text = fontSizeActiveSetting.ToString();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void AutoScrollCheckboxChanged(Toggle checkbox)
    {
        autoScrollTempSetting = checkbox.isOn;
        scrollSpeedSliderContainerGO.SetActive(checkbox.isOn);
    }

    public void UpdateScrollSpeed()
    {
        scrollSpeedTempSetting = (char)scrollSpeedSlider.value;
    }

    public void UpdateFontSize()
    {
        textPreview.placeholder.GetComponent<Text>().fontSize = textPreview.textComponent.fontSize = fontSizeTempSetting = (short)fontSizeSlider.value;
        fontSizeDisplayText.text = fontSizeTempSetting.ToString();
        
    }

    public void Save()
    {
        autoScrollActiveSetting = autoScrollTempSetting;
        scrollSpeedActiveSetting = scrollSpeedTempSetting;
        fontSizeActiveSetting = fontSizeTempSetting;
        SaveSettingsToFile();
        settingsUpdater.SettingsChanged();
        this.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        scrollSpeedSlider.value = scrollSpeedTempSetting = scrollSpeedActiveSetting;
        autoScrollTempSetting = autoScrollActiveSetting;
        fontSizeSlider.value = fontSizeTempSetting = fontSizeActiveSetting;

        this.gameObject.SetActive(false);
    }

    private void SaveSettingsToFile()
    {
        SettingsObject settings = new SettingsObject();
        settings.autoScroll = autoScrollActiveSetting;
        settings.scrollSpeed = scrollSpeedActiveSetting;
        settings.fontSize = fontSizeActiveSetting;

        string json = JsonUtility.ToJson(settings);
        Debug.Log("saving to: " + Application.persistentDataPath);

        using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + prefFile))
        {
            sw.WriteLine(json);
        }
    }

    private void LoadSettingsFromFile()
    {
        string json;

        using (StreamReader sr = new StreamReader(Application.persistentDataPath + Path.DirectorySeparatorChar + prefFile))
        {
            json = sr.ReadLine();
        }        
        SettingsObject settings = JsonUtility.FromJson<SettingsObject>(json);
        autoScrollActiveSetting = settings.autoScroll;
        scrollSpeedActiveSetting = settings.scrollSpeed;
        fontSizeActiveSetting = settings.fontSize;
    }

    [Serializable]
    public class SettingsObject
    {
        public bool autoScroll;
        public char scrollSpeed;
        public short fontSize;
    }

public Dictionary<string, string> GetSettings()
    {
        Dictionary<string, string> settingsList = new Dictionary<string, string>();
        settingsList.Add("autoScroll", autoScrollActiveSetting.ToString());
        settingsList.Add("scrollSpeed", scrollSpeedActiveSetting.ToString());

        return settingsList;
    }
}
