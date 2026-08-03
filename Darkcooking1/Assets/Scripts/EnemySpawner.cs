using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; //lista de Prefabs dos inimigos.

    public float spawnInterval = 2f; //tempo entre cada spawn.

    public float minX = -8f;

    public float maxX = 8f; //posição do spawn do inimigo

    public float spawnY = 6f;

    private float timer = 0f; //contador de tempo.

    void Update()
    {
        timer += Time.deltaTime; //soma o tempo entre os frames.

        if (timer >= spawnInterval)
        {
            SpawnEnemy();

            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        //escolhe uma posição X aleatória.
        float randomX = Random.Range(minX, maxX);

        //cria a posição onde o inimigo nascerá.
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        //escolhe aleatoriamente um dos Prefabs da lista.
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        //cria o inimigo escolhido.
        Instantiate(
            enemyPrefabs[randomEnemy],
            spawnPosition,
            Quaternion.identity
        );
    }
}