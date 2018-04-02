/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FlagTrailEditor.cs
 *  Description  :  Editor for FlagTrail component.
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
    [CustomEditor(typeof(FlagTrail), true)]
    [CanEditMultipleObjects]
    public class FlagTrailEditor : MapEditor
    {
        #region Field and Property
        protected FlagTrail Target { get { return target as FlagTrail; } }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Clear Trail"))
            {
                Target.ClearTrailInEditor();
                MarkSceneDirty();
                EditorUtility.UnloadUnusedAssetsImmediate(true);
            }
        }
        #endregion
    }
}