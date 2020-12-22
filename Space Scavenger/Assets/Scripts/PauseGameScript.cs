using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void PauseGame()
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
}
