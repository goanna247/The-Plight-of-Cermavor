using UnityEngine;
using UnityEngine.XR;
using static Globals;

public class DrillRig : MonoBehaviour {
  [SerializeField]
  private Material ready;
  [SerializeField]
  private Material collecting;

  private float drillingTimer = 0;
  private float drillForTime = 10;

  private bool collect = false;
  
  void Update() {
    if (Globals.Drilling) {
      gameObject.GetComponent<MeshRenderer>().material = collecting;
    } else {
      gameObject.GetComponent<MeshRenderer>().material = ready;
    }

    if (collect == false) {
      if (Globals.Drilling) {
        collect = true;
      }
    }

    if (collect) {
      drillingTimer += Time.deltaTime;

      if (drillingTimer >= drillForTime) {
        Globals.DeepRockAmount ++;
        Globals.Drilling = false;
        collect = false;
      }
    }
  }
}