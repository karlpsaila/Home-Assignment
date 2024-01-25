using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, ITakeDamage
{
    public void ApplyDamage(int hitpoints, bool isCharged)
    {
        if (isCharged == false)
        {
            EnemyScript _enemy = GetComponent<EnemyScript>();
            _enemy._strength--;
            StartCoroutine(ApplyDamageEffect());


            if (_enemy._strength <= 0)
            {
                GameData.Score += hitpoints;
                GameData.Kills ++;
                Debug.Log("ScoreY: " + GameData.Score.ToString());
                Destroy(this.gameObject);
            }
        }
        else
        {
            EnemyScript _enemy = GetComponent<EnemyScript>();
            _enemy._strength -= 5;
            StartCoroutine(ApplyDamageEffect());
            if (_enemy._strength <= 0)
            {
                GameData.Score += hitpoints;
                GameData.Kills++;
                Debug.Log("Score: " + GameData.Score.ToString());
                Destroy(this.gameObject);
            }
        }
        

    }



    IEnumerator ApplyDamageEffect()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        Color enemyColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        // Reset the color back to normal (you can adjust the color as needed)
        spriteRenderer.color = enemyColor;
    }
}