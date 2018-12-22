/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GlobalMapEditor.cs
 *  Description  :  Editor for GlobalMap component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Mogoson.Map
{
    [CustomEditor(typeof(GlobalMap), true)]
    [CanEditMultipleObjects]
    public class GlobalMapEditor : BaseEditor
    {
        #region Field and Property
        protected GlobalMap Target { get { return target as GlobalMap; } }
        #endregion

        #region Protected Method
        protected bool CheckInitialiseFlags(MapFlag[] flags)
        {
            foreach (var flag in flags)
            {
                if (flag == null)
                {
                    return false;
                }
                flag.Initialize();
            }
            return true;
        }

        protected bool CheckMapSettings()
        {
            if (Target.terrainInfo.center == null || Target.terrainInfo.width <= 0 || Target.terrainInfo.length <= 0)
            {
                return false;
            }

            if (CheckInitialiseFlags(Target.staticFlags.ToArray()) == false)
            {
                return false;
            }

            return CheckInitialiseFlags(Target.dynamicFlags.ToArray());
        }

        protected void DrawAlignFlagsButton()
        {
            if (GUILayout.Button("Align Flags"))
            {
                if (CheckMapSettings())
                {
                    Target.UpdateFlags();
                    MarkSceneDirty();
                }
                else
                {
                    Debug.LogError("The parameter settings is incomplete or invalid.");
                }
            }
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DrawAlignFlagsButton();
        }
        #endregion
    }
}