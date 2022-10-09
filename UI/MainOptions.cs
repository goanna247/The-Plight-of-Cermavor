using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using static Globals;

public class MainOptions : MonoBehaviour {

  // private Canvas mainScreen;
  // public Text DayText;
  // public Text CycleText;
  // public Text MoneyText;
  // public Text ProfitText;
  // public Text TotalProfitText;
  
  void Update() {
    // DayText.text = Globals.day.ToString();
    // CycleText.text = Globals.cycle.ToString();
    // MoneyText.text = "$" + Globals.totalMoney.ToString() + " Mill";
    // ProfitText.text = "$" + Globals.profitThisCycle.ToString() + " Mill";
    // TotalProfitText.text = "$" + Globals.profitTotal.ToString() + " Mill";
  }

  public void SendMoneyButton() {
    // if (Globals.totalMoney >= 1) {
    //   Globals.totalMoney --;
    //   Globals.profitThisCycle ++;
    //   Globals.profitTotal ++;
    // }
  }
}