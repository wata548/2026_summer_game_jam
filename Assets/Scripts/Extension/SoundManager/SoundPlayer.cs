using System;
using Extension.ObjectPool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Extension {
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer: ObjBase<SoundPlayer> {
        //==================================================||Fields        
        private AudioSource _source;
        private bool _isPlay = false;
        
       //==================================================||Methods 
        public void Play(AudioClip pClip) {
            _source.PlayOneShot(pClip);
            _isPlay = true;
        }

        public override SoundPlayer Clone() {
            if (Folder == null) {
                Folder = new GameObject("SoundPlayerFolder").transform;
                DontDestroyOnLoad(Folder);
            }

            var player = new GameObject("Player");
            player.transform.parent = Folder;
            return player.AddComponent<SoundPlayer>();
        }

        //==================================================||Unity 
        private void Awake() {
            _source = GetComponent<AudioSource>();
        }

        private void Update() {
            if (!IsExist || !_isPlay) return;
            if (!_source.isPlaying) {
                _isPlay = false;
                Hide();
            }
        }
    }
}