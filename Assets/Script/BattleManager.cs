using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;
    private string enemyPositionTag;
    private GameObject targetEnemy;

    [SerializeField] Transform[] playerPosition;
    [SerializeField] GameObject[] teamMember;

    public static BattleManager Instance { get => instance; set => instance = value; }
    public string EnemyPositionTag { get => enemyPositionTag; set => enemyPositionTag = value; }
    public Transform[] PlayerPosition { get => playerPosition; set => playerPosition = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null && instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlaceTeamMemberToPosition();
    }

    private void PlaceTeamMemberToPosition()
    {
        for (int i=0; i<teamMember.Length; i++)
        {
            GameObject member = Instantiate(teamMember[i], playerPosition[i].position, Quaternion.identity);

            member.GetComponent<Character>().PlayerPosition = i;
        }
    }

    public void setTargetEnemy()
    {

    }
}
