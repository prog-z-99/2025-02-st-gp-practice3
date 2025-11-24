using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MAIN_MENU,
    GAME_PLAY,
    GAME_OVER,
    GAME_CLEAR
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState CurrentState { get; private set; }
    private const float STATE_CHANGE_DELAY = 0.1f;

    public GameObject mainMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public int bullet_damage;
    public int bullet_count;
    public float bullet_time;
    private float bulletAS = 0.0f;
    float play_time = 0f;
    int maxHP = 10;
    int hp = 0;
    int killCount = 0;
    public int wave = 1;
    public int MAX_ROUND = 5;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        ChangeState(GameState.MAIN_MENU); ;
    }

    void Update()
    {
        if (CurrentState != GameState.GAME_PLAY)
        {
            return;
        }
        Debug.Log(wave);
        if (killCount / 10 > wave)
        {
            AdvanceWave();
        }
    }

    private void ChangeState(GameState newState)
    {
        StartCoroutine(TransitionToState(newState));
    }

    IEnumerator TransitionToState(GameState newState)
    {
        yield return new WaitForSecondsRealtime(STATE_CHANGE_DELAY);
        CurrentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        HideAllMenu();
        switch (CurrentState)
        {
            case GameState.MAIN_MENU:
                Time.timeScale = 0f;
                mainMenuUI.SetActive(true);
                FillUpHP();
                break;
            case GameState.GAME_PLAY:
                inGameUI.SetActive(true);
                Time.timeScale = 1f;
                break;
            case GameState.GAME_OVER:
                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
                UIManager.instance.SetGameOverUI(wave, (int)play_time, killCount);
                break;
            case GameState.GAME_CLEAR:
                gameClearUI.SetActive(true);
                Time.timeScale = 0f;
                UIManager.instance.SetGameClearUI(wave, (int)play_time, killCount);
                break;
        }
    }

    public void HideAllMenu()
    {
        mainMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameClearUI.SetActive(false);
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeToPlaying()
    {
        ChangeState(GameState.GAME_PLAY);
    }

    public void ChangeToGameOver()
    {
        ChangeState(GameState.GAME_OVER);
    }

    public void ChangeToGameClear()
    {
        ChangeState(GameState.GAME_CLEAR);
    }

    void AdvanceWave()
    {

        if (wave >= MAX_ROUND)
        {
            ChangeToGameClear();
            return;
        }

        wave++;

        FillUpHP();
        UIManager.instance.UpdateWaveText(wave, MAX_ROUND);
    }

    public void GetItem(string tag)
    {
        switch (tag)
        {
            case ItemManager.ATK_Speed.tag:
                bullet_time = 1 / (1 + bulletAS);
                bulletAS = bulletAS + 0.3f;
                break;
            case ItemManager.ATK_Count.tag:
                bullet_count++;
                break;
            case ItemManager.ATK_Damage.tag:
                bullet_damage++;
                break;
        }
    }

    public void DecreaseHP(int value = 1)
    {
        hp--;
        UIManager.instance.UpdateHP(hp, maxHP);
        if (hp == 0)
        {
            ChangeToGameOver();
        }
    }

    public void IncreaseHP(int value = 1)
    {
        hp = Math.Min(hp + value, maxHP);
        UIManager.instance.UpdateHP(hp, maxHP);
    }

    public void FillUpHP()
    {
        hp = maxHP;
        UIManager.instance.UpdateHP(hp, maxHP);
    }

    public void IncreaseKillCount(int count = 1)
    {
        killCount += count;
        UIManager.instance.UpdateKillCount(killCount);
    }

}