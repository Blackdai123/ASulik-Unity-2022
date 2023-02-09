using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayers : Singleton<BasePlayers>
{
    public readonly List<Players> easyPlayers = new List<Players>()
    {
        new Players("����������", "�������", "����������", "���", "Mbappe"),

        new Players("������������", "�������", "�����������", "�������", "Pogba")

        //new Players("����������", "���������", "����������", "���", "Messi"),

        //new Players("����������", "�������", "���������", "���� ������", "Benzema"),

        //new Players("����������", "��������", "���", "���. ����", "Holland"),

        //new Players("������������", "��������", "���������", "���� ������", "Modric"),

        //new Players("������������", "�������", "���", "���� ������", "De Bruyne"),

        //new Players("����������", "������", "���������", "���������", "Lewandowski"),

        //new Players("����������", "��������", "���������", "���� ������", "Vinicius"),

        //new Players("�������", "�������", "���������", "���� ������", "Courtis"),

        //new Players("����������", "������", "���", "���������", "Salah"),

        //new Players("����������", "�������", "��������", "�������", "Mane"),

        //new Players("����������", "��������", "����������", "���", "Neymar"),

        //new Players("����������", "�����", "���", "��������", "Kean"),

        //new Players("������������", "������", "��������", "�������", "Bellingham"),

        //new Players("������������", "��������", "���������", "���� ������", "Casemiro")
    };

    public Players GiveRandEasyPlayer()
    {
        Players player;

        player = easyPlayers[Random.Range(0, easyPlayers.Count-1)];
        
        return player;
    }

}
