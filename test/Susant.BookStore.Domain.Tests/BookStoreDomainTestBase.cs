﻿using Volo.Abp.Modularity;

namespace Susant.BookStore;

/* Inherit from this class for your domain layer tests. */
public abstract class BookStoreDomainTestBase<TStartupModule> : BookStoreTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
