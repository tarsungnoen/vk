using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Параметры запроса ads.getStatistics
/// </summary>
[Serializable]
public class GetStatisticsParams
{
	/// <summary>
	/// Идентификатор рекламного кабинета. обязательный параметр, целое число
	/// </summary>
	[JsonProperty("account_id")]
	public long AccountId { get; set; }

	/// <summary>
	/// Тип запрашиваемых объектов, которые перечислены в параметре ids:
	/// ad — объявления;
	/// campaign — кампании;
	/// client — клиенты;
	/// office — кабинет.
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("ids_type")]
	public IdsType IdsType { get; set; }

	/// <summary>
	/// Перечисленные через запятую id запрашиваемых объявлений, кампаний, клиентов или кабинета, в зависимости от того, что указано в параметре ids_type. Максимум 2000 объектов. обязательный параметр, строка
	/// </summary>
	[JsonProperty("ids")]
	public string Ids { get; set; }

	/// <summary>
	/// Способ группировки данных по датам:
	/// day — статистика по дням;
	/// month — статистика по месяцам;
	/// overall — статистика за всё время;
	/// Временные ограничения задаются параметрами date_from и date_to. обязательный параметр, строка
	/// </summary>
	[JsonProperty("period")]
	public string Period { get; set; }

	/// <summary>
	/// Начальная дата выводимой статистики. Используется разный формат дат для разного значения параметра period:
	/// day: YYYY-MM-DD, пример: 2011-09-27 - 27 сентября 2011
	/// 0 — день создания;
	/// month: YYYY-MM, пример: 2011-09 - сентябрь 2011
	/// 0 — месяц создания;
	/// overall: 0
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("date_from")]
	public string DateFrom { get; set; }

	/// <summary>
	/// Конечная дата выводимой статистики. Используется разный формат дат для разного значения параметра period:
	/// day: YYYY-MM-DD, пример: 2011-09-27 - 27 сентября 2011
	/// 0 — текущий день;
	/// month: YYYY-MM, пример: 2011-09 - сентябрь 2011
	/// 0 — текущий месяц;
	/// overall: 0
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("date_to")]
	public string DateTo { get; set; }
}