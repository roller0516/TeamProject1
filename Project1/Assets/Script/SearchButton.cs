﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchButton : MonoBehaviour
{
    public string Name;
    public GameObject go;
    public int RandomRange1;
    public int ItemRandomRange;
    public int probability;
    SpecialitemList sl;
    
    private void Start()
    {
        sl = GameObject.Find("Canvas").GetComponent<SpecialitemList>();
    }
    public void PlayerTeleport()
    {
        //go.transform.position = new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y-20f, Player.Instance.transform.position.z);
        Win();
        if (RandomRange1 <= 5)
        {
            print("아이템 얻음");
        }
    }

    public void Win()
    {
        switch (Name)
        {
            case "하북":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[0].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[0].itemCount++;
                        print(sl.Sp_item[0].itemCount);
                    }
                    else if (sl.Sp_item[1].itemCount < 10 && Name == "하북" && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[1].itemCount++;
                        print(sl.Sp_item[1].itemCount);
                    }
                }
                break;
            case "청서":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[2].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[2].itemCount++;
                        print(sl.Sp_item[2].itemCount);
                    }
                    else if (sl.Sp_item[3].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[3].itemCount++;
                        print(sl.Sp_item[3].itemCount);
                    }
                }
                break;

            case "중원":
                
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[4].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[4].itemCount++;
                        print(sl.Sp_item[4].itemCount);
                    }
                    else if (sl.Sp_item[5].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[5].itemCount++;
                        print(sl.Sp_item[5].itemCount);
                    }
                }
                 
                
                break;

            case "강동":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[6].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[6].itemCount++;
                        print(sl.Sp_item[6].itemCount);
                    }
                    else if (sl.Sp_item[7].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[7].itemCount++;
                        print(sl.Sp_item[7].itemCount);
                    }
                }
                break;

            case "관중":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[8].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[8].itemCount++;
                        print(sl.Sp_item[8].itemCount);
                    }
                    else if (sl.Sp_item[9].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[9].itemCount++;
                        print(sl.Sp_item[9].itemCount);
                    }
                }
                break;
            case "형북":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[10].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[10].itemCount++;
                        print(sl.Sp_item[10].itemCount);
                    }
                    else if (sl.Sp_item[11].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[11].itemCount++;
                        print(sl.Sp_item[11].itemCount);
                    }
                }
                break;
            case "형남":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[12].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[12].itemCount++;
                        print(sl.Sp_item[12].itemCount);
                    }
                    else if (sl.Sp_item[13].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[13].itemCount++;
                        print(sl.Sp_item[13].itemCount);
                    }
                }
                break;
            case "파촉":
                if (RandomRange1 <= 5)
                {
                    if (sl.Sp_item[14].itemCount < 10 && ItemRandomRange <= 50)
                    {
                        sl.Sp_item[14].itemCount++;
                        print(sl.Sp_item[14].itemCount);
                    }
                    else if (sl.Sp_item[15].itemCount < 10 && ItemRandomRange >= 51)
                    {
                        sl.Sp_item[15].itemCount++;
                        print(sl.Sp_item[15].itemCount);
                    }
                }
                break;
        }
    }
    public void lose()
    {

        
    }
    private void Update()
    {
        RandomRange1 = Random.Range(0,101);
        ItemRandomRange = Random.Range(0, 101);

    }
}