using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Bartype
{
    healthBar
}
public class PlayerBar : MonoBehaviour
{
    private Slider slider;
    public Bartype type;
    
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = character.MAX_HEALTH;
    }

    
    void Update()
    {
        slider.value = GameObject.Find("Character").GetComponent<character>().getHealth();
        
    }
}
