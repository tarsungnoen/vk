﻿using VkNet.Abstractions;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class LikesCategory : ILikesCategory
{
	/// <summary>
	/// API
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// API для работы с лайками.
	/// </summary>
	/// <param name="vk"> The vk. </param>
	public LikesCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public VkCollection<long> GetList(LikesGetListParams @params, bool skipAuthorization = false)
	{
		if (@params.Extended == true)
			throw new VkApiException("Если параметр Extended = true то используйте метод GetListEx()");

		var parameters = new VkParameters
		{
			{
				"type", @params.Type
			},
			{
				"owner_id", @params.OwnerId
			},
			{
				"item_id", @params.ItemId
			},
			{
				"page_url", @params.PageUrl
			},
			{
				"filter", @params.Filter
			},
			{
				"friends_only", @params.FriendsOnly
			},
			{
				"extended", @params.Extended
			},
			{
				"offset", @params.Offset
			},
			{
				"skip_own", @params.SkipOwn
			}
		};

		if (@params.FriendsOnly.HasValue && @params.FriendsOnly.Value)
		{
			if (@params.Count <= 100)
			{
				parameters.Add("count", @params.Count);
			}
		} else
		{
			if (@params.Count <= 1000)
			{
				parameters.Add("count", @params.Count);
			}
		}

		return _vk.Call("likes.getList", parameters, skipAuthorization)
			.ToVkCollectionOf<long>(selector: x => x);
	}

	/// <inheritdoc />
	public UserOrGroup GetListEx(LikesGetListParams @params)
	{
		if (@params.Extended == false)
			throw new VkApiException("Если параметр Extended = false то используйте метод GetList()");

		var parameters = new VkParameters
		{
			{
				"type", @params.Type
			},
			{
				"owner_id", @params.OwnerId
			},
			{
				"item_id", @params.ItemId
			},
			{
				"page_url", @params.PageUrl
			},
			{
				"filter", @params.Filter
			},
			{
				"friends_only", @params.FriendsOnly
			},
			{
				"extended", @params.Extended
			},
			{
				"offset", @params.Offset
			},
			{
				"skip_own", @params.SkipOwn
			}
		};

		if (@params.FriendsOnly.HasValue && @params.FriendsOnly.Value)
		{
			if (@params.Count <= 100)
			{
				parameters.Add("count", @params.Count);
			}
		} else
		{
			if (@params.Count <= 1000)
			{
				parameters.Add("count", @params.Count);
			}
		}

		return _vk.Call<UserOrGroup>("likes.getList", parameters, true);

	}

	/// <inheritdoc />
	public long Add(LikesAddParams @params)
	{
		var response = _vk.Call("likes.add", new()
		{
			{
				"type", @params.Type
			},
			{
				"item_id", @params.ItemId
			},
			{
				"owner_id", @params.OwnerId
			},
			{
				"access_key", @params.AccessKey
			},
			{
				"ref", @params.Reference
			}
		});

		return response[key: "likes"];
	}



	/// <inheritdoc />
	public long Delete(LikeObjectType type, long itemId, long? ownerId = null)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"item_id", itemId
			},
			{
				"owner_id", ownerId
			}
		};

		var response = _vk.Call("likes.delete", parameters);

		return response[key: "likes"];
	}

	/// <inheritdoc />
	public bool IsLiked(out bool copied, LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"item_id", itemId
			},
			{
				"user_id", userId
			},
			{
				"owner_id", ownerId
			}
		};

		var resp = _vk.Call("likes.isLiked", parameters);

		copied = resp[key: "copied"];

		return resp[key: "liked"];
	}
}