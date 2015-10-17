﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Custom_Scenery.Decorators
{
    interface IDecorator
    {
        GameObject Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle);
    }
}
