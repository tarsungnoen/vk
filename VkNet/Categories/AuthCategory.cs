﻿using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AuthCategory : IAuthCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Методы для работы с подарками.
	/// </summary>
	/// <param name="vk"> API. </param>
	public AuthCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
	{
		var parameters = new VkParameters
		{
			{
				"phone", phone
			},
			{
				"client_id", clientId
			},
			{
				"client_secret", clientSecret
			},
			{
				"auth_by_phone", authByPhone
			}
		};

		return _vk.Call<bool>("auth.checkPhone", parameters);
	}

	/// <inheritdoc />
	public string Signup(AuthSignupParams @params) => _vk.Call<string>("auth.signup", new()
	{
		{
			"first_name", @params.FirstName
		},
		{
			"last_name", @params.LastName
		},
		{
			"birthday", @params.Birthday
		},
		{
			"client_id", @params.ClientId
		},
		{
			"client_secret", @params.ClientSecret
		},
		{
			"phone", @params.Phone
		},
		{
			"password", @params.Password
		},
		{
			"test_mode", @params.TestMode
		},
		{
			"voice", @params.Voice
		},
		{
			"sex", @params.Sex
		},
		{
			"sid", @params.Sid
		}
	});

	/// <inheritdoc />
	public AuthConfirmResult Confirm(AuthConfirmParams @params) => _vk.Call<AuthConfirmResult>("auth.confirm", new()
	{
		{
			"client_id", @params.ClientId
		},
		{
			"client_secret", @params.ClientSecret
		},
		{
			"phone", @params.Phone
		},
		{
			"code", @params.Code
		},
		{
			"password", @params.Password
		},
		{
			"test_mode", @params.TestMode
		},
		{
			"intro", @params.Intro
		}
	});

	/// <inheritdoc />
	public string Restore(string phone, string lastName)
	{
		var response = _vk.Call("auth.restore"
			, new()
			{
				{
					"phone", phone
				},
				{
					"last_name", lastName
				}
			});

		return response[key: "sid"];
	}
}