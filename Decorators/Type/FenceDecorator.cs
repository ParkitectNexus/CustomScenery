using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Custom_Scenery.Decorators.Type
{
    class FenceDecorator : IDecorator
    {
        public GameObject Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            go.AddComponent<Fence>();

            Dictionary<string, object> fenceOptions = options["fence_options"] as Dictionary<string, object>;

            GameObject flat = GameObject.Instantiate(assetBundle.LoadAsset((string)fenceOptions["flat"])) as GameObject;
            flat.transform.rotation = Quaternion.identity;
            GameObject post = GameObject.Instantiate(assetBundle.LoadAsset((string)fenceOptions["post"])) as GameObject;
            post.transform.rotation = Quaternion.identity;

            go.GetComponent<Fence>().flatGO = flat;
            go.GetComponent<Fence>().postGO = post;
            go.GetComponent<Fence>().hasMidPosts = false;

            return go;
        }
    }
}
