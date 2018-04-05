using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float TotalHp;
    public float CurrentHp;

    public void TakeDamage(float damage)
    {
        CurrentHp -= damage;
        if (CurrentHp < 0)
        {
            transform.localScale = new Vector3(0, 1, 1);
            LevelManager lm = FindObjectOfType<LevelManager>();
            lm.LoadLevel("Lose");
        }
        else transform.localScale = new Vector3((CurrentHp / TotalHp), 1, 1);
    }

    public void setTotalHP(float hp)
    {
        TotalHp = hp;
        CurrentHp = hp;
    }


}
