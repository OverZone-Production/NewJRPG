using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float m_maxHP = 100;

    private UIPartyPanel m_uiPartyPanel;
    private float m_currentHP;
    private int m_playerPosition;

    public float MaxHP { get => m_maxHP; set => m_maxHP = value; }
    public float CurrentHP { get => m_currentHP; set => m_currentHP = value; }

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHP = MaxHP;
        m_uiPartyPanel = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIPartyPanel>();
        m_playerPosition = GetComponent<Character>().PlayerPosition;
    }

    public void TakeDamage(float damage)
    {
        m_currentHP -= damage;
        
        if (m_currentHP < 0)
        {
            Dead();
        }

        m_uiPartyPanel.SetCurrentHP(m_currentHP, m_playerPosition);
    }

    public void RecoveryHP (float point)
    {
        m_currentHP += point;

        if (m_currentHP > m_maxHP)
        {
            m_currentHP = m_maxHP;
        }

        // Update CurrentHP UI
        m_uiPartyPanel.SetCurrentHP(m_currentHP, m_playerPosition);
    }

    private void Dead()
    {
        print("Dead!");
    }
}
