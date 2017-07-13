﻿using Collectively.Api.Tests.EndToEnd.Framework;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using Collectively.Services.Storage.Models.Users;

namespace Collectively.Api.Tests.EndToEnd.Modules
{
    public abstract class UserModule_specs : ModuleBase_specs
    {
        protected static IEnumerable<User> GetUsers()
            => HttpClient.GetCollectionAsync<User>("users").WaitForResult();
    }

    [Subject("Users collection")]
    public class when_fetching_the_users : UserModule_specs
    {
        static IEnumerable<User> Users;

        Establish context = () => Initialize();

        Because of = () => Users = GetUsers();

        It should_return_non_empty_collection = () =>
        {
            Users.ShouldNotBeEmpty();
            foreach (var user in Users)
            {
                user.Id.ShouldNotEqual(Guid.Empty);
                user.UserId.ShouldNotBeEmpty();
                user.Name.ShouldNotBeEmpty();
                user.Role.ShouldNotBeEmpty();
                user.State.ShouldNotBeEmpty();
                user.CreatedAt.ShouldNotEqual(DateTime.UtcNow);
            }
        };
    }
}