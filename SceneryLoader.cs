using System;
using System.Collections.Generic;
using System.IO;
using Custom_Scenery.Decorators;
using MiniJSON;
using UnityEngine;

namespace Custom_Scenery
{
    internal class SceneryLoader : MonoBehaviour
    {
        private List<BuildableObject> _sceneryObjects = new List<BuildableObject>();
        
        public void LoadScenery()
        {
            var dict = Json.Deserialize(File.ReadAllText(@"C:\Users\luukh\Desktop\ParkitectRecentBuild\mods\Custom Scenery\scenery.json")) as Dictionary<string, object>;

            GameObject hider = new GameObject();

            hider.SetActive(false);

            using (WWW www = new WWW("file://" + Application.streamingAssetsPath + "/mods/custom-scenery/scenery"))
            {
                if (www.error != null)
                    throw new Exception("Download had an error:" + www.error);

                AssetBundle bundle = www.assetBundle;
                
                foreach (KeyValuePair<string, object> pair in dict)
                {
                    try
                    {
                        var options = pair.Value as Dictionary<string, object>;

                        GameObject asset;

                        asset = (new TypeDecorator((string)options["type"])).Decorate(options, bundle);
                        asset = (new PriceDecorator((double)options["price"])).Decorate(asset, options, bundle);
                        asset = (new NameDecorator(pair.Key)).Decorate(asset, options, bundle);

                        if (options.ContainsKey("grid"))
                            asset = (new GridDecorator((bool)options["grid"])).Decorate(asset, options, bundle);

                        DontDestroyOnLoad(asset);

                        AssetManager.Instance.registerObject(asset.GetComponent<BuildableObject>());
                        _sceneryObjects.Add(asset.GetComponent<BuildableObject>());

                        // hide it from view
                        asset.transform.parent = hider.transform;
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                        // ignore
                    }
                }

                bundle.Unload(false);
            }
        }

        public void UnloadScenery()
        {
            foreach (Deco deco in _sceneryObjects)
            {
                AssetManager.Instance.unregisterObject(deco);
            }
        }
    }
}
