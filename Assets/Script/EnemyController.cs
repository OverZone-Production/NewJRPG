using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void EnemyTookDamageEffect()
    {
        StartCoroutine(tookDamageEffect());
    }

    IEnumerator tookDamageEffect()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    

}
