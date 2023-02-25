using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIEnemyPanel : MonoBehaviour, IObserver 
{
    [SerializeField] List<GameObject> m_enemyUI;

    private static UIEnemyPanel m_Instance;

    private GameObject bottomPanel;
    private GameObject actionPanel;
    private List<TextMeshProUGUI> m_curEnemyHP;

    public static UIEnemyPanel Instance { get => m_Instance; set => m_Instance = value; }

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
        {
            Destroy(this);
            return;
        }

        m_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bottomPanel = GameObject.FindGameObjectWithTag("BottomPanel");
        actionPanel = bottomPanel.transform.Find("ActionPanel").gameObject;
        actionPanel.SetActive(false);
        m_curEnemyHP = new List<TextMeshProUGUI>();
        foreach (GameObject enemyUI in m_enemyUI)
        {
            var healthTransform = enemyUI.transform.Find("Health");
            m_curEnemyHP.Add(healthTransform.Find("MemberCurHP").GetComponent<TextMeshProUGUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressEnemy(string enemyTag)
    {
        BattleManager.Instance.EnemyPositionTag = enemyTag;
        actionPanel.SetActive(!actionPanel.activeSelf);
    }

    public void ClosedActionPanel()
    {
        actionPanel.SetActive(false);
    }

    public void UpdateEnemyHP(int newHP, int enemyIdx)
    {
        m_curEnemyHP[enemyIdx].text = newHP.ToString();
    }
    

    public void OnNotify(PlayerAction action, GameObject objRef = null, Payload payload = null)
    {
        switch (action)
        {
            case PlayerAction.Attack:
                ClosedActionPanel();
                
                break;
        }
    }

}
