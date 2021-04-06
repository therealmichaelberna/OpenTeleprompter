using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUpdater : MonoBehaviour
{
    [SerializeField]
    private settings Settings;

    [SerializeField]
    private Text mainTelepromptText;
    [SerializeField]
    private Text mainTelepromptPlaceHolderText;

    // Start is called before the first frame update
    void Start()
    {
        Settings.InitializeSettings();
        UpdateTextSize();        
    }

    private void UpdateTextSize()
    {
        mainTelepromptPlaceHolderText.fontSize = mainTelepromptText.fontSize = Settings.fontSizeActiveSetting;        
    }

    /// <summary>
    /// Called when a setting is changed to update text size, scroll speed, etc.
    /// </summary>
    public void SettingsChanged()
    {
        UpdateTextSize();
    }
}
