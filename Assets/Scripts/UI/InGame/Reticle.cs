using System;
using Entity;
using UnityEngine;

namespace UI.InGame {
    public class Reticle: MonoBehaviour {
        [SerializeField] private float _term = 3;
        private void Update() {
            var mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2f;
            mousePos.y -= Screen.height / 2f;
            transform.position = Player.Instance.transform.position + mousePos.normalized * _term;
        }
    }   
}