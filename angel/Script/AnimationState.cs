using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    Animator ani;
    public bool isBoss;
    // Use this for initialization
    void Start()
    {
        ani = GetComponent<Animator>();

    }
    public void SetAniWalkSpeedX(float _speedX)
    {
        ani.SetFloat("speedX", _speedX);

    }
    public void SetAniWalkSpeedY(float _speedY)
    {
        ani.SetFloat("speedY", _speedY);

    }
    public void SetAniWalkSpeed(float _speedX, float _speedY) {
        ani.SetFloat("speedX", _speedX);
        ani.SetFloat("speedY", _speedY);
    }
    public void animationBehavior(Player_Data _data, float _speedX, float _speedY)
    {
        ani.SetInteger("i_State", _data.spread_Method_Pointer);
        ani.SetFloat("speedX", _speedX);
        ani.SetFloat("speedY", _speedY);
    }
    public void animationBehavior(NPC_Basic_Data _data, float _speedX, float _speedY)
    {
      
        ani.SetInteger("i_State", _data.K_Pointer);
        ani.SetFloat("speedX", _speedX);
        ani.SetFloat("speedY", _speedY);
    }
    public void setBool(string name, bool _bool)
    {
        ani.SetBool(name, _bool);
    }
    public bool GetBoss()
    {
        if (isBoss) return true;
        else return false;
    }
}

