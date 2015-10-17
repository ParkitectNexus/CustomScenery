using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Custom_Scenery.Decorators.Type
{
    class DecoDecorator : IDecorator
    {
        public GameObject Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            go.AddComponent<global::Deco>();

            return go;
        }
    }
}
