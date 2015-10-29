﻿using System.Collections.Generic;
using Custom_Scenery.Decorators.Type;
using UnityEngine;

namespace Custom_Scenery.Decorators
{
    class TypeDecorator : IDecorator
    {
        private string _type;

        public TypeDecorator(string type)
        {
            _type = type;
        }

        public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            switch (_type)
            {
                case "deco":
                    (new DecoDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "trashbin":
                    (new TrashBinDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "seating":
                    (new SeatingDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "seating_auto":
                    (new SeatingAutoDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "fence":
                    (new FenceDecorator()).Decorate(go, options, assetBundle);
                    break;
            }
        }

        internal GameObject Decorate(Dictionary<string, object> options, AssetBundle bundle)
        {
            GameObject asset = null;

            switch (_type)
            {
                case "deco":
                case "trashbin":
                case "seating":
                case "seating_auto":
                    asset = Object.Instantiate(bundle.LoadAsset((string) options["model"])) as GameObject;
                    break;
                case "fence":
                    asset = new GameObject();
                    break;
            }

            Decorate(asset, options, bundle);

            return asset;
        }
    }
}
