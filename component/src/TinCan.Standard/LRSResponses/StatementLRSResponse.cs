// ***********************************************************************
// Assembly         : xAPI.Standard
// Author           : ashedge
// Created          : 11-16-2017
//
// Last Modified By : ashedge
// Last Modified On : 02-19-2018
// ***********************************************************************
// <copyright file="StatementLRSResponse.cs" company="xAPI.Standard">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="StatementLRSResponse.cs" company="iWork Technologies">
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

namespace xAPI.Standard.LRSResponses
{
    /// <summary>
    /// Class StatementLRSResponse.
    /// </summary>
    /// <seealso cref="xAPI.Standard.LRSResponses.LRSResponse" />
    /// <seealso cref="LRSResponse" />
    public class StatementLRSResponse : LRSResponse
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public Statement Content { set; get; }
    }
}