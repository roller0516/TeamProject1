﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public weaponData weaponData;
    public Button[] bt;
    public Slider[] WeaponGradeSlider;
    public string itemname;
    public int item_Attack;
    public int AttackUpgrade;

    private int StartAttackByUpgrade = 1;
    private int maxLevel = 10;
    
    
    private void Start()
    {
        item_Attack = weaponData.dataArray[0].Atk;
        //DataController.GetInstance().LoadUpgradeButton(this);
    }

    public void ButtonOn(string name)
    {
        itemname = name;
        for (int i = 0; i < weaponData.dataArray.Length; i++)
        {
            if (weaponData.dataArray[i].UID == name)//이름으로 찾는다
            {
                weaponData.dataArray[i].Isusing = true; //착용한상태로변경
                //레벨을 올려주고 

                UpgradeWeapon(weaponData.dataArray[i].Level + 1, i);

                if (i >= 1) // 나무막대기 이상의 급부터
                {

                    if (weaponData.dataArray[i].Isusing == true)
                        AttechmentPlayeritem(weaponData.dataArray[i].UID);
                    weaponData.dataArray[i-1].Isusing = false;
                }
                
                
            }
        }

        //DataController.GetInstance().SaveUpgradeButton(this);
    }
    public void Update()
    {
        UpgradeCount();
        AttachmentCheck();
        WeaponUpGradeSlider();
    }

    public void UpgradeWeapon(int num,int num2)
    {
        switch (num)
        {
            case 1:
                item_Attack = weaponData.dataArray[num2].Atk;
                break;
            case 2:
                item_Attack = weaponData.dataArray[num2].Atk_2;
                break;
            case 3:
                item_Attack = weaponData.dataArray[num2].Atk_3;
                break;
            case 4:
                item_Attack = weaponData.dataArray[num2].Atk_4;
                break;
            case 5:
                item_Attack = weaponData.dataArray[num2].Atk_5;
                break;
            case 6:
                item_Attack = weaponData.dataArray[num2].Atk_6;
                break;
            case 7:
                item_Attack = weaponData.dataArray[num2].Atk_7;
                break;
            case 8:
                item_Attack = weaponData.dataArray[num2].Atk_8;
                break;
            case 9:
                item_Attack = weaponData.dataArray[num2].Atk_9;
                break;
            case 10:
                item_Attack = weaponData.dataArray[num2].Atk_10;
                break;
        }
        
    }
    public void UpgradeCount()// 아이템갯수만큼 돌면서 level이 levelmax가 되는지 체크한다.
    {
        for (int i = 0; i < weaponData.dataArray.Length; i++)
        {
            if (weaponData.dataArray[i].Level < maxLevel && weaponData.dataArray[i].Level > 0) // 모든 아이템의 레벨이 0보다크고 맥스치보단 작다면
            {
                bt[i].interactable = true;//버튼 활성화
            }
            else if (weaponData.dataArray[i].Level >= maxLevel)
            {
                bt[i].interactable = false;

                if (i == weaponData.dataArray.Length - 1)// i가 마지막일때는 return으로 빠져나간다.
                    return;
                else if (weaponData.dataArray[i + 1].Level == 0)
                    bt[i + 1].interactable = true;
            }
        }
    }
    public void AttechmentPlayeritem(string itemname)
    {
        Player.Instance.skeletonRenderer.skeleton.SetAttachment("weapon", "Spear01");
    }
    public void AttachmentCheck()
    {
        for (int i = 0; i < weaponData.dataArray.Length; i++)
            if (weaponData.dataArray[i].Isusing == true)
                AttechmentPlayeritem(weaponData.dataArray[i].UID);
    }
    public void WeaponUpGradeSlider()
    {
        for (int i = 0; i < weaponData.dataArray.Length; i++)
        {
            WeaponGradeSlider[i].value = (float)weaponData.dataArray[i].Level / (float)maxLevel;
        }
    }

}
