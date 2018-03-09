// ***********************************************************************
// Assembly         : xAPI
// Author           : ashedge
// Created          : 11-16-2017
//
// Last Modified By : ashedge
// Last Modified On : 02-19-2018
// ***********************************************************************
// <copyright file="ActivityDefinition.cs" company="xAPI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region License and Warranty Information

// ==========================================================
//  <copyright file="ActivityDefinition.cs" company="iWork Technologies">
//  Copyright (c) 2015 All Right Reserved, http://www.iworktech.com/
//
//  This source is subject to the iWork Technologies Permissive License.
//  Please see the License.txt file for more information.
//  All other rights reserved.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//
//  </copyright>
//  <author>iWorkTech Dev</author>
//  <email>info@iworktech.com</email>
//  <date>2017-01-05</date>
// ===========================================================

#endregion

#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using xAPI.Json;
using xAPI.Standard;

#endregion

namespace xAPI
{
    /// <summary>
    ///     Class ActivityDefinition.
    /// </summary>
    /// <seealso cref="xAPI.Json.JsonModel" />
    public class ActivityDefinition : JsonModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivityDefinition" /> class.
        /// </summary>
        public ActivityDefinition()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivityDefinition" /> class.
        /// </summary>
        /// <param name="json">The json.</param>
        public ActivityDefinition(StringOfJSON json) : this(json.toJObject())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActivityDefinition" /> class.
        /// </summary>
        /// <param name="jobj">The jobj.</param>
        public ActivityDefinition(JObject jobj)
        {
            if (jobj["type"] != null)
                Type = new Uri(jobj.Value<string>("type"));
            if (jobj["moreInfo"] != null)
                MoreInfo = new Uri(jobj.Value<string>("moreInfo"));
            if (jobj["name"] != null)
                Name = (LanguageMap) jobj.Value<JObject>("name");
            if (jobj["description"] != null)
                Description = (LanguageMap) jobj.Value<JObject>("description");
            if (jobj["extensions"] != null)
                Extensions = (Extensions) jobj.Value<JObject>("extensions");
        }

        /// <summary>
        ///     Gets or sets the type of the interaction.
        /// </summary>
        /// <value>The type of the interaction.</value>
        public InteractionType InteractionType { get; set; }

        /// <summary>
        ///     Gets or sets the correct responses pattern.
        /// </summary>
        /// <value>The correct responses pattern.</value>
        public List<string> CorrectResponsesPattern { get; set; }

        /// <summary>
        ///     Gets or sets the choices.
        /// </summary>
        /// <value>The choices.</value>
        public List<InteractionComponent> Choices { get; set; }

        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public List<InteractionComponent> Scale { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public List<InteractionComponent> Source { get; set; }

        /// <summary>
        ///     Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public List<InteractionComponent> Target { get; set; }

        /// <summary>
        ///     Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        public List<InteractionComponent> Steps { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Uri Type { get; set; }

        /// <summary>
        ///     Gets or sets the more information.
        /// </summary>
        /// <value>The more information.</value>
        public Uri MoreInfo { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public LanguageMap Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public LanguageMap Description { get; set; }

        /// <summary>
        ///     Gets or sets the extensions.
        /// </summary>
        /// <value>The extensions.</value>
        public Extensions Extensions { get; set; }

        /// <summary>
        ///     To the j object.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>JObject.</returns>
        public override JObject ToJObject(xAPIVersion version)
        {
            var result = new JObject();

            if (Type != null)
                result.Add("type", Type.ToString());
            if (MoreInfo != null)
                result.Add("moreInfo", MoreInfo.ToString());
            if (Name != null && !Name.IsEmpty())
                result.Add("name", Name.ToJObject(version));
            if (Description != null && !Description.IsEmpty())
                result.Add("description", Description.ToJObject(version));
            if (Extensions != null && !Extensions.IsEmpty())
                result.Add("extensions", Extensions.ToJObject(version));

            return result;
        }

        /// <summary>
        ///     Performs an explicit conversion from <see cref="JObject" /> to <see cref="ActivityDefinition" />.
        /// </summary>
        /// <param name="jobj">The jobj.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ActivityDefinition(JObject jobj)
        {
            return new ActivityDefinition(jobj);
        }
    }
}