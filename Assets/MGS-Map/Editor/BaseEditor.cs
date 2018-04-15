/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BaseEditor.cs
 *  Description  :  Custom base editor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;

#if UNITY_5_3_OR_NEWER
using UnityEditor.SceneManagement;
#endif

namespace Mogoson.Map
{
    public class BaseEditor : Editor
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