using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour, ITakeDamage
{


    public void ApplyDamage(int hitpoints, bool isCharged)
    {
        //GameData.Score += hitpoints;
        //Debug.Log("Score: " + GameData.Score.ToString());
        GameManager.Instance.OnEnemyDie(hitpoints);
        Destroy(this.gameObject);
    }



}


