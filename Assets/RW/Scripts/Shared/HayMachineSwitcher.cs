using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    private int selectedIndex;
    public GameObject blueHayMachine, yellowHayMachine, redHayMachine;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedIndex++;
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length;
        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex;

        blueHayMachine.SetActive(false);
        yellowHayMachine.SetActive(false);
        redHayMachine.SetActive(false);
        
        if (GameSettings.hayMachineColor == HayMachineColor.Blue) blueHayMachine.SetActive(true);
        if (GameSettings.hayMachineColor == HayMachineColor.Yellow) yellowHayMachine.SetActive(true); 
        if (GameSettings.hayMachineColor == HayMachineColor.Red) redHayMachine.SetActive(true);
    }
}
