﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Zen.Tracker.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Conversations operations.
    /// </summary>
    public partial interface IConversations
    {
        /// <summary>
        /// Start a new conversation
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<Conversation>> StartConversationWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get information about an existing conversation
        /// </summary>
        /// <param name='conversationId'>
        /// </param>
        /// <param name='watermark'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<Conversation>> ReconnectToConversationWithHttpMessagesAsync(string conversationId, string watermark = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get activities in this conversation. This method is paged with the
        /// 'watermark' parameter.
        /// </summary>
        /// <param name='conversationId'>
        /// Conversation ID
        /// </param>
        /// <param name='watermark'>
        /// (Optional) only returns activities newer than this watermark
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<ActivitySet>> GetActivitiesWithHttpMessagesAsync(string conversationId, string watermark = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Send an activity
        /// </summary>
        /// <param name='conversationId'>
        /// Conversation ID
        /// </param>
        /// <param name='activity'>
        /// Activity to send
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<ResourceResponse>> PostActivityWithHttpMessagesAsync(string conversationId, Activity activity, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Upload file(s) and send as attachment(s)
        /// </summary>
        /// <param name='conversationId'>
        /// </param>
        /// <param name='file'>
        /// </param>
        /// <param name='userId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<ResourceResponse>> UploadWithHttpMessagesAsync(string conversationId, System.IO.Stream file, string userId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
