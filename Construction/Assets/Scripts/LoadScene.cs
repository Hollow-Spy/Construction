using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public void tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene("DanielTest 2");
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene("KianTest");
    }
    public void firstLevel()
    {
        SceneManager.LoadScene("MichalTestMain");
    }
   
    

}
