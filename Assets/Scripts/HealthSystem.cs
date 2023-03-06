using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public Sprite redbull, redbullEmpty;
    public Image life1, life2, life3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerLife.instance.Health)
        {
            case 0:
                life1.sprite = redbullEmpty;
                life2.sprite = redbullEmpty;
                life3.sprite = redbullEmpty;
                break;
            case 1:
                life1.sprite = redbull;
                life2.sprite = redbullEmpty;
                life3.sprite = redbullEmpty;
                break;
            case 2:
                life1.sprite = redbull;
                life2.sprite = redbull;
                life3.sprite = redbullEmpty;
                break;
            case 3:
                life1.sprite = redbull;
                life2.sprite = redbull;
                life3.sprite = redbull;
                break;
        }
    }
}
