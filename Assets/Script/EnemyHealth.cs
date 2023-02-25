using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float m_maxHP = 100;

    private float m_currentHP;

    public float MaxHP { get => m_maxHP; set => m_maxHP = value; }
    public float CurrentHP { get => m_currentHP; set => m_currentHP = value; }

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHP = MaxHP;
       
    }

    public void TakeDamage(float damage)
    {
        m_currentHP -= damage;

        if (m_currentHP < 0)
        {
            CurrentHP = 0;
            Dead();
        }

        

        print("Enemy HP: " + CurrentHP.ToString());
    }

    public void RecoveryHP(float point)
    {
        m_currentHP += point;

        if (m_currentHP > m_maxHP)
        {
            m_currentHP = m_maxHP;
        }

        // Update CurrentHP UI
    }

    private void Dead()
    {
        print("Enemy Dead!");
    }

    
}
