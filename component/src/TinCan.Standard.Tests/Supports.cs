// ***********************************************************************
// Assembly         : xAPI.Standard.Tests
// Author           : ashedge
// Created          : 03-09-2018
//
// Last Modified By : ashedge
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="Supports.cs" company="xAPI.Standard.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Warranty Information

// ==========================================================
//  <copyright file="Support.cs" company="iWork Technologies">
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

#endregion

namespace xAPI.Standard.Tests
{
    /// <summary>
    /// Class Support.
    /// </summary>
    static class Supports
    {
        /// <summary>
        /// The agent
        /// </summary>
        public static Agent Agent;
        /// <summary>
        /// The verb
        /// </summary>
        public static Verb Verb;
        /// <summary>
        /// The activity
        /// </summary>
        public static Activity Activity;
        /// <summary>
        /// The parent
        /// </summary>
        public static Activity Parent;
        /// <summary>
        /// The context
        /// </summary>
        public static Context Context;
        /// <summary>
        /// The result
        /// </summary>
        public static Result Result;
        /// <summary>
        /// The score
        /// </summary>
        public static Score Score;
        /// <summary>
        /// The statement reference
        /// </summary>
        public static StatementRef StatementRef;
        /// <summary>
        /// The sub statement
        /// </summary>
        public static SubStatement SubStatement;

        /// <summary>
        /// Initializes static members of the <see cref="Supports" /> class.
        /// </summary>
        static Supports()
        {
            Agent = new Agent { Mbox = "mailto:so_moni@hotmail.com", Name = "So Moni", Account = new AgentAccount
            {
                Name = "So Moni",
                HomePage = new Uri("http://tincanapi.com/")
            }};

            Verb = new Verb("https://w3id.org/xapi/adl/verbs/experienced") { Display = new LanguageMap() };
            Verb.Display.Add("en-US", "experienced");

            Activity = new Activity
            {
                ID = "http://tincanapi.com/TinCanCSharp/Test/Unit/0",
                Definition = new ActivityDefinition
                {
                    Type = new Uri("http://id.tincanapi.com/activitytype/unit-test"),
                    Name = new LanguageMap()
                }
            };
            Activity.Definition.Name.Add("en-US", "Tin Can C# Tests: Unit 0");
            Activity.Definition.Description = new LanguageMap();
            Activity.Definition.Description.Add("en-US", "Unit test 0 in the test suite for the Tin Can C# library.");

            Parent = new Activity
            {
                ID = "http://tincanapi.com/TinCanCSharp/Test",
                Definition = new ActivityDefinition
                {
                    Type = new Uri("http://id.tincanapi.com/activitytype/unit-test-suite"),
                    Name = new LanguageMap()
                }
            };
            Parent.Definition.Name.Add("en-US", "Tin Can C# Tests");
            Parent.Definition.Description = new LanguageMap();
            Parent.Definition.Description.Add("en-US", "Unit test suite for the Tin Can C# library.");

            StatementRef = new StatementRef(Guid.NewGuid());

            Context = new Context
            {
                Registration = Guid.NewGuid(),
                Statement = StatementRef,
                ContextActivities = new ContextActivities { Parent = new List<Activity> { Activity } }
            };

            Score = new Score
            {
                Raw = 97,
                Scaled = 1,
                Max = 100,
                Min = 0
            };

            Result = new Result
            {
                Score = Score,
                Success = true,
                Completion = true,
                Duration = new TimeSpan(0,0,2,0)
            };

            SubStatement = new SubStatement
            {
                Actor = Agent,
                Verb = Verb,
                Target = Parent
            };
        }
    }
}