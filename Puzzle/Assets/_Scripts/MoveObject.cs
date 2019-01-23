using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    private Transform _transform;
    public float speed = 10;
    protected bool is_pause = false;

	// Use this for initialization
	void Start () {
        _transform = this.transform;

    }
	
	// Update is called once per frame
	void Update () {
        if(!is_pause) { 
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
        }
    }

    public void OnPauseGame() {
        is_pause = true;
    }

    public void OnRestartGame() {
        is_pause = false;
    }
}
