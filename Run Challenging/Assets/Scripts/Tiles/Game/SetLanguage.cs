using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage : MonoBehaviour
{
    public Language[] languages;

    public Text Paused;
    public Text startingText;
    public Text Playlist;
    public Text Settings;
    public Text English;
    public Text VietNamese;
    public Text Volume;
    public Text language;
    public Text GameOver;

    private void Start()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            int index = PlayerPrefs.GetInt("language");
            CurrentLanguage(index);
        }

    }
    public void CurrentLanguage(int index)
    {
        Paused.text = languages[index].Paused;
        GameOver.text = languages[index].GameOver;
        startingText.text = languages[index].startingText;
        Playlist.text = languages[index].Playlist;
        Settings.text = languages[index].Settings;
        English.text = languages[index].English;
        VietNamese.text = languages[index].VietNamese;
        Volume.text = languages[index].Volume;
        language.text = languages[index].languages;
        PlayerPrefs.SetInt("language", index);

    }
}
