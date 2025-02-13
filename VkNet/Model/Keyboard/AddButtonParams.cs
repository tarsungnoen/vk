﻿using System;
using JetBrains.Annotations;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Параметры для создания кнопки в билдере
/// </summary>
[Serializable]
public class AddButtonParams
{
	/// <summary>
	/// Надписть на кнопке
	/// </summary>
	public string Label { get; set; }

	/// <summary>
	/// Ссылка на кнопке
	/// </summary>
	public string Link { get; set; }

	/// <summary>
	/// Парметры для платежа
	/// </summary>
	public string Hash { get; set; }

	/// <summary>
	/// Дополнительная информация о кнопке
	/// </summary>
	public string Extra { get; set; }

	/// <summary>
	/// Цвет кнопки
	/// </summary>
	public KeyboardButtonColor Color { get; set; } = default;

	/// <summary>
	/// Основная информация о кнопке
	/// </summary>
	[CanBeNull]
	public string Type { get; set; } = null;

	/// <summary>
	/// Тип клавиши
	/// </summary>
	public KeyboardButtonActionType? ActionType { get; set; }

	/// <summary>
	/// Любой из интентов, требующий подписки.
	/// </summary>
	public Intent Intent { get; set; }

	/// <summary>
	/// Дополнительное поле для confirmed_notification.
	/// </summary>
	public byte? SubscribeId { get; set; }

	/// <summary>
	/// user_id: 1-2e9
	/// </summary>
	public long? PeerId { get; set; }
}