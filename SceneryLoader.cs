using System;
using System.Collections.Generic;
using UnityEngine;

namespace Custom_Scenery
{
    class SceneryLoader : MonoBehaviour
    {
        private List<Deco> _sceneryObjects = new List<Deco>(); 

        private List<string> _scenery = new List<string>()
        {
            "Bush1",
            "Bush2",
            "Bush3",
            "Bush4",
            "Bush5",
            "Bush6",
            "Bush7",
            "Fern",
            "RockMesh",
            "Alder",
            "Bamboo",
            "BananaPlant",
            "Banyan",
            "JapaneseMaple",
            "Mimosa",
            "Palm",
            "Palm (group)",
            "ScotsPineTypeA",
            "Sycamore",
            "ThinTree",
            "Willow",
        };

        public void LoadScenery()
        {
            using (WWW www = new WWW("file://" + Application.streamingAssetsPath + "/mods/custom-scenery/scenery"))
            {
                if (www.error != null)
                    throw new Exception("Download had an error:" + www.error);

                AssetBundle bundle = www.assetBundle;

                foreach (string s in _scenery)
                {
                    GameObject scenery = Instantiate(bundle.LoadAsset(s)) as GameObject;

                    Deco d = scenery.AddComponent<Deco>();

                    d.price = 100;

                    ScriptableSingleton<AssetManager>.Instance.registerObject(d);

                    _sceneryObjects.Add(d);
                }

                bundle.Unload(false);
            }
        }

        public void UnloadScenery()
        {
            foreach (Deco deco in _sceneryObjects)
            {
                ScriptableSingleton<AssetManager>.Instance.unregisterObject(deco);
            }
        }
    }
}
