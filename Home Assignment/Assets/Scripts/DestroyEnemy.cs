using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour, ITakeDamage
{

    public void ApplyDamage(int hitpoints, bool isCharged)
    {
        GameData.Score += hitpoints;
        GameData.Kills += hitpoints;
        GameData.PlayerHealth += 10;
        Playerscript playerScript = FindObjectOfType<Playerscript>();
        if (playerScript != null)
        {
            playerScript.UpdateHealthBar();
        }
        Debug.Log("Score: " + GameData.Score.ToString());
        Destroy(this.gameObject);
    }


}


