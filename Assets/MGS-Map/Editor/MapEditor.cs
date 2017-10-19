/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  MapEditor.cs
 *  Description  :  Custom editor for map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

#if UNITY_5_3_OR_NEWER
using UnityEditor.SceneManagement;
#endif

namespace Developer.Map
{
    public class MapEditor : Editor
    {
        #region Protected Method
        protected void MarkSceneDirty()
        {
#if UNITY_5_3_OR_NEWER
            EditorSceneManager.MarkAllScenesDirty();
#else
            EditorApplication.MarkSceneDirty();
#endif
        }
        #endregion
    }
}