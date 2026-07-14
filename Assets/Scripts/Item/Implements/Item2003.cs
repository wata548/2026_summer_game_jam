using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Rendering.Universal;

namespace Item
{
    internal class Item2003 : ItemBase
    {
        public override int Id => 2003;
        private int usingCount = 0;
        public override void Use()
        {
            if (usingCount == 0)
            {

            }
        }
    }
}