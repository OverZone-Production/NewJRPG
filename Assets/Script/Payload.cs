using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload
{
    private int m_id;
    private float m_damage;
    private string m_tag;

    public Payload(int id = -1, float damage = 0, string tag = null)
    {
        m_id = id;
        m_damage = damage;
        m_tag = tag;
    }

    public int Id { get => m_id; set => m_id = value; }
    public float Damage { get => m_damage; set => m_damage = value; }
    public string Tag { get => m_tag; set => m_tag = value; }
}
