using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {
    public Transform menu_cursor;
    protected List<Transform> menus;
    protected GameObject canvas_main;
    protected int selected_menu = 0;
    protected bool is_pause = false;
    // Use this for initialization
    void Start () {
        canvas_main = GameObject.Find("Canvas");
        menus = GetChildCollection(this.transform);
    }

    // Update is called once per frame
    void Update() {
        if (!is_pause) {
            // do movement
            OnPressArrows();
            OnPressEnter();
            MoveMenuCursor();
        }
    }

    int mod(int x, int m) {
        return (x % m + m) % m;
    }
    //Move the cursor of menu
    public void MoveMenuCursor() {
        menu_cursor.position = Vector3.Lerp(menu_cursor.position, menus[selected_menu].position, Time.deltaTime * 10);
    }

    public static List<Transform> GetChildCollection(Transform obj) {
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < obj.childCount; i++) {
            list.Add(obj.GetChild(i));
        }
        return list;
    }

    public void OnPressArrows() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            selected_menu = mod(selected_menu + 1, 3);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            selected_menu = mod(selected_menu - 1, 3);
        }
    }

    public void OnPressEnter() {
        if (Input.GetKeyDown(KeyCode.Return) && menus[selected_menu].gameObject.activeSelf) {
            switch (selected_menu) {
                case 0: menus[selected_menu].SendMessage("OnClickSceneTrans", "DummyGameScene"); break;
                case 1: menus[selected_menu].SendMessage("OnClickPopup", "Canvas_Popup_Option"); break;
                case 2: menus[selected_menu].SendMessage("OnClickExit"); break;
            }
        }
            
    }
    public void OnPauseGame() {
        is_pause = true;
    }

    public void OnRestartGame() {
        is_pause = false;
    }
}