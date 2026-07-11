using System.Collections.Generic;

namespace Extension.ObjectPool {
    
    public delegate void AutoObjCollect<T>(T pObj) where T : IObj<T>;
    
    public class ObjPool<T> where T : IObj<T> {
        
       //==================================================||Properties 
       public IEnumerable<T> Elements {
           get {
               Update();
               return _curList;
           }
       }

       //==================================================||Fields 
        private T _form;
        private readonly Queue<T> _pool = new();
        private List<T> _curList = new();
        private List<T> _tempList = new();
          
       //==================================================||Constructors 
        public ObjPool(T pForm) {
            _form = pForm;
            _form.Init(AddToPool);
        }
        
        //==================================================|| Methods
        private void Update() {
            _tempList.Clear();
            foreach (var obj in _curList) {
                if (obj.IsExist)
                    _tempList.Add(obj);
            }
            (_tempList, _curList) = (_curList, _tempList);
        } 
        
        public T Get() {
            Update();
            if (!_pool.TryDequeue(out var target)) {
                target = _form.Clone();
            }
            _curList.Add(target);
            target.Show();
            return target;
        }

        private void AddToPool(T pObj) =>
            _pool.Enqueue(pObj);
    }
}