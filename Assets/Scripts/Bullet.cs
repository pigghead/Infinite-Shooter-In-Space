using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        StartCoroutine(DestroyMe());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            ScoreManager._scoreManagerInstance.IncreaseScore();
            Destroy(col.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(3f);
        Destroy(transform.parent.gameObject);
    }
}
