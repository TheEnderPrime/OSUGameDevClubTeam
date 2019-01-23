using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseUI : MonoBehaviour {
    protected GameObject canvas_main;
    protected bool is_pause=false;

    // Use this for initialization
    void Start () {
        canvas_main = GameObject.Find("Canvas");
    }
	
    // Update is called once per frame
	void Update () {
        OnPressEsc();
        if (!is_pause)
        {
            // do movement
        }
    }

    //Click Events
    public void OnClickSceneTrans(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public void OnClickPopup(string CanvasName) {
        GameObject popup = canvas_main.transform.Find(CanvasName).gameObject;
        popup.SetActive(true);
    }

    public void OnClickClosePopup() {
        GameObject popup = gameObject.transform.parent.gameObject;
        popup.SetActive(false);
    }

    public void OnClickExit() {
        Application.Quit();
    }

    public void OnClickPause() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects) {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnClickRestart() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnRestartGame", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnPauseGame() {
        is_pause = true;
    }

    public void OnRestartGame() {
        is_pause = false;
    }

    //KeyBorad Events
    public void OnPressEsc() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject popupPause = canvas_main.transform.Find("Canvas_Popup_Pause").gameObject;
            if(popupPause.activeInHierarchy) {
                popupPause.SetActive(false);
                OnClickRestart();
            } else {
                popupPause.SetActive(true);
                OnClickPause();
            }
        }
    }

}
