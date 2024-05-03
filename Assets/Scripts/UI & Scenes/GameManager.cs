using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Victoria Monzi - Ivo Joaquín Aguilera
public class GameManager : MonoBehaviour
{
    public static GameManager InstanceGameManager;

    public List<string> allLevels = new List<string>();

    [SerializeField]    GameObject      _menuPausa;
    [SerializeField]    BaseCharacter   _characterController;
                        bool            _menu = false;
                        static string   _currentScene;

    private void Awake()
    {
        if (InstanceGameManager) Destroy(this);
        else InstanceGameManager = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level1" && SceneManager.GetActiveScene().name != "Level2")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            if(SceneManager.GetActiveScene().name != "Lose") PlayerPrefs.DeleteKey("currentScene");
        }
        else
        {
            PlayerPrefs.SetString("currentScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("currentScene")) _currentScene = PlayerPrefs.GetString("currentScene");
    }

    private void Update()
    {
        if (_menuPausa)
        {
            //Menu de pausa
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _menu = !_menu;
            }
            if (_menu)
            {
                _menuPausa.SetActive(true);
                _characterController.UpdateFeedback.StopSound();

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                MenuDesactivado();
            }
        }
    }
    //Botones
    public void LoadLevel(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    //ExitGame
    public void ExitGame()
    {
        Application.Quit();
    }
    //Evento para continuar
    public void Continuar()
    {
        MenuDesactivado();
        _menu = false;
    }
    //Desactivar el Menu de pausa
    public void MenuDesactivado()
    {
        _menuPausa.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(_currentScene);
    }


    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
