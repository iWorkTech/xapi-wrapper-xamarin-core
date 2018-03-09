// ***********************************************************************
// Assembly         : xAPI.Standard
// Author           : ashedge
// Created          : 11-16-2017
//
// Last Modified By : ashedge
// Last Modified On : 02-19-2018
// ***********************************************************************
// <copyright file="StateDocument.cs" company="xAPI.Standard">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="StateDocument.cs" company="iWork Technologies">
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

#endregion

namespace xAPI.Standard.Documents
{
    /// <summary>
    /// Class StateDocument.
    /// </summary>
    /// <seealso cref="xAPI.Standard.Documents.Document" />
    /// <seealso cref="Document" />
    public class StateDocument : Document
    {
        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        public Activity Activity { get; set; }
        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public Agent Agent { get; set; }
        /// <summary>
        /// Gets or sets the registration.
        /// </summary>
        /// <value>The registration.</value>
        public Guid? Registration { get; set; }
    }
}