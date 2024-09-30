using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int nextSceneIndex;
    public GameObject transition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip"))
        {
            StartCoroutine(waitSec());
        }
    }

    public void NextSceneFunc()
    {
        StartCoroutine(waitSec());
    }

    public void ExitGameFunc()
    {
        Application.Quit();
    }

    public IEnumerator waitSec()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
