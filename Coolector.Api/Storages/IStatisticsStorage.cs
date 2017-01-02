﻿using System.Threading.Tasks;
using Coolector.Api.Queries;
using Coolector.Common.Types;
using Coolector.Services.Statistics.Shared.Dto;

namespace Coolector.Api.Storages
{
    public interface IStatisticsStorage
    {
        Task<Maybe<PagedResult<UserStatisticsDto>>> BrowseUserStatisticsAsync(BrowseUserStatistics query);
        Task<Maybe<UserStatisticsDto>> GetUserStatisticsAsync(GetUserStatistics query);
        Task<Maybe<PagedResult<RemarkStatisticsDto>>> BrowseRemarkStatisticsAsync(BrowseRemarkStatistics query);
        Task<Maybe<RemarkStatisticsDto>> GetRemarkStatisticsAsync(GetRemarkStatistics query);
        Task<Maybe<RemarkGeneralStatisticsDto>> GetRemarkGeneralStatisticsAsync(GetRemarkGeneralStatistics query);
    }
}