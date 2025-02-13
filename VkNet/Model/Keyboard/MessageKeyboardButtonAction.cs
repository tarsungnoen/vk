using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация о кнопке клавиатуры.
/// </summary>
[Serializable]
[JsonObject(MemberSerialization.OptOut)]
public class MessageKeyboardButtonAction
{
	/// <summary>
	/// Содержит <c>'text'</c>
	/// </summary>
	[JsonProperty("type")]
	public KeyboardButtonActionType? Type { get; set; }

	/// <summary>
	/// Дополнительная информация.
	/// </summary>
	/// <remarks>JSON строка с <c>payload</c>, до 255 символов</remarks>
	[CanBeNull]
	[JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
	public string Payload { get; set; }

	/// <summary>
	/// Текст на кнопке, до 40 символов
	/// </summary>
	[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
	public string Label { get; set; }

	/// <summary>
	/// Ссылка, которую необходимо открыть по нажатию на кнопку.
	/// </summary>
	[JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
	public Uri Link { get; set; }

	/// <summary>
	/// <list type="KeyboardButtonActionType">
	/// <listheader>
	/// <term>Значение параметра <see cref="Type"/></term>
	/// <description>description</description>
	/// </listheader>
	/// <item>
	/// <term><see cref="KeyboardButtonActionType.OpenApp"/></term>
	/// <description>хэш для навигации в приложении, будет передан в строке параметров запуска после символа #</description>
	/// </item>
	/// <item>
	/// <term><see cref="KeyboardButtonActionType.Vkpay"/></term>
	/// <description>строка, содержащая параметры платежа VK Pay и идентификатор приложения в параметре <c>aid</c>, разделенные &amp;.</description>
	/// </item>
	/// <item>
	/// <term><see cref="KeyboardButtonActionType.Location"/></term>
	/// <description>По нажатию отправляет местоположение в диалог с ботом/беседу.</description>
	/// </item>
	/// <item>
	/// <term><see cref="KeyboardButtonActionType.OpenLink"/></term>
	/// <description>Открывает указанную ссылку.</description>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// Пример: <c>action=transfer-to-group&amp;group_id=1&amp;aid=10.</c>
	/// </remarks>
	[JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
	public string Hash { get; set; }

	/// <summary>
	/// Идентификатор вызываемого приложения с типом <see cref="KeyboardButtonActionType.OpenApp"/>.
	/// </summary>
	/// <remarks>
	/// Пока может использоваться только приложение, которому мы выдали под это доступ.
	/// Получить доступ для Вашего приложения Вы можете <a href="https://vk.com/support?act=home_api">здесь </a>;
	/// </remarks>
	[JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
	public ulong? AppId { get; set; }

	/// <summary>
	/// Идентификатор сообщества, в котором установлено приложение, если требуется открыть в контексте сообщества.
	/// </summary>
	/// <remarks>
	/// Для <see cref="Type"/> со значением <see cref="KeyboardButtonActionType.OpenApp"/>
	/// </remarks>
	[JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
	public long? OwnerId { get; set; }

	/// <summary>
	/// user_id: 1-2e9
	/// </summary>
	[JsonProperty("peer_id", NullValueHandling = NullValueHandling.Ignore)]
	public long? PeerId { get; set; }

	/// <summary>
	/// Любой из интентов, требующий подписки.
	/// </summary>
	[JsonProperty("intent", NullValueHandling = NullValueHandling.Ignore)]
	public Intent? Intent { get; set; }

	/// <summary>
	/// Дополнительное поле для confirmed_notification.
	/// </summary>
	[JsonProperty("subscribe_id", NullValueHandling = NullValueHandling.Ignore)]
	public byte? SubscribeId { get; set; }
}