using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public List<float> autoClickersLastTimeLittle = new List<float>();
    public List<float> autoClickersLastTimeBig = new List<float>();
    public int autoClickerPriceLittle;
    public int autoClickerPriceBig;
    public int heavenlyPuchPrice;
    public TextMeshProUGUI littleQuantityText;
    public TextMeshProUGUI bigQuantityText;

    void Update()
    {
        for (int i = 0; i < autoClickersLastTimeLittle.Count; i++)
        {
            if (Time.time - autoClickersLastTimeLittle[i] >= 1.0f)
            {
                autoClickersLastTimeLittle[i] = Time.time;
                EnemyManager.instance.curEnemy.Damage();
            }
        }
        
        for (int i = 0; i < autoClickersLastTimeBig.Count; i++)
        {
            if (Time.time - autoClickersLastTimeBig[i] >= 1.0f)
            {
                autoClickersLastTimeBig[i] = Time.time;
                EnemyManager.instance.curEnemy.DamageBig();
            }
        }
    }

    public void OnBuyHeavenlyPunch()
    {
        if (GameManager.instance.gold >= heavenlyPuchPrice)
        {
            GameManager.instance.TakeGold(heavenlyPuchPrice);
            EnemyManager.instance.curEnemy.MaxDamage();
        }
    }

    public void OnBuyLittleAutoClicker()
    {
        if (GameManager.instance.gold >= autoClickerPriceLittle)
        {
            GameManager.instance.TakeGold(autoClickerPriceLittle);
            autoClickersLastTimeLittle.Add(Time.time);
            littleQuantityText.text = "x " + autoClickersLastTimeLittle.Count.ToString();
        }
    }
    
    public void OnBuyBigeAutoClicker()
    {
        if (GameManager.instance.gold >= autoClickerPriceBig)
        {
            GameManager.instance.TakeGold(autoClickerPriceBig);
            autoClickersLastTimeBig.Add(Time.time);
            bigQuantityText.text = "x " + autoClickersLastTimeBig.Count.ToString();
        }
    }
}
