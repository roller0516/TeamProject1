﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Boss : MonoBehaviour
{
    public enum AnimState //몬스터 상태
    {
        Idle, move, hit,die
    }

    private SkeletonRenderer skeletonRenderer;
    private AnimState _AniState;
    private Rigidbody rig;
    private Animator ani;
    private Transform target;
    private int hitCount = 0;
    private int MaxhitCount = 1;

    public GameObject damageText;
    public float knockbackPower = 1;
    public float moveSpeed = 0.5f;
    public int Hp;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }


    private void Start()
    {

        ani = GetComponent<Animator>(); // 애니메이션
        skeletonRenderer = GetComponent<SkeletonRenderer>();//스파인



        target = Player.Instance.transform; // 플레이어를 타겟으로 한다

        _AniState = AnimState.move;// 애니메이션 변경

        // 무기변경 랜덤으로 변경

    }

    private void Update()
    {
        transform.Translate(new Vector2(-1f * moveSpeed * Time.deltaTime, 0));//왼쪽으로 전진 
        SetCurrentAnimation(_AniState); // 실시간으로 애니메이션을 받아온다.
        
        Distance();//실시간으로 타겟과의 거리를 받아온다
    }

    private void SetCurrentAnimation(AnimState _state) //애니메이션 
    {
        switch (_state)
        {
            case AnimState.Idle:
                ani.SetInteger("AniState", (int)AnimState.Idle);
                break;
            case AnimState.move:
                ani.SetInteger("AniState", (int)AnimState.move);
                break;
            case AnimState.hit:
                ani.SetTrigger("hit");
                break;
            case AnimState.die:
                ani.SetBool("Die", true);
                break;
        }
    }

    public void Distance()// 플레이어와의 거리를 계산한다.
    {
        float d = Vector2.Distance(target.position, transform.position);

        if (d > 3f && d < 4f) // 거리가 2보단크고 3보다 작을때 2~ 3.9
        {
            Player.Instance.Monster = this.gameObject;
            Player.Instance.moveSpeed = 3f;
            Player.Instance.moveSpeed = Mathf.Lerp(Player.Instance.moveSpeed, 0, Time.deltaTime);
            Player.Instance._AniState = Player.AnimState.moveSpeedup;
        }
        else if (d > 2f && d <= 3f) // 2.1 ~ 3f
        {
            Player.Instance._AniState = Player.AnimState.Idle;

            if (_AniState == AnimState.die) // 몬스터의 애니메이션이 Die면 속도가 0
                moveSpeed = 0f;
            else // 다른 애니메이션이면 move 속도 2
            {
                _AniState = AnimState.move;
                moveSpeed = 2f;
            }
        }
        else if (d <= 2f && Hp > 0) // 2보다 크거나 같고 hp가 0보다 클때
        {
            Player.Instance._AniState = Player.AnimState.Attack;
            Player.Instance.moveSpeed = 0f;
            _AniState = AnimState.Idle;
            moveSpeed = 0;
        }
        else if (d > 4f) // 거리가 4보다 클때
        {
            Player.Instance._AniState = Player.AnimState.move;
            Player.Instance.moveSpeed = 2f;
            moveSpeed = 2f;
            _AniState = AnimState.move;
        }

    }
    public void TakeDamage(int damage) // 데미지 함수
    {
        Instantiate(damageText, new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0), Quaternion.identity);// 데미지 텍스트 생성
        DamageText dam = FindObjectOfType<DamageText>();
        dam.Damage = damage;
        print(hitCount);
        
        Hitcount(hitCount);// 애니메이션 변경
        if (hitCount >= 2)
            hitCount = 0;

        KnockBack();

        Hp -= damage;// hp 뺌
        hitCount++;
        if (Hp <= 0)
        {
            _AniState = AnimState.die;
            MonsterSpawn._instance.MonsterCount--;
            MonsterSpawn._instance.boss_IsDie = true;
            Player.Instance._AniState = Player.AnimState.move;
            Player.Instance.moveSpeed = 2f;
            Destroy(this.gameObject, 2f);
        }
    }
    public void KnockBack()// 넉백
    {
        rig.AddForce(new Vector3(2.5f, 2, 0) * knockbackPower, ForceMode.Impulse);
    }

    public void SetAttechment(int num) // 무기변경
    {
        skeletonRenderer.skeleton.SetAttachment("weapon 1", "weapon " + num);
    }
    public void Hitcount(int count)
    {
        ani.SetFloat("Blend", count);
        _AniState = AnimState.hit;
        
    }
}


