﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioSystem.Helpers
{
    public static class ExtensionMethods
    {
        public static IMappingExpression<TSource, TDestination> IgnoreProperty<TSource, TDestination> (this IMappingExpression<TSource, 
            TDestination> mappingExpression, Expression<Func<TDestination, object>> selector)
        {
            return mappingExpression.ForMember(selector, opt => opt.Ignore());
        }
    }
}
