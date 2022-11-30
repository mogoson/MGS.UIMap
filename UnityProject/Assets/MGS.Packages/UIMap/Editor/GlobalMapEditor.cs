/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GlobalMapEditor.cs
 *  Description  :  Editor for GlobalMap component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace MGS.UIMap.Editors
{
    [CustomEditor(typeof(GlobalMap), true)]
    [CanEditMultipleObjects]
    public class GlobalMapEditor : UIMapEditor
    {
        #region Field and Property
        protected GlobalMap Target { get { return target as GlobalMap; } }
        #endregion

        #region Protected Method
        protected bool InitializeFlags(MapFlag[] flags)
        {
            foreach (var flag in flags)
            {
                if (flag == null)
                {
                    return false;
                }
                InvokeMethod(flag, "Initialize");
            }
            return true;
        }

        protected bool CheckMapSettingsValid()
        {
            if (Target.terrainInfo.center == null || Target.terrainInfo.width <= 0 || Target.terrainInfo.length <= 0)
            {
                return false;
            }

            if (InitializeFlags(Target.staticFlags.ToArray()) == false)
            {
                return false;
            }

            return InitializeFlags(Target.dynamicFlags.ToArray());
        }

        protected void DrawAlignFlagsButton()
        {
            if (GUILayout.Button("Align Flags"))
            {
                if (CheckMapSettingsValid())
                {
                    InvokeMethod(Target, "Initialize");
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