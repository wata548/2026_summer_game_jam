using System.Collections.Generic;
using System.Linq;

namespace Extension.ObjectPool {
    
    public delegate void AutoObjCollect<T>(T pObj) where T : IObj<T>;
    
    public class ObjPool<T> where T : IObj<T> {
        private T _form;
        private readonly Queue<T> _pool = new();
        private List<T> _curList = new();
        private List<T> _tempList = new();
        
        public ObjPool(T pForm) {
            _form = pForm;
            _form.Init(AddToPool);
        }

        private void Update() {
            _tempList.Clear();
            foreach (var obj in _curList) {
                if (obj.IsExist)
                    _tempList.Add(obj);
                else 
                    _pool.Enqueue(obj);
            }
            (_tempList, _curList) = (_curList, _tempList);
        } 
        
        public T Get() {
            Update();
            if (!_pool.TryDequeue(out var target)) {
                target = _form.Clone();
            }
            target.Show();
            return target;
        }

        private void AddToPool(T pObj) =>
            _pool.Enqueue(pObj);
    }
}