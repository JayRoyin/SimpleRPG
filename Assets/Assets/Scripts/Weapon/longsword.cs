using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longsword : Weapon
{
    public const string ANIMATOR_IS_ATTACK = "isAttack";//¾²Ì¬³£Á¿

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Attack();
        //}
    }

    public override void Attack()
    {
        animator.SetTrigger(ANIMATOR_IS_ATTACK);
        base.Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit with" + other.name);
            //other.GetComponent<Enemy>().TakeDamage(attackValue);
        }
    }
}
