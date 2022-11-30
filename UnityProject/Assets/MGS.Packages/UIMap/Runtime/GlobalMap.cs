/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GlobalMap.cs
 *  Description  :  Define global map.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UIMap
{
    /// <summary>
    /// Global map.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class GlobalMap : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Terrain info.
        /// </summary>
        [Tooltip("Terrain info.")]
        public TerrainInfo terrainInfo = new TerrainInfo(null, 500, 500);

        /// <summary>
        /// Dynamic flags.
        /// </summary>
        [Tooltip("Dynamic flags.")]
        public List<MapFlag> dynamicFlags;

        /// <summary>
        /// Static flags.
        /// </summary>
        [Tooltip("Static flags.")]
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
        /// <summary>
        /// Component start.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
            UpdateFlags(staticFlags);
        }

        /// <summary>
        /// Component update.
        /// </summary>
        protected virtual void Update()
        {
            UpdateFlags(dynamicFlags);
        }

        /// <summary>
        /// Initialize global map.
        /// </summary>
        protected virtual void Initialize()
        {
            rectTrans = GetComponent<RectTransform>();
            widthRatio = rectTrans.rect.width / terrainInfo.width;
            heightRatio = rectTrans.rect.height / terrainInfo.length;
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
        /// <summary>
        /// Update flags position and rotation.
        /// </summary>
        public void UpdateFlags()
        {
            UpdateFlags(staticFlags);
            UpdateFlags(dynamicFlags);
        }
        #endregion
    }
}