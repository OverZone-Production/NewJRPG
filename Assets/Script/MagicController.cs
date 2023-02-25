using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    private Rigidbody2D rb2d;
    private GameObject target;
    private string targetTag;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targetTag = BattleManager.Instance.EnemyPositionTag;
        target = GameObject.FindGameObjectWithTag(targetTag);
        enemyController = target.GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        rb2d.position = Vector2.MoveTowards(rb2d.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            enemyController.EnemyTookDamageEffect();
            Destroy(gameObject);
        }
    }
}
