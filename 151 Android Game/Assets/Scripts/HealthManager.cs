using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public MoveUpwardsManager mumana;
    public ScoreManager smana;
    public GameManager gmana;
    public MoveManager mmana;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("DEAD");
        Time.timeScale = 0;
        //mumana.Died();

    }

}
