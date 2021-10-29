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
    public void FirstLevel()
    {
        SceneManager.LoadScene("DanielTest 2");
    }
}
