using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    public void setQuality (int index)
    {
        QualitySettings.SetQualityLevel(index, true);
        declarations.successPanel.SetActive(true);
        declarations.successPanelText.text = "You have successfully changed your graphics settings!";
    }
    public void setVolume ()
    {
        AudioSource audioSource;
        audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        audioSource.volume = declarations.audioSliderMusicVolume.value;
        declarations.audioSliderMusicValue = audioSource.volume;
    }
}
