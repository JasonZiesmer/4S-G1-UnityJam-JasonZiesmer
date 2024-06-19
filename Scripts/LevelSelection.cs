using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void OnBackButtonClick()
    {

        SceneManager.LoadScene("OptionScene");
    }
    public void OnLevel1Click()
    {

        SceneManager.LoadScene("GameScene");
    }

  /*  public void OnLevel2Click()
    {

        SceneManager.LoadScene("+GameScene");
    }

    public void OnLevel3Click()
    {

        SceneManager.LoadScene("++GameScene");
    }

    public void OnLevel4Click()
    {

        SceneManager.LoadScene("+++GameScene");
    }*/
}
