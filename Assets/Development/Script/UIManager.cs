using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text InGame_killCountText;
    public Text InGame_playerHPText;
    public Slider InGame_playerHPSlider;
    public Text InGame_playTimeText;
    public Text WaveText;
    public Text GameOverUI_waveText;
    public Text GameOverUI_timeText;
    public Text GameOverUI_killCountText;
    public Text GameClearUI_waveText;
    public Text GameClearUI_timeText;
    public Text GameClearUI_killCountText;


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
    }

    void Update()
    {
    }

    public void UpdateKillCount(int kill_count)
    {
        if (InGame_killCountText == null) return;
        InGame_killCountText.text = string.Format("Kill: {0}", kill_count);
    }

    public void UpdateHP(int hp, int max_hp)
    {
        if (InGame_playerHPText != null)
        {
            InGame_playerHPText.text = string.Format("HP: {0} / {1}", hp, max_hp);
        }
        if (InGame_playerHPSlider != null)
        {
            InGame_playerHPSlider.maxValue = max_hp;
            InGame_playerHPSlider.value = hp;
        }
    }

    public void UpdateWaveText(int wave, int max_wave)
    {
        if (WaveText == null) return;
        WaveText.text = string.Format("Wave: {0} / {1}", wave, max_wave);
    }

    public void SetGameOverUI(int wave, int seconds, int kill_count)
    {
        GameOverUI_waveText.text = string.Format("Wave: {0}", wave);
        GameOverUI_timeText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        GameOverUI_killCountText.text = string.Format("Kill: {0}", kill_count);
    }

    public void SetGameClearUI(int wave, int seconds, int kill_count)
    {
        GameClearUI_waveText.text = string.Format("Wave: {0}", wave);
        GameClearUI_timeText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        GameClearUI_killCountText.text = string.Format("Kill: {0}", kill_count);
    }
}
