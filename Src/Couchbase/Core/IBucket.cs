﻿
using System;
using System.Threading.Tasks;
using Couchbase.IO.Operations;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Core
{
    /// <summary>
    /// Represents a Couchbase Bucket object for performing CRUD operations on Documents and Key/Value pairs, View
    /// queries, and executing N1QL queries.
    /// </summary>
    public interface IBucket : IDisposable
    {
        /// <summary>
        /// The name of the Couchbase Bucket. This is visible from the Couchbase Server Management Console.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Inserts or replaces an existing document into Couchbase Server.
        /// </summary>
        /// <typeparam name="T">The Type of the value to be inserted.</typeparam>
        /// <param name="key">The unique key for indexing.</param>
        /// <param name="value">The value for the key.</param>
        /// <returns>An object implementing the <see cref="IOperationResult{T}"/>interface.</returns>
        IOperationResult<T> Insert<T>(string key, T value);

        /// <summary>
        /// Gets a value for a given key.
        /// </summary>
        /// <typeparam name="T">The Type of the value object to be retrieved.</typeparam>
        /// <param name="key">The unique Key to use to lookup the value.</param>
        /// <returns>An object implementing the <see cref="IOperationResult{T}"/>interface.</returns>
        IOperationResult<T> Get<T>(string key);

        /// <summary>
        /// Gets a Task that can be awaited on for a given Key and value.
        /// </summary>
        /// <typeparam name="T">The Type of the value object to be retrieved.</typeparam>
        /// <param name="key">The unique Key to use to lookup the value.</param>
        /// <returns>A Task that can be awaited on for it's <see cref="IOperationResult{T}"/> value.</returns>
        Task<IOperationResult<T>> GetAsync<T>(string key);

        /// <summary>
        /// Inserts or replaces an existing document into Couchbase Server.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>A Task that can be awaited on for it's <see cref="IOperationResult{T}"/> value.</returns>
        Task<IOperationResult<T>> InsertAsync<T>(string key, T value);

        /// <summary>
        /// Executes a View query and returns the result.
        /// </summary>
        /// <typeparam name="T">The Type to deserialze the results to. The dynamic Type works well.</typeparam>
        /// <param name="query">The <see cref="Couchbase.Views.IViewQuery"/> used to generate the results.</param>
        /// <returns>An instance of an object that implements the <see cref="T:Couchbase.Views.IViewResult{T}"/> Type with the results of the query.</returns>
        /// <remarks>Use one of the IBucket.CreateQuery overloads to generate the query.</remarks>
        IViewResult<T> Query<T>(IViewQuery query);

        /// <summary>
        /// Executes a N1QL query against the Couchbase Cluster.
        /// </summary>
        /// <typeparam name="T">The Type to deserialze the results to. The dynamic Type works well.</typeparam>
        /// <param name="query">An ad-hoc N1QL query.</param>
        /// <returns>An instance of an object that implements the <see cref="Couchbase.N1QL.IQueryResult{T}"/> interface; the results of the query.</returns>
        IQueryResult<T> Query<T>(string query);

        /// <summary>
        /// Creates an instance of an object that implements <see cref="Couchbase.Views.IViewQuery"/>, which targets a given bucket.
        /// </summary>
        /// <param name="development">True will execute on the development dataset.</param>
        /// <returns>An <see cref="T:Couchbase.Views.IViewQuery"/> which can have more filters and options applied to it.</returns>
        IViewQuery CreateQuery(bool development);

        /// <summary>
        /// Creates an instance of an object that implements <see cref="Couchbase.Views.IViewQuery"/>, which targets a given bucket, design document and view.
        /// </summary>
        /// <param name="designdoc">The design document that the View belongs to.</param>
        /// <param name="development">True will execute on the development dataset.</param>
        /// <returns>An <see cref="T:Couchbase.Views.IViewQuery"/> which can have more filters and options applied to it.</returns>
        IViewQuery CreateQuery(string designdoc, bool development);

        /// <summary>
        /// Creates an instance of an object that implements <see cref="Couchbase.Views.IViewQuery"/>, which targets a given bucket and design document.
        /// </summary>
        /// <param name="designdoc">The design document that the View belongs to.</param>>
        /// <param name="view">The View to query.</param>
        /// <param name="development">True will execute on the development dataset.</param>
        /// <returns>An <see cref="T:Couchbase.Views.IViewQuery"/> which can have more filters and options applied to it.</returns>
        IViewQuery CreateQuery(string designdoc, string view, bool development);
    }
}
