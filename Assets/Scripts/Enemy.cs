using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody enemyRb;
    private AudioSource _audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        _audioSrc = GetComponent<AudioSource>();
        enemyRb.velocity = Vector3.left * enemySpeed;
    }

    void OnDestroy()
    {
        EnemyManager._enemyManagerInstance.PlayDestructionNoise();
        //Debug.Log("Destroyed Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
