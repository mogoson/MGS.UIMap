/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIMapEditor.cs
 *  Description  :  
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  11/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Reflection;
using UnityEditor;

#if UNITY_5_3_OR_NEWER
using UnityEditor.SceneManagement;
#endif

namespace MGS.UIMap.Editors
{
    public class UIMapEditor : Editor
    {
        protected void MarkSceneDirty()
        {
#if UNITY_5_3_OR_NEWER
            EditorSceneManager.MarkAllScenesDirty();
#else
            EditorApplication.MarkSceneDirty();
#endif
        }

        protected object InvokeMethod(object obj, string name,
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic, object[] parameters = null)
        {
            var methodInfo = obj.GetType().GetMethod(name, bindingAttr);
            if (methodInfo == null)
            {
                return null;
            }

            return methodInfo.Invoke(obj, parameters);
        }
    }
}