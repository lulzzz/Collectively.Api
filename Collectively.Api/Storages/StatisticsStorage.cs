﻿using System;
using System.Threading.Tasks;
using Collectively.Api.Queries;
using Collectively.Common.Extensions;
using Collectively.Common.Types;


namespace Collectively.Api.Storages
{
    public class StatisticsStorage : IStatisticsStorage
    {
        private readonly IStorageClient _storageClient;
        private readonly string RemarkStatisticsEndpoint = "statistics/remarks";
        private readonly string UserStatisticsEndpoint = "statistics/users";
        private readonly string CategoryStatisticsEndpoint = "statistics/categories";
        private readonly string TagStatisticsEndpoint = "statistics/tags";

        public StatisticsStorage(IStorageClient storageClient)
        {
            _storageClient = storageClient;
        }

        public async Task<Maybe<PagedResult<UserStatisticsDto>>> BrowseUserStatisticsAsync(BrowseUserStatistics query)
            => await _storageClient
                .GetFilteredCollectionAsync<UserStatisticsDto, BrowseUserStatistics>(query, UserStatisticsEndpoint);

        public async Task<Maybe<UserStatisticsDto>> GetUserStatisticsAsync(GetUserStatistics query)
            => await _storageClient
                .GetAsync<UserStatisticsDto>($"{UserStatisticsEndpoint}/{query.Id}");

        public async Task<Maybe<PagedResult<RemarkStatisticsDto>>> BrowseRemarkStatisticsAsync(BrowseRemarkStatistics query)
            => await _storageClient
                .GetFilteredCollectionAsync<RemarkStatisticsDto, BrowseRemarkStatistics>(query, RemarkStatisticsEndpoint);

        public async Task<Maybe<RemarkStatisticsDto>> GetRemarkStatisticsAsync(GetRemarkStatistics query)
            => await _storageClient
                .GetAsync<RemarkStatisticsDto>($"{RemarkStatisticsEndpoint}/{query.Id}");

        public async Task<Maybe<RemarksCountStatisticsDto>> GetRemarksCountStatisticsAsync(GetRemarksCountStatistics query)
            => await _storageClient
                .GetAsync<RemarksCountStatisticsDto>($"{RemarkStatisticsEndpoint}/general".ToQueryString(query));

        public async Task<Maybe<PagedResult<CategoryStatisticsDto>>> BrowseCategoryStatisticsAsync(
                BrowseCategoryStatistics query)
            => await _storageClient
                .GetFilteredCollectionAsync<CategoryStatisticsDto, BrowseCategoryStatistics>(query, CategoryStatisticsEndpoint);

        public async Task<Maybe<PagedResult<TagStatisticsDto>>> BrowseTagStatisticsAsync(BrowseTagStatistics query)
            => await _storageClient
                .GetFilteredCollectionAsync<TagStatisticsDto, BrowseTagStatistics>(query, TagStatisticsEndpoint);
    }
}