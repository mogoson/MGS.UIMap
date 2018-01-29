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
    [CanEditMultipleObjects]
    public class GlobalMapEditor : MapEditor
    {
        #region Property and Field
        protected GlobalMap Script { get { return target as GlobalMap; } }
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
            if (Script.terrainInfo.center == null || Script.terrainInfo.width <= 0 || Script.terrainInfo.length <= 0)
                return false;

            if (CheckInitialiseFlags(Script.dynamicFlags.ToArray()) == false)
                return false;

            return CheckInitialiseFlags(Script.staticFlags.ToArray());
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
                    Script.AlignFlagsInEditMode();
                    MarkSceneDirty();
                }
                else
                    Debug.LogError("The settings of map is incomplete or invalid.");
            }
        }
        #endregion
    }
}