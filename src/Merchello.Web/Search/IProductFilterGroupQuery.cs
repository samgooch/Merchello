﻿namespace Merchello.Web.Search
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Merchello.Web.Models;

    /// <summary>
    /// Defines a ProductFilterGroupService.
    /// </summary>
    public interface IProductFilterGroupQuery : IEntityProxyQuery<IProductFilterGroup>
    {
        /// <summary>
        /// Gets a collection of <see cref="IProductFilterGroup"/> that has at least one filter that contains a product with key passed as parameter.
        /// </summary>
        /// <param name="productKey">
        /// The product key.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IProductFilterGroup}"/>.
        /// </returns>
        IEnumerable<IProductFilterGroup> GetFilterGroupsContainingProduct(Guid productKey);

        /// <summary>
        /// Gets a collection of <see cref="IProductFilterGroup"/> that has at least one filter that contains a product with key passed as parameter.
        /// </summary>
        /// <param name="productKeys">
        /// The product keys.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IProductFilterGroup}"/>.
        /// </returns>
        IEnumerable<IProductFilterGroup> GetFilterGroupsContainingProducts(Guid[] productKeys);

        /// <summary>
        /// Gets a collection of <see cref="IProductFilterGroup"/> in which NONE of the filters contains a product with key passed as parameter.
        /// </summary>
        /// <param name="productKey">
        /// The product key.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IProductFilterGroup}"/>.
        /// </returns>
        IEnumerable<IProductFilterGroup> GetFilterGroupsNotContainingProduct(Guid productKey);

        /// <summary>
        /// Gets a collection of FilterGroups with information relating to the context in which they are going to be applied.
        /// </summary>
        /// <param name="collectionKeys">
        /// The collection keys.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{IPrimedProductFilterGroup}"/>.
        /// </returns>
        IEnumerable<IPrimedProductFilterGroup> GetFilterGroupsForCollectionContext(params Guid[] collectionKeys);
    }
}