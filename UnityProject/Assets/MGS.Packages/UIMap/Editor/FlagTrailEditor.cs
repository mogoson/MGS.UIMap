/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FlagTrailEditor.cs
 *  Description  :  Editor for FlagTrail component.
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
    [CustomEditor(typeof(FlagTrail), true)]
    [CanEditMultipleObjects]
    public class FlagTrailEditor : UIMapEditor
    {
        #region Field and Property
        protected FlagTrail Target { get { return target as FlagTrail; } }
        #endregion

        #region Protected Method
        protected void DrawClearTrailButton()
        {
            if (GUILayout.Button("Clear Trail"))
            {
                InvokeMethod(Target, "Initialize");
                Target.ClearTrail();

                MarkSceneDirty();
                EditorUtility.UnloadUnusedAssetsImmediate(false);
            }
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DrawClearTrailButton();
        }
        #endregion
    }
}