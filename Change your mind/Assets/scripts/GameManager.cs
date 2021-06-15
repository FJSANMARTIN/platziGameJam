using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState
{
    menu,inGame,gameOver
}
public class GameManager : MonoBehaviour
{

    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public Canvas winCanvas;
    public GameState currentGameState;
    public Camera camara;
    public Canvas pauseCanvas;

    public static GameManager sharedInstance;

    public character characterScript;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        Application.targetFrameRate = 60;
    }

    void Start()
    {
         camara.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
        





    }
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1");

     

        
        
        

    }

    public void GameStart()
    {
        Time.timeScale = 1;
        gameOverCanvas.enabled = false;

        winCanvas.enabled = false;

        pauseCanvas.enabled = false;

        setGameState(GameState.inGame);
    }

    public void pause()
    {
        inGameCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void continueGame()
    {
        pauseCanvas.enabled = false;
        inGameCanvas.enabled = true;
        Time.timeScale = 1;
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void options()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        inGameCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        camara.GetComponent<AudioSource>().enabled = false;
        setGameState(GameState.gameOver);

    }

    public void FinishGame()
    {
        winCanvas.enabled = true;
        camara.GetComponent<AudioSource>().enabled = false;
        
        
    }



    private void setGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {

        }
        else if(newGameState == GameState.inGame)
        {
            currentGameState = GameState.inGame;
        }
        if(newGameState == GameState.gameOver)
        {
            currentGameState = GameState.gameOver;
        }
        this.currentGameState = newGameState;

    }

    


}
