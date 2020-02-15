﻿using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с универсальным методом.
	/// </summary>
	public partial class ExecuteCategory : IExecuteCategory
	{
		/// <inheritdoc />
		public VkResponse Execute(string code, VkParameters vkParameters = default)
		{
			var parameters = new VkParameters
			{
				{ "code", code }
			};

			if (vkParameters == default)
			{
				return _vk.Call("execute", parameters);
			}

			foreach (var pair in vkParameters)
			{
				parameters.Add(pair.Key.StartsWith("Args.") ? pair.Key : $"Args.{pair.Key}", pair.Value);
			}

			return _vk.Call("execute", parameters);
		}

		/// <inheritdoc />
		public T Execute<T>(string code, VkParameters vkParameters = default)
		{
			var parameters = new VkParameters
			{
				{ "code", code }
			};

			if (vkParameters == default)
			{
				return _vk.Call<T>("execute", parameters);
			}

			foreach (var pair in vkParameters)
			{
				parameters.Add(pair.Key.StartsWith("Args.") ? pair.Key : $"Args.{pair.Key}", pair.Value);
			}

			return _vk.Call<T>("execute", parameters);
		}

		/// <inheritdoc />
		public T StoredProcedure<T>(string procedureName, VkParameters vkParameters)
		{
			return _vk.Call<T>($"execute.{procedureName}", vkParameters);
		}
	}
}