using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Custom_Scenery.Decorators.Type
{
    class SeatingDecorator : IDecorator
    {
        public GameObject Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            if (options.ContainsKey("seating_options"))
            {
                Dictionary<string, object> seatingOptions = options["seating_options"] as Dictionary<string, object>;
                
                go.AddComponent<Seating>();

                go.GetComponent<Seating>().hasBackRest = (bool)seatingOptions["has_back_rest"];
            }

            return go;
        }
    }
    }
}
