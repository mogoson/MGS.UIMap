/*************************************************************************
 *  Copyright (C), 2016-2017, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  GlobalMap.cs
 *  Description  :  Define global map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  12/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Developer.Map
{
    /// <summary>
    /// Terrain Info.
    /// </summary>
    [Serializable]
    public struct TerrainInfo
    {
        /// <summary>
        /// Center of terrain.
        /// </summary>
        public Transform center;

        /// <summary>
        /// Width of terrain.
        /// </summary>
        public float width;

        /// <summary>
        /// Length of terrain.
        /// </summary>
        public float length;

        /// <summary>
        /// Constructor of TerrainInfo.
        /// </summary>
        /// <param name="center">Center of terrain.</param>
        /// <param name="width">Width of terrain.</param>
        /// <param name="length">Length of terrain.</param>
        public TerrainInfo(Transform center, float width, float length)
        {
            this.center = center;
            this.width = width;
            this.length = length;
        }
    }

    [AddComponentMenu("Developer/Map/GlobalMap")]
    [RequireComponent(typeof(RectTransform))]
    public class GlobalMap : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Terrain info.
        /// </summary>
        public TerrainInfo terrainInfo = new TerrainInfo(null, 500, 500);

        /// <summary>
        /// Dynamic flags.
        /// </summary>
        public List<MapFlag> dynamicFlags;

        /// <summary>
        /// Static flags.
        /// </summary>
        public List<MapFlag> staticFlags;

        /// <summary>
        /// RectTransform of map UI.
        /// </summary>
        protected RectTransform rTrans;

        /// <summary>
        ///  Width Factor(Map width / Terrain width).
        /// </summary>
        protected float wFactor = 0;

        /// <summary>
        /// Height Factor(Map height / Terrain length).
        /// </summary>
        protected float hFactor = 0;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            rTrans = GetComponent<RectTransform>();
            wFactor = rTrans.rect.width / terrainInfo.width;
            hFactor = rTrans.rect.height / terrainInfo.length;
            UpdateFlags(staticFlags);
        }

        protected virtual void Update()
        {
            UpdateFlags(dynamicFlags);
        }

        /// <summary>
        /// Update flags position and rotation.
        /// </summary>
        /// <param name="flags">Map flags.</param>
        protected void UpdateFlags(List<MapFlag> flags)
        {
            foreach (var flag in flags)
            {
                var tPos = GetTargetPosition(flag);
                flag.UpdateFlagPosition(new Vector2(tPos.x * wFactor, tPos.z * hFactor));
                flag.UpdateFlagRotation();
            }
        }

        /// <summary>
        /// Get flag's target position.
        /// </summary>
        /// <param name="flag">Map flag.</param>
        /// <returns></returns>
        protected Vector3 GetTargetPosition(MapFlag flag)
        {
            return flag.target.position - terrainInfo.center.position;
        }
        #endregion

        #region Public Method
#if UNITY_EDITOR
        /// <summary>
        /// Align flags in edit mode (Only call this method in editor script).
        /// </summary>
        public void AlignFlagsInEditMode()
        {
            Start();
            Update();
        }
#endif
        #endregion
    }
}