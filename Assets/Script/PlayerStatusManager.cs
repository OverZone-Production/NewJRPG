using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    private static PlayerStatusManager m_instance;
    private List<Health> m_playersHealth = new List<Health>();
    public static PlayerStatusManager Instance { get => m_instance; private set => m_instance = value; }

    void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this);
            return;
        }

        m_instance = this;
    }

}
    
