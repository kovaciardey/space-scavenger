using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameScript : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    public GameObject pauseMenuParent;

    public bool IsPaused { get; set; }

    private GameObject pauseMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false;

        // create the pause menu
        pauseMenuObject = Instantiate(pauseMenuPrefab, new Vector2(0, 0), Quaternion.identity);
        pauseMenuObject.transform.SetParent(pauseMenuParent.transform, false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            pauseMenuObject.GetComponent<PauseMenuController>().ShowShipSceneButtons();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            pauseMenuObject.GetComponent<PauseMenuController>().ShowLevelSceneButtons();
        }

        pauseMenuObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!IsPaused)
        {
            IsPaused = true;
            Time.timeScale = 0;

            pauseMenuObject.gameObject.SetActive(true);
        } 
        else
        {
            IsPaused = false;
            Time.timeScale = 1;

            pauseMenuObject.gameObject.SetActive(false);
        }
    }

    public void SaveGame()
    {
        Debug.Log("Game Saved");
    }

    public void BackToShip()
    {
        SceneManager.LoadScene(1);
    }
}
