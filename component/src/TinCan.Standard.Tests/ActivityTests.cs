// ***********************************************************************
// Assembly         : xAPI.Standard.Tests
// Author           : ashedge
// Created          : 03-09-2018
//
// Last Modified By : ashedge
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="ActivityTests.cs" company="xAPI.Standard.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="ActivityTests.cs" company="iWork Technologies">
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
using Xunit;

#endregion

namespace xAPI.Standard.Tests
{
    /// <summary>
    /// Class ActivityTests.
    /// </summary>

    public class ActivityTests
    {
        /// <summary>
        /// Tests the activity identifier case.
        /// </summary>
        [Fact]
        public void TestActivityIdCase()
        {
            var activity = new Activity();
            var mixedCase = "http://fOO";
            activity.ID = mixedCase;
            Assert.Equal(mixedCase, activity.ID);
        }

        /// <summary>
        /// Tests the activity identifier invalid URI.
        /// </summary>
        [Fact]
        public void TestActivityIdInvalidUri()
        {
            Assert.Throws<UriFormatException>(
                () =>
                {
                    var activity = new Activity();
                    var invalid = "foo";
                    activity.ID = invalid;
                }
            );
        }

        /// <summary>
        /// Tests the activity identifier trailing slash.
        /// </summary>
        [Fact]
        public void TestActivityIdTrailingSlash()
        {
            var activity = new Activity();
            var noTrailingSlash = "http://foo";
            activity.ID = noTrailingSlash;
            Assert.Equal(noTrailingSlash, activity.ID);
        }
    }
}