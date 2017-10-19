/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  FlagTrailEditor.cs
 *  Description  :  Editor for FlagTrail.
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
    [CustomEditor(typeof(FlagTrail), true)]
    [CanEditMultipleObjects]
    public class FlagTrailEditor : MapEditor
    {
        #region Property and Field
        protected FlagTrail script { get { return target as FlagTrail; } }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Clear Pixels"))
            {
                script.ClearPixelsInEditMode();
                MarkSceneDirty();
                EditorUtility.UnloadUnusedAssetsImmediate(true);
            }
        }
        #endregion
    }
}