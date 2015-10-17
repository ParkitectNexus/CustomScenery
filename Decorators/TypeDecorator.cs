using System.Collections.Generic;
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

        public GameObject Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            switch (_type)
            {
                case "deco":
                    go = (new DecoDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "trashbin":
                    go = (new TrashBinDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "seating":
                    go = (new SeatingDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "seating_auto":
                    go = (new SeatingAutoDecorator()).Decorate(go, options, assetBundle);
                    break;
                case "fence":
                    go = (new FenceDecorator()).Decorate(go, options, assetBundle);
                    break;
            }

            return go;
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

            return Decorate(asset, options, bundle);
        }
    }
}
