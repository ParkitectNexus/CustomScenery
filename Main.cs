using UnityEngine;

namespace Custom_Scenery
{
    class Main : IMod
    {
        private GameObject _go;

        public void onEnabled()
        {
            _go = new GameObject();

            _go.AddComponent<SceneryLoader>();

            _go.GetComponent<SceneryLoader>().LoadScenery();
        }

        public void onDisabled()
        {
            _go.GetComponent<SceneryLoader>().UnloadScenery();

            Object.Destroy(_go);
        }

        public string Name { get { return "Custom Scenery"; } }
        public string Description { get { return "Custom Scenery"; } }
    }
}
