using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с документами (получение списка, загрузка,
/// удаление и т.д.)
/// </summary>
public interface IDocsCategoryAsync
{
	/// <summary>
	/// Возвращает расширенную информацию о документах пользователя или сообщества.
	/// </summary>
	/// <param name="count">
	/// Количество документов, информацию о которых нужно вернуть. По умолчанию — все
	/// документы.
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выборки определенного подмножества документов.
	/// Положительное число.
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежат документы.
	/// Целое число, по
	/// умолчанию идентификатор текущего пользователя.
	/// </param>
	/// <param name="type"> Фильтр по типу документа. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов документов.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.get
	/// </remarks>
	Task<VkCollection<Document>> GetAsync(int? count = null,
										int? offset = null,
										long? ownerId = null,
										DocFilter? type = null,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию о документах по их идентификаторам.
	/// </summary>
	/// <param name="docs">
	/// Идентификаторы документов, информацию о которых нужно
	/// вернуть.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает список объектов документов. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.getById
	/// </remarks>
	Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки документов.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества (если необходимо загрузить документ в список
	/// документов сообщества).
	/// Если документ нужно загрузить в список пользователя, метод вызывается без
	/// дополнительных параметров. Положительное
	/// число
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает объект UploadServerInfo </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.getUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки документов в папку Отправленные, для
	/// последующей отправки документа на стену
	/// или личным сообщением.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества, в которое нужно загрузить документ. Положительное
	/// число.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает объект UploadServerInfo </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.getWallUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null,
													CancellationToken token = default);

	/// <summary>
	/// Сохраняет документ после его успешной загрузки на сервер.
	/// </summary>
	/// <param name="file">
	/// JSON-объект с полем file, возвращаемый после успешной загрузки документа
	/// сервер. Обязательный
	/// параметр.
	/// </param>
	/// <param name="title"> Название документа. </param>
	/// <param name="tags"> Метки для поиска. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> Возвращает массив с загруженными объектами. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.save
	/// </remarks>
	Task<ReadOnlyCollection<Attachment>> SaveAsync(string file,
													string title = null,
													string tags = null,
													CancellationToken token = default);


	/// <summary>
	/// Удаляет документ пользователя или группы.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит документ. Целое
	/// число,
	/// обязательный параметр
	/// </param>
	/// <param name="docId">
	/// Идентификатор документа. Положительное число, обязательный
	/// параметр
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает 1. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.delete
	/// </remarks>
	Task<bool> DeleteAsync(long ownerId,
							long docId,
							CancellationToken token = default);

	/// <summary>
	/// Копирует документ в документы текущего пользователя.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит документ. Целое
	/// число,
	/// обязательный параметр
	/// </param>
	/// <param name="docId">
	/// Идентификатор документа. Положительное число, обязательный
	/// параметр
	/// </param>
	/// <param name="accessKey">
	/// Ключ доступа документа. Этот параметр следует передать, если вместе с
	/// остальными данными о
	/// документе было возвращено поле access_key.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданного
	/// документа (did).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.add
	/// </remarks>
	Task<long> AddAsync(long ownerId,
						long docId, string
							accessKey = null,
						CancellationToken token = default);

	/// <summary>
	/// Возвращает доступные типы документы для пользователя.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежат документы.
	/// целое число, по
	/// умолчанию идентификатор текущего пользователя, обязательный параметр (Целое
	/// число, по умолчанию идентификатор
	/// текущего пользователя, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов type.
	/// Объект type — тип документов.
	/// id идентификатор типа.
	/// положительное число name название типа.
	/// строка count число документов;
	/// int (числовое значение).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.getTypes
	/// </remarks>
	Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает результаты поиска по документам.
	/// </summary>
	/// <param name="query">
	/// Строка поискового запроса. Например, зеленые тапочки. строка, обязательный
	/// параметр, максимальная
	/// длина 512 (Строка, обязательный параметр, максимальная длина 512).
	/// </param>
	/// <param name="searchOwn"> 1 — искать среди собственных документов пользователя. </param>
	/// <param name="count">
	/// Количество документов, информацию о которых нужно вернуть. положительное число
	/// (Положительное
	/// число).
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выборки определенного подмножества документов.
	/// положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов документов.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.search
	/// </remarks>
	Task<VkCollection<Document>> SearchAsync(string query,
											bool searchOwn,
											long? count = null,
											long? offset = null,
											CancellationToken token = default);

	/// <summary>
	/// Редактирует документ пользователя или группы.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит документ.
	/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо
	/// указывать со знаком "-" — например,
	/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число, по умолчанию идентификатор
	/// текущего пользователя, обязательный параметр (Целое число, по умолчанию
	/// идентификатор текущего пользователя,
	/// обязательный параметр).
	/// </param>
	/// <param name="docId">
	/// Идентификатор документа. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="title">
	/// Название документа. строка, максимальная длина 128 (Строка, максимальная длина
	/// 128).
	/// </param>
	/// <param name="tags">
	/// Метки для поиска. список слов, разделенных через запятую (Список слов,
	/// разделенных через запятую).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/docs.edit
	/// </remarks>
	Task<bool> EditAsync(long ownerId,
						long docId,
						string title,
						IEnumerable<string> tags,
						CancellationToken token = default);

	/// <summary>
	/// Получает адрес сервера для загрузки документа в личное сообщение.
	/// </summary>
	/// <param name="peerId"> идентификатор назначения </param>
	/// <param name="type">
	/// тип документа. Возможные значения:
	/// doc — обычный документ;
	/// audio_message — голосовое сообщение.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> </returns>
	Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null,
														DocMessageType? type = null,
														CancellationToken token = default);
}