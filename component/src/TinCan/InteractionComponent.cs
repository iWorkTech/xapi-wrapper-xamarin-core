// ***********************************************************************
// Assembly         : xAPI
// Author           : ashedge
// Created          : 03-09-2018
//
// Last Modified By : ashedge
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="InteractionComponent.cs" company="xAPI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace xAPI.Standard
{
    /// <summary>
    /// Class InteractionComponent.
    /// </summary>
    public partial class InteractionComponent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    /// <summary>
    /// Class Description.
    /// </summary>
    public class Description
    {
    }

    public partial class InteractionComponent
    {
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>InteractionComponent.</returns>
        public static InteractionComponent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InteractionComponent>(json, Converter.SETTINGS);
        }
    }

    /// <summary>
    /// Class Serialize.
    /// </summary>
    public static class Serialize
    {
        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>System.String.</returns>
        public static string ToJson(this InteractionComponent self)
        {
            return JsonConvert.SerializeObject(self, Converter.SETTINGS);
        }
    }
}