using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация информацию о том, каким образом (через интерфейс сайта, виджет и
/// т.п.) была создана запись на стене.
/// Используя данные из этого поля, разработчик может вывести уточняющую информацию
/// о том, как была создана запись на
/// стене
/// в своем приложении.
/// См. описание http://vk.com/dev/post_source
/// </summary>
[Serializable]
public class PostSource
{
	/// <summary>
	/// На данный момент поддерживаются следующие типы источников записи на стене.
	/// </summary>
	[JsonProperty("type")]
	public PostSourceType Type { get; set; }

	/// <summary>
	/// Название платформы, если оно доступно: android, iphone, wphone.
	/// </summary>
	[JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
	public Platform Platform { get; set; }

	/// <summary>
	/// Поле data является опциональным и содержит следующие данные в зависимости от
	/// значения поля type:
	/// </summary>
	[JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
	public PostSourceData Data { get; set; }

	/// <summary>
	/// Cодержит внешнюю ссылку на ресурс, с которого была опубликована запись.
	/// </summary>
	[JsonProperty("source_url")]
	public Uri Uri { get; set; }
}