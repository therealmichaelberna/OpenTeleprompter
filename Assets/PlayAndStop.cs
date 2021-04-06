using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAndStop : MonoBehaviour
{
    [SerializeField]
    private Sprite playIcon;
    
    [SerializeField]
    private Sprite stopIcon;

    [SerializeField]
    private InputField mainInputField;

    [SerializeField]
    private Text playText;

    [SerializeField]
    private Image playButtonIcon;

    private bool currentlyPlaying = false;

    [SerializeField]
    private settings Settings;

    private const float playTextDefaultYPosition = -287.5f;
    private const float mouseScrollScale = 20f;

    public void OnPlayStopButonClick()
    {
        if(currentlyPlaying)
        {
            Stop();
        }
        else
        {
            Play();
        }
    }
    public void Play()
    {
        mainInputField.gameObject.SetActive(false);
        playText.gameObject.SetActive(true);
        playText.fontSize = mainInputField.textComponent.fontSize;
        playText.text = mainInputField.text;
        playText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(playText.gameObject.GetComponent<RectTransform>().sizeDelta.x, 1);
        playButtonIcon.sprite = stopIcon;//change the icon indicating that we can stop
        currentlyPlaying = true;
    }
    public void Stop()
    {
        mainInputField.gameObject.SetActive(true);
        playText.gameObject.SetActive(false);
        playButtonIcon.sprite = playIcon;//change the icon indicating that we can play

        currentlyPlaying = false;
    }

    void Update()
    {
        float newYPos = 0;

        if (currentlyPlaying)//if we are playing
        {
            if(Settings.autoScrollActiveSetting && Input.mouseScrollDelta.y == 0)//if auto scroll is enabled, scroll away!
            {
                newYPos = (playText.gameObject.GetComponent<RectTransform>().anchoredPosition.y) + (Settings.scrollSpeedActiveSetting * Time.deltaTime);
            }

            //Debug.Log("scrolling");            
            if (Input.mouseScrollDelta.y != 0)//also scroll if we are using the mouse
            {
                //Debug.Log("mouse scroll detected!");
                //Debug.Log("mouse scroll value: " + Input.mouseScrollDelta.y);
                //Debug.Log("mouse scroll scaled speed:" + );
                newYPos = (playText.gameObject.GetComponent<RectTransform>().anchoredPosition.y) + (Input.mouseScrollDelta.y * mouseScrollScale);
            }

            playText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(playText.gameObject.GetComponent<RectTransform>().anchoredPosition.x, newYPos);
        }   
    }
}
