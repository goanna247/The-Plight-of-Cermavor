using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SideMenuButtons : MonoBehaviour {

  // [SerializeField]
  // private GameObject mainShow;
  // [SerializeField]
  // private GameObject enemiesShow;
  // [SerializeField]
  // private GameObject robotsShow;
  // [SerializeField]
  // private GameObject weaponsShow;
  // [SerializeField]
  // private GameObject resourcesShow;

  void Start() {
    // mainShow.SetActive(true);
    // enemiesShow.SetActive(false);
    // robotsShow.SetActive(false);
    // weaponsShow.SetActive(false);
    // resourcesShow.SetActive(false);
  }
  

  public void MainButton() {
    // mainShow.SetActive(true);
    // enemiesShow.SetActive(false);
    // robotsShow.SetActive(false);
    // weaponsShow.SetActive(false);
    // resourcesShow.SetActive(false);
  }

  public void EnemiesButton() {
    // mainShow.SetActive(false);
    // enemiesShow.SetActive(true);
    // robotsShow.SetActive(false);
    // weaponsShow.SetActive(false);
    // resourcesShow.SetActive(false);
  }

  public void RobotsButton() {
    // mainShow.SetActive(false);
    // enemiesShow.SetActive(false);
    // robotsShow.SetActive(true);
    // weaponsShow.SetActive(false);
    // resourcesShow.SetActive(false);
  }

  public void WeaponsButton() {
    // mainShow.SetActive(false);
    // enemiesShow.SetActive(false);
    // robotsShow.SetActive(false);
    // weaponsShow.SetActive(true);
    // resourcesShow.SetActive(false);
  }

  public void ResourcesButton() {
    // mainShow.SetActive(false);
    // enemiesShow.SetActive(false);
    // robotsShow.SetActive(false);
    // weaponsShow.SetActive(false);
    // resourcesShow.SetActive(true);
  }
}