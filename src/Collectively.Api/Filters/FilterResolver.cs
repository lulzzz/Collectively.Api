﻿using Autofac;
using Collectively.Common.Queries;
using Collectively.Common.Types;

namespace Collectively.Api.Filters
{
    public class FilterResolver : IFilterResolver
    {
        private readonly IComponentContext _context;

        public FilterResolver(IComponentContext context)
        {
            _context = context;
        }

        public IFilter<TResult, TQuery> Resolve<TResult, TQuery>() where TQuery : IQuery
        {
            IFilter<TResult, TQuery> filter;

            return _context.TryResolve(out filter) ? filter : new EmptyFilter<TResult, TQuery>();
        }
    }
}