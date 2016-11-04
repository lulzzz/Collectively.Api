﻿using System.Linq;
using Coolector.Api.Validation;
using Coolector.Common.Commands.Remarks;
using Coolector.Common.Types;
using Coolector.Dto.Remarks;
using Nancy;
using BrowseRemarkCategories = Coolector.Api.Queries.BrowseRemarkCategories;
using BrowseRemarks = Coolector.Api.Queries.BrowseRemarks;
using GetRemark = Coolector.Api.Queries.GetRemark;
using ICommandDispatcher = Coolector.Api.Commands.ICommandDispatcher;
using IRemarkStorage = Coolector.Api.Storages.IRemarkStorage;

namespace Coolector.Api.Modules
{
    public class RemarkModule : ModuleBase
    {
        public RemarkModule(ICommandDispatcher commandDispatcher,
            IRemarkStorage remarkStorage,
            IValidatorResolver validatorResolver)
            : base(commandDispatcher, validatorResolver, modulePath: "remarks")
        {
            Get("", async args => await FetchCollection<BrowseRemarks, RemarkDto>
                (async x => await remarkStorage.BrowseAsync(x)).HandleAsync());

            Get("categories", async args => await FetchCollection<BrowseRemarkCategories, RemarkCategoryDto>
                (async x => await remarkStorage.BrowseCategoriesAsync(x)).HandleAsync());

            Get("{id}", async args => await Fetch<GetRemark, RemarkDto>
                (async x => await remarkStorage.GetAsync(x.Id)).HandleAsync());

            Post("", async args => await For<CreateRemark>().DispatchAsync());

            Put("", async args => await For<ResolveRemark>().DispatchAsync());

            Delete("{remarkId}", async args => await For<DeleteRemark>().DispatchAsync());
        }
    }
}