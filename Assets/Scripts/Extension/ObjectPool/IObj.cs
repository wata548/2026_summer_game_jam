using System;
using CSVData;

namespace Extension.ObjectPool {
    public interface IClone<T>  {
        T Clone();
    }
    
    public interface IObj<T>: IClone<T> where T: IObj<T> {
        bool IsExist { get;}
        void Init(AutoObjCollect<T> pReturnMethod);
        void Show();
        void Hide();
    }
}