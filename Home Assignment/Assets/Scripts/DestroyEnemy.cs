using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour, ITakeDamage
{

    public void ApplyDamage(int hitpoints, bool isCharged)
    {
        GameData.Score += hitpoints;
        Debug.Log("Score: " + GameData.Score.ToString());
        Destroy(this.gameObject);
        GameData.PlayerHealth +=10;
        GameData.Kills += 1;
    }

}


