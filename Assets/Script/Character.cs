using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] string m_name = "No name";
    [SerializeField] float m_damage = 10f;
    private Health m_health;
    private UIPartyPanel m_uiPartyPanel;
    private int m_PlayerPosition;

    public string Name { get => m_name; set => m_name = value; }
    public Health Health { get => m_health; set => m_health = value; }
    public int PlayerPosition { get => m_PlayerPosition; set => m_PlayerPosition = value; }
    public float Damage { get => m_damage; set => m_damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_health = GetComponent<Health>();
        m_uiPartyPanel = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIPartyPanel>();
        OnCharacterAdded();
    }

    private void OnCharacterAdded()
    {
        m_uiPartyPanel.SetMemberNameAtPosition(m_name, m_PlayerPosition);
        m_uiPartyPanel.SetCurrentHP(m_health.CurrentHP, PlayerPosition);
        m_uiPartyPanel.SetMaxHP(m_health.MaxHP, PlayerPosition);
    }
}
