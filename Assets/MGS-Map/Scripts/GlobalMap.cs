/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GlobalMap.cs
 *  Description  :  Define global map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.Map
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

    /// <summary>
    /// Global map.
    /// </summary>
    [AddComponentMenu("Mogoson/Map/GlobalMap")]
    [RequireComponent(typeof(RectTransform))]
    public class GlobalMap : MonoBehaviour
    {
        #region Field and Property
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
        protected RectTransform rectTrans;

        /// <summary>
        ///  Width ratio (Map width / Terrain width).
        /// </summary>
        protected float widthRatio = 0;

        /// <summary>
        /// Height ratio (Map height / Terrain length).
        /// </summary>
        protected float heightRatio = 0;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            rectTrans = GetComponent<RectTransform>();
            widthRatio = rectTrans.rect.width / terrainInfo.width;
            heightRatio = rectTrans.rect.height / terrainInfo.length;
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
                flag.UpdateFlagPosition(GetMappingPos(flag));
                flag.UpdateFlagRotation();
            }
        }

        /// <summary>
        /// Get mapping position of flag.
        /// </summary>
        /// <param name="flag">Map flag.</param>
        /// <returns>Mapping position</returns>
        protected Vector3 GetMappingPos(MapFlag flag)
        {
            var offset = flag.target.position - terrainInfo.center.position;
            return new Vector2(offset.x * widthRatio, offset.z * heightRatio);
        }
        #endregion

        #region Public Method
#if UNITY_EDITOR
        /// <summary>
        /// Align flags to map base on target (Only call this method in editor script).
        /// </summary>
        public void AlignFlagsInEditor()
        {
            Start();
            Update();
        }
#endif
        #endregion
    }
}