﻿using System;

namespace Calabonga.Module12.Web.Infrastructure.Attributes
{
    /// <summary>
    /// Swagger controller group attribute
    /// </summary>
    ///
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerGroupAttribute : Attribute
    {
        /// <inheritdoc />
        public SwaggerGroupAttribute(string groupName)
        {
            GroupName = groupName;
        }

        /// <summary>
        /// Group name
        /// </summary>
        public string GroupName { get; }
    }
}