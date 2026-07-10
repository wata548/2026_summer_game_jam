using System;
using Extension.ObjectPool;
using UnityEngine;

namespace Extension {
    
    public class SoundManager: MonoSingleton<SoundManager> {
        private readonly ObjPool<SoundPlayer> _pool = new(new());

        public void Play(string pClip) {
            var clip = Resources.Load<AudioClip>(pClip);
            _pool.Get().Play(clip);
        }
    }
}