using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using static Globals;

public class ResourcesMenu : MonoBehaviour {
  
  private Canvas resourcesScreen;
  public Text MartianRock;
  public Text MartianRockPrice;
  
  public Text DeepRock;
  public Text DeepRockPrice;

  public Text Samples;
  public Text SamplesPrice;

  void Update() {
    MartianRock.text = Globals.MartianRockAmount.ToString();
    MartianRockPrice.text = "$" + Globals.MartianRockSellPrice.ToString() + " Mill";

    DeepRock.text = Globals.DeepRockAmount.ToString();
    DeepRockPrice.text = "$" + Globals.DeepRockSellPrice.ToString() + " Mill";

    Samples.text = Globals.SamplesAmount.ToString();
    SamplesPrice.text = "$" + Globals.SamplesSellPrice.ToString() + " Mill";
  }

  public void MartianRockSell() {
    if (Globals.MartianRockAmount > 0) {
      Globals.MartianRockAmount --;
      Globals.totalMoney = Globals.totalMoney + Globals.MartianRockSellPrice;
    }
  }

  public void DeepRockSell() {
    if (Globals.DeepRockAmount > 0) {
      Globals.DeepRockAmount --;
      Globals.totalMoney = Globals.totalMoney + Globals.DeepRockSellPrice;
    }
  }

  public void SamplesSell() {
    if (Globals.SamplesAmount > 0) {
      Globals.SamplesAmount --;
      Globals.totalMoney = Globals.totalMoney + Globals.SamplesSellPrice;
    }
  }
}