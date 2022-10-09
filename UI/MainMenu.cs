using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

  [SerializeField]
  private GameObject ButtonSelection;
  [SerializeField]
  private GameObject HelpScreen;
  //add options + Quit game?


  public void LaunchGame() {
    SceneManager.LoadScene("MainScene");
  }

  public void HelpButton() {
    ButtonSelection.SetActive(false);
    HelpScreen.SetActive(true);
  }

  public void QuitGame() {
    Application.Quit(); 
  }

  public void ExitHelpScreen() {
    ButtonSelection.SetActive(true);
    HelpScreen.SetActive(false);
  }

  void Start() {
    ButtonSelection.SetActive(true);
    HelpScreen.SetActive(false);
  }
  
  void Update() {}
}