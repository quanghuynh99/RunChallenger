using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySong : MonoBehaviour
{
    public void Unity()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "Unity";
    }
    public void MainTheme()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "MainTheme";
    }
    public void Animals()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "Animals";
    }
    public void Dancin()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "Dancin";
    }
    public void Nevada()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "Nevada";
    }
    public void Faded()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "Faded";
    }
    public void RoadSoFar()
    {
        FindObjectOfType<AudioManager>().StopSound(PlayerController.nameSong);
        PlayerController.nameSong = "RoadSoFar"; 
    }

}
