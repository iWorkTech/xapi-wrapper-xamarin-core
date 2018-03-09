// ***********************************************************************
// Assembly         : xAPI
// Author           : ashedge
// Created          : 03-09-2018
//
// Last Modified By : ashedge
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="InteractionType.cs" company="xAPI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Newtonsoft.Json;
using xAPI.Standard;

namespace xAPI
{
    /// <summary>
    /// Class InteractionType.
    /// </summary>
    public class InteractionType
    {
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        public static Dictionary<string, object> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json, Converter.SETTINGS);
        }
    }
}