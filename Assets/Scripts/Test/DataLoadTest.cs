using System.IO;
using Data;
using Extension.Test;
using TMPro;
using UnityEngine;

namespace TestExtension {
    [RequireComponent(typeof(TMP_Text))]
    public class DataLoadTest: MonoBehaviour {
        [TestMethod]
        private void Load() {
            _ = DataTables.Instance; 
            var tmp = GetComponent<TMP_Text>();
            var data = DataTables.Instance.CardDesc.Get(1002);
            tmp.text = data.Name;
        }
    }
}