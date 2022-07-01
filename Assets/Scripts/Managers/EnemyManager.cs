using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager _enemyManagerInstance;
    public GameObject enemyPrefab;
    public float maxY;
    public float minY;
    public float spawnInterval;
    private float spawnX = 4.65f;  // Must always spawn on this x to stay out of sight
    private AudioSource _audioSrc;
    
    void Awake()
    {
        if(_enemyManagerInstance != null)
            Destroy(this);
        else
            _enemyManagerInstance = this;

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
        StartCoroutine(SpawnEnemy());
    }

    public void PlayDestructionNoise()
    {
        _audioSrc.Play();
    }

    IEnumerator SpawnEnemy() 
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnInterval);
            // Calculate a new random Y
            float randY = Random.Range(minY, maxY + 0.01f);
            //Debug.Log("New enemy spawning");
            Instantiate(enemyPrefab, new Vector3(spawnX, randY, -7f), Quaternion.identity);
        }
    }
}
