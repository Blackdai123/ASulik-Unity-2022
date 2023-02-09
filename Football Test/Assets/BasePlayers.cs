using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayers : Singleton<BasePlayers>
{
    public readonly List<Players> easyPlayers = new List<Players>()
    {
        new Players("Нападающий", "Франция", "Французкая", "ПСЖ", "Mbappe"),

        new Players("Полузащитник", "Франция", "Итальянская", "Ювентус", "Pogba")

        //new Players("Нападающий", "Аргентина", "Французкая", "ПСЖ", "Messi"),

        //new Players("Нападающий", "Франция", "Испанская", "Реал Мадрид", "Benzema"),

        //new Players("Нападающий", "Норвегия", "АПЛ", "Ман. Сити", "Holland"),

        //new Players("Полузащитник", "Хорватия", "Испанская", "Реал Мадрид", "Modric"),

        //new Players("Полузащитник", "Бельгия", "АПЛ", "Реал Мадрид", "De Bruyne"),

        //new Players("Нападающий", "Польша", "Испанская", "Барселона", "Lewandowski"),

        //new Players("Нападающий", "Бразилия", "Испанская", "Реал Мадрид", "Vinicius"),

        //new Players("Вратарь", "Бельгия", "Испанская", "Реал Мадрид", "Courtis"),

        //new Players("Нападающий", "Егитеп", "АПЛ", "Ливерпуль", "Salah"),

        //new Players("Нападающий", "Сенегал", "Немецкая", "Бавария", "Mane"),

        //new Players("Нападающий", "Бразилия", "Французкая", "ПСЖ", "Neymar"),

        //new Players("Нападающий", "Анлия", "АПЛ", "Тотенхем", "Kean"),

        //new Players("Полузащитник", "Англия", "Немецкая", "Борусия", "Bellingham"),

        //new Players("Полузащитник", "Бразилия", "Испанская", "Реал Мадрид", "Casemiro")
    };

    public Players GiveRandEasyPlayer()
    {
        Players player;

        player = easyPlayers[Random.Range(0, easyPlayers.Count-1)];
        
        return player;
    }

}
