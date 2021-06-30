using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Interfaces;

namespace Tools.Extensions
{
    public static class ToViewModelExtension
    {
        public static TDestination ToViewModel<TSource, TDestination>(this TSource source) where TDestination : IModelContainer<TSource>, new()
        {
            TDestination destination = new TDestination();

            destination.Model = source;

            return destination;
        }

        public static List<TDestination> ToViewModels<TSource, TDestination>(this IEnumerable<TSource> source) where TDestination : IModelContainer<TSource>, new()
        {
            return source.Select(o => o.ToViewModel<TSource, TDestination>()).ToList();
        }
    }
}
