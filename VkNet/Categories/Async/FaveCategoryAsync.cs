using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class FaveCategory
{
	/// <inheritdoc/>
	public Task<bool> AddArticleAsync(Uri url,
									string @ref = null,
									string trackCode = null,
									string source = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddArticle(url, @ref, trackCode, source), token);

	/// <inheritdoc/>
	public Task<bool> AddLinkAsync(Uri link,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddLink(link), token);

	/// <inheritdoc/>
	public Task<bool> AddPageAsync(ulong? userId = null,
									ulong? groupId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddPage(userId, groupId), token);

	/// <inheritdoc/>
	public Task<bool> AddPostAsync(FaveAddPostParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddPost(@params), token);

	/// <inheritdoc/>
	public Task<bool> AddProductAsync(long ownerId,
									long id,
									string accessKey = null,
									string @ref = null,
									string source = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddProduct(ownerId, id, accessKey, @ref, source), token);

	/// <inheritdoc/>
	public Task<FaveTag> AddTagAsync(string name,
									string position,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddTag(name, position), token);

	/// <inheritdoc/>
	public Task<bool> AddVideoAsync(long ownerId,
									long id,
									string accessKey = null,
									string @ref = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddVideo(ownerId, id, accessKey, @ref), token);

	/// <inheritdoc/>
	public Task<bool> EditTagAsync(long id,
									string name,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditTag(id, name), token);

	/// <inheritdoc/>
	public Task<VkCollection<FaveGetObject>> GetAsync(FaveGetParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params), token);

	/// <inheritdoc/>
	public Task<VkCollection<FaveGetPagesObject>> GetPagesAsync(FavePageType? type = null,
																IEnumerable<string> fields = null,
																ulong? offset = null,
																ulong? count = null,
																long? tagId = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPages(type, fields, offset, count, tagId), token);

	/// <inheritdoc/>
	public Task<VkCollection<FaveTag>> GetTagsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetTags, token);

	/// <inheritdoc/>
	public Task<bool> MarkSeenAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(MarkSeen, token);

	/// <inheritdoc/>
	public Task<bool> RemoveArticleAsync(long ownerId,
										ulong articleId,
										string @ref = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveArticle(ownerId, articleId, @ref), token);

	/// <inheritdoc/>
	public Task<bool> RemoveLinkAsync(string linkId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveLink(linkId), token);

	/// <inheritdoc/>
	public Task<bool> RemovePageAsync(long? userId = null,
									long? groupId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemovePage(userId, groupId), token);

	/// <inheritdoc/>
	public Task<bool> RemovePostAsync(long ownerId,
									long id,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemovePost(ownerId, id), token);

	/// <inheritdoc/>
	public Task<bool> RemoveProductAsync(long ownerId,
										long id,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveProduct(ownerId, id), token);

	/// <inheritdoc/>
	public Task<bool> RemoveTagAsync(long id,
									CancellationToken token = default) =>
	TypeHelper.TryInvokeMethodAsync(() =>
		RemoveTag(id), token);

	/// <inheritdoc/>
	public Task<bool> RemoveVideoAsync(long ownerId,
										long id,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveVideo(ownerId, id), token);

	/// <inheritdoc/>
	public Task<bool> ReorderTagsAsync(IEnumerable<long> ids,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderTags(ids), token);

	/// <inheritdoc/>
	public Task<bool> SetPageTagsAsync(ulong? userId = null,
										ulong? groupId = null,
										IEnumerable<long> tagIds = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetPageTags(userId, groupId, tagIds), token);

	/// <inheritdoc/>
	public Task<bool> SetTagsAsync(FaveSetTagsParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetTags(@params), token);

	/// <inheritdoc/>
	public Task<bool> TrackPageInteractionAsync(ulong? userId = null,
												ulong? groupId = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TrackPageInteraction(userId, groupId), token);
}