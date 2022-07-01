using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    BoxCollider enemyGoal;

    void Start()
    {
        enemyGoal = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
            ScoreManager._scoreManagerInstance.DecreaseLives();
    }
}
