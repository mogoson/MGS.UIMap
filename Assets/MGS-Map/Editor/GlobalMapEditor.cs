/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  GlobalMapEditor.cs
 *  Description  :  Editor for GlobalMap.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Developer.Map
{
    [CustomEditor(typeof(GlobalMap), true)]
    public class GlobalMapEditor : MapEditor
    {
        #region Property and Field
        protected GlobalMap script { get { return target as GlobalMap; } }
        #endregion

        #region Protected Method
        protected bool CheckInitialiseFlags(MapFlag[] flags)
        {
            foreach (var flag in flags)
            {
                if (flag == null)
                    return false;
                else
                    flag.InitialiseInEditMode();
            }
            return true;
        }

        protected bool CheckMapSettings()
        {
            if (script.terrainInfo.center == null || script.terrainInfo.width <= 0 || script.terrainInfo.length <= 0)
                return false;

            if (CheckInitialiseFlags(script.dynamicFlags.ToArray()) == false)
                return false;

            return CheckInitialiseFlags(script.staticFlags.ToArray());
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Align Flags"))
            {
                if (CheckMapSettings())
                {
                    script.AlignFlagsInEditMode();
                    MarkSceneDirty();
                }
                else
                    Debug.LogError("The settings of map is incomplete or invalid.");
            }
        }
        #endregion
    }
}