using UnityEngine;

namespace Extension.ObjectPool {
    public abstract class ObjBase<T>: MonoBehaviour, IObj<T> where T: class, IObj<T> {
        public bool IsExist { get; private set; }
        public Transform Folder { get; protected set; }
        private static AutoObjCollect<T> _returnMethod;

        public virtual T Clone() {
            Folder ??= new GameObject("Folder").transform;
            return Instantiate(this, Folder) as T;
        }
        public virtual void Init(AutoObjCollect<T> pReturnMethod) {
            _returnMethod = pReturnMethod;
        }

        public void Show() {
            IsExist = true;
            gameObject.SetActive(true);
        }

        public void Hide() {
            IsExist = false;
            gameObject.SetActive(false);
            _returnMethod?.Invoke(this as T);
        }
    }
}