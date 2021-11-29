using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevator : MonoBehaviour
{

    public GameObject elevatorDoor;
    public GameObject endGame;
    bool activated;

    public void Activate()
    {
        activated = true;
    }
    private void Update()
    {
     
        {
            if (activated)
            {
                elevatorDoor.gameObject.transform.localScale = new Vector3(elevatorDoor.gameObject.transform.localScale.x, elevatorDoor.gameObject.transform.localScale.y, elevatorDoor.gameObject.transform.localScale.z - .5f);

                if (elevatorDoor.gameObject.transform.localScale.z <= .3f && !endGame.activeSelf)
                {
                    endGame.SetActive(true);
                    StartCoroutine(GoToMenu(1.6f));

                }
            }
        }
    }

    IEnumerator GoToMenu(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Menu");
    }



}
