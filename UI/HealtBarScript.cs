using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    public Slider healtBarSlider;

    public void Start() {}
    public void Update() {}

    public void SetHealt(int currentHealt, int maxHealt) {

        healtBarSlider.maxValue = maxHealt;
        healtBarSlider.value = currentHealt;
    }

    public void getDamage(int damage) {
        healtBarSlider.value -= damage;
    }

    public void getHeal(int heal) {

        healtBarSlider.value = heal;
    }
}
