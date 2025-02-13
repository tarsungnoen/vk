﻿using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StreamingCategory : IStreamingCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public StreamingCategory(VkApi vk) => _vk = vk;

	/// <inheritdoc />
	public StreamingServerUrl GetServerUrl() => _vk.Call<StreamingServerUrl>("streaming.getServerUrl", VkParameters.Empty);

	/// <inheritdoc />
	public StreamingSettings GetSettings() => _vk.Call<StreamingSettings>("streaming.getSettings", VkParameters.Empty);

	/// <inheritdoc />
	public ReadOnlyCollection<StreamingStats> GetStats(string type
														, string interval
														, DateTime? startTime = null
														, DateTime? endTime = null)
	{
		var result = _vk.Call<ReadOnlyCollection<StreamingStats>>("streaming.getStats"
			, new()
			{
				{
					"type", type
				},
				{
					"interval", interval
				},
				{
					"start_time", startTime
				},
				{
					"end_time", endTime
				}
			});

		return result;
	}

	/// <inheritdoc />
	public bool SetSettings(MonthlyLimit monthlyTier) => _vk.Call<bool>("streaming.setSettings", new()
	{
		{
			"monthly_tier", monthlyTier
		}
	});

	/// <inheritdoc />
	public string GetStem(string word) => _vk.Call("streaming.getStem", new()
	{
		{
			"word", word
		}
	})["stem"];
}