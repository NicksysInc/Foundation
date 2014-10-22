// ----------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nicksys.Foundation.ObjectMapping
{
    public static class ReflectionHelper
    {
        public static bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static MemberInfo[] GetPublicFieldsAndProperties(Type type)
        {
            return type
                .GetMembers(BindingFlags.Instance | BindingFlags.Public)
                .Where(mi => mi.MemberType == MemberTypes.Property || mi.MemberType == MemberTypes.Field)
                .ToArray();
        }

        public static MemberMatch[] GetCommonMembers(Type first, Type second, Func<string, string, bool> matcher)
        {
            if (matcher == null)
            {
                matcher = (f, s) => f == s;
            }

            var firstMembers = GetPublicFieldsAndProperties(first);
            var secondMembers = GetPublicFieldsAndProperties(second);
            
            var result = new List<MemberMatch>();
            
            foreach (var f in firstMembers)
            {
                var s = secondMembers.FirstOrDefault(sm => matcher(f.Name, sm.Name));
                if (s != null)
                {
                    result.Add(new MemberMatch(f, s));
                }
            }
            
            return result.ToArray();
        }

        public static Type GetMemberType(MemberInfo memberInfo)
        {
            if (memberInfo is PropertyInfo)
            {
                return ((PropertyInfo)memberInfo).PropertyType;
            }
            else if (memberInfo is FieldInfo)
            {
                return ((FieldInfo)memberInfo).FieldType;
            }
            else if (memberInfo is MethodInfo)
            {
                return ((MethodInfo)memberInfo).ReturnType;
            }

            return null;
        }

        public static bool HasDefaultConstructor(Type type)
        {
            return type.GetConstructor(new Type[0]) != null;
        }
    }
}
