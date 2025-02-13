﻿using System;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class NewsFeedCategory : INewsFeedCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Методы для работы с новостной лентой пользователя.
	/// </summary>
	/// <param name="vk"> API. </param>
	public NewsFeedCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public NewsFeed Get(NewsFeedGetParams @params) => _vk.Call<NewsFeed>("newsfeed.get", new()
	{
		{
			"filters", @params.Filters
		},
		{
			"return_banned", @params.ReturnBanned
		},
		{
			"start_time", @params.StartTime
		},
		{
			"end_time", @params.EndTime
		},
		{
			"max_photos", @params.MaxPhotos
		},
		{
			"source_ids", @params.SourceIds
		},
		{
			"start_from", @params.StartFrom
		},
		{
			"count", @params.Count
		},
		{
			"fields", @params.Fields
		},
		{
			"section", @params.Section
		}
	});

	/// <inheritdoc />
	public NewsFeed GetRecommended(NewsFeedGetRecommendedParams @params) => _vk.Call<NewsFeed>("newsfeed.getRecommended", new()
	{
		{
			"start_time", @params.StartTime
		},
		{
			"end_time", @params.EndTime
		},
		{
			"max_photos", @params.MaxPhotos
		},
		{
			"start_from", @params.StartFrom
		},
		{
			"count", @params.Count
		},
		{
			"fields", @params.Fields
		}
	});

	/// <inheritdoc />
	public NewsFeed GetComments(NewsFeedGetCommentsParams @params) => _vk.Call<NewsFeed>("newsfeed.getComments", new()
	{
		{
			"count", @params.Count
		},
		{
			"filters", @params.Filters
		},
		{
			"reposts", @params.Reposts
		},
		{
			"start_time", @params.StartTime
		},
		{
			"end_time", @params.EndTime
		},
		{
			"last_comments_count", @params.LastCommentsCount
		},
		{
			"start_from", @params.StartFrom
		},
		{
			"fields", @params.Fields
		}
	});

	/// <inheritdoc />
	public VkCollection<Mention> GetMentions(long? ownerId = null
											, DateTime? startTime = null
											, DateTime? endTime = null
											, long? offset = null
											, long? count = null)
	{
		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			},
			{
				"start_time", startTime
			},
			{
				"end_time", endTime
			},
			{
				"offset", offset
			}
		};

		if (count <= 50)
		{
			parameters.Add("count", count);
		}

		return _vk.Call<VkCollection<Mention>>("newsfeed.getMentions", parameters);
	}

	/// <inheritdoc />
	public NewsBannedList GetBanned() => _vk.Call<NewsBannedList>("newsfeed.getBanned", VkParameters.Empty);

	/// <inheritdoc />
	public NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase? nameCase = null)
	{
		var parameters = new VkParameters
		{
			{
				"extended", true
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		return _vk.Call<NewsBannedExList>("newsfeed.getBanned", parameters);
	}

	/// <inheritdoc />
	public bool AddBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
	{
		var parameters = new VkParameters
		{
			{
				"user_ids", userIds
			},
			{
				"group_ids", groupIds
			}
		};

		return _vk.Call<bool>("newsfeed.addBan", parameters);
	}

	/// <inheritdoc />
	public bool DeleteBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
	{
		var parameters = new VkParameters
		{
			{
				"user_ids", userIds
			},
			{
				"group_ids", groupIds
			}
		};

		return _vk.Call<bool>("newsfeed.deleteBan", parameters);
	}

	/// <inheritdoc />
	public bool IgnoreItem(NewsObjectTypes type, long ownerId, long itemId)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"owner_id", ownerId
			},
			{
				"item_id", itemId
			}
		};

		return _vk.Call<bool>("newsfeed.ignoreItem", parameters);
	}

	/// <inheritdoc />
	public bool UnignoreItem(NewsObjectTypes type, long ownerId, long itemId)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"owner_id", ownerId
			},
			{
				"item_id", itemId
			}
		};

		return _vk.Call<bool>("newsfeed.unignoreItem", parameters);
	}

	/// <inheritdoc />
	public NewsSearchResult Search(NewsFeedSearchParams @params)
	{
		var parameters = new VkParameters
		{
			{
				"q", @params.Query
			},
			{
				"extended", @params.Extended
			},
			{
				"latitude", @params.Latitude
			},
			{
				"longitude", @params.Longitude
			},
			{
				"start_time", @params.StartTime
			},
			{
				"end_time", @params.EndTime
			},
			{
				"start_from", @params.StartFrom
			},
			{
				"fields", @params.Fields
			}
		};

		if (@params.Count <= 200)
		{
			parameters.Add("count", @params.Count);
		}

		return _vk.Call<NewsSearchResult>("newsfeed.search", parameters);
	}

	/// <inheritdoc />
	public VkCollection<NewsUserListItem> GetLists(IEnumerable<long> listIds, bool? extended = null)
	{
		var parameters = new VkParameters
		{
			{
				"list_ids", listIds
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<VkCollection<NewsUserListItem>>("newsfeed.getLists", parameters);
	}

	/// <inheritdoc />
	public long SaveList(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null)
	{
		var parameters = new VkParameters
		{
			{
				"list_id", listId
			},
			{
				"title", title
			},
			{
				"source_ids", sourceIds
			},
			{
				"no_reposts", noReposts
			}
		};

		return _vk.Call<long>("newsfeed.saveList", parameters);
	}

	/// <inheritdoc />
	public bool DeleteList(long listId)
	{
		var parameters = new VkParameters
		{
			{
				"list_id", listId
			}
		};

		return _vk.Call<bool>("newsfeed.deleteList", parameters);
	}

	/// <inheritdoc />
	public bool Unsubscribe(CommentObjectType type, long itemId, long? ownerId = null)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"owner_id", ownerId
			},
			{
				"item_id", itemId
			}
		};

		return _vk.Call<bool>("newsfeed.unsubscribe", parameters);
	}

	/// <inheritdoc />
	public NewsSuggestions GetSuggestedSources(long? offset = null, long? count = null, bool? shuffle = null, UsersFields fields = null)
	{
		var parameters = new VkParameters
		{
			{
				"offset", offset
			},
			{
				"shuffle", shuffle
			},
			{
				"fields", fields
			}
		};

		if (count <= 1000)
		{
			parameters.Add("count", count);
		}

		return _vk.Call<NewsSuggestions>("newsfeed.getSuggestedSources", parameters);
	}
}