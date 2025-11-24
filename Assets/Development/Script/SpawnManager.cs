using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject monsterPrefab;
    public GameObject zombiePrefab;
    public GameObject itemPrefab;
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

        StartCoroutine(Spawn_Monster_Coroutine());
        StartCoroutine(Spawn_Item_Coroutine());
    }

    void Update()
    {

    }
    IEnumerator Spawn_Monster_Coroutine()
    {
        if (GameManager.instance != null && GameManager.instance.CurrentState == GameState.GAME_PLAY)
        {
            int wave = GameManager.instance.wave;
            float xPos = Random.Range(-4.0f, 4.0f);
            float zPos = Random.Range(33.5f, 55.5f);
            if (Random.Range(0.0f, 1.0f) > (1 / (wave * 0.2f + 0.8f)))
            {
                Instantiate(zombiePrefab, new Vector3(xPos, 0.32f, zPos), Quaternion.Euler(0, 180, 0));
            }
            else
                Instantiate(monsterPrefab, new Vector3(xPos, 0.32f, zPos), Quaternion.Euler(0, 180, 0));

            float wait = Mathf.Max(0.01f, Random.Range(1f, 1.5f) / (1 + wave * 0.3f));
            yield return new WaitForSeconds(wait);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(Spawn_Monster_Coroutine());
    }

    IEnumerator Spawn_Item_Coroutine()
    {
        if (GameManager.instance != null && GameManager.instance.CurrentState == GameState.GAME_PLAY)
        {
            float zPos = Random.Range(33.5f, 55.5f);
            Instantiate(itemPrefab, new Vector3(0, 3, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(Spawn_Item_Coroutine());
    }
}
