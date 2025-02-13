﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с видеофайлами.
/// </summary>
public interface IVideoCategoryAsync
{
	/// <summary>
	/// Возвращает информацию о видеозаписях.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов видеозаписей с
	/// дополнительным полем comments, содержащим
	/// число комментариев  у видеозаписи.
	/// Если был задан параметр extended=1, возвращаются дополнительные поля:
	/// privacy_view — настройки приватности в формате настроек приватности; (приходит
	/// только для текущего пользователя)
	/// privacy_comment — настройки приватности в формате настроек приватности;
	/// (приходит только для текущего пользователя)
	/// can_comment — может ли текущий пользователь оставлять комментарии к ролику (1 —
	/// может, 0 — не может, CancellationToken token = default);
	/// can_repost — может ли текущий пользователь скопировать ролик с помощью функции
	/// «Рассказать друзьям» (1 — может, 0 —
	/// не может, CancellationToken token = default);
	/// likes — информация об отметках «Мне нравится»:
	/// user_likes — есть ли отметка «Мне нравится» от текущего пользователя;
	/// count — число отметок «Мне нравится»;
	/// repeat — зацикливание воспроизведения видеозаписи (1 — зацикливается, 0 — не
	/// зацикливается).
	/// Если в Вашем приложении используется  прямая авторизация, возвращается
	/// дополнительное поле files, содержащее ссылку
	/// на файл с видео (если ролик размещен на сервере ВКонтакте) или ссылку на
	/// внешний ресурс (если ролик встроен с
	/// какого-либо видеохостинга).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.get
	/// </remarks>
	Task<VkCollection<Video>> GetAsync(VideoGetParams @params,
										CancellationToken token = default);

	/// <summary>
	/// Редактирует данные видеозаписи.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.edit
	/// </remarks>
	Task<bool> EditAsync(VideoEditParams @params,
						CancellationToken token = default);

	/// <summary>
	/// Добавляет видеозапись в список пользователя.
	/// </summary>
	/// <param name="targetId">
	/// Идентификатор пользователя или сообщества, в которое нужно добавить видео.
	/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
	/// указывать со знаком "-" — например,
	/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число (Целое число).
	/// </param>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число,
	/// обязательный параметр (Целое число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.add
	/// </remarks>
	Task<long> AddAsync(long videoId,
						long ownerId,
						long? targetId = null,
						CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера (необходимый для загрузки) и данные видеозаписи.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает объект, который имеет поля upload_url, video_id, title, description,
	/// owner_id.
	/// Метод может быть вызван не более 5000 раз в сутки для одного сервиса.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.save
	/// </remarks>
	Task<Video> SaveAsync(VideoSaveParams @params,
						CancellationToken token = default);

	/// <summary>
	/// Удаляет видеозапись со страницы пользователя.
	/// </summary>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="targetId">
	/// Идентификатор пользователя или сообщества, для которого нужно удалить
	/// видеозапись.
	/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
	/// указывать со знаком "-" — например,
	/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.delete
	/// </remarks>
	Task<bool> DeleteAsync(long videoId,
							long? ownerId = null,
							long? targetId = null,
							CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удаленную видеозапись.
	/// </summary>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца видеозаписи (пользователь или сообщество). Обратите
	/// внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.restore
	/// </remarks>
	Task<bool> RestoreAsync(long videoId,
							long? ownerId = null,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает список видеозаписей в соответствии с заданным критерием поиска.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов видеозаписей.
	/// Если в Вашем приложении используется  прямая авторизация, возвращается
	/// дополнительное поле files, содержащее ссылку
	/// на файл с видео (если ролик размещен на сервере ВКонтакте) или ссылку на
	/// внешний ресурс (если ролик встроен с
	/// какого-либо видеохостинга).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.search
	/// </remarks>
	Task<VkCollection<Video>> SearchAsync(VideoSearchParams @params,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает список альбомов видеозаписей пользователя или сообщества.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца альбомов (пользователь или сообщество). По умолчанию —
	/// идентификатор
	/// текущего пользователя. целое число, по умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию
	/// идентификатор текущего пользователя).
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выборки определенного подмножества альбомов. По
	/// умолчанию — 0.
	/// положительное число (Положительное число).
	/// </param>
	/// <param name="count">
	/// Количество альбомов, информацию о которых нужно вернуть. По умолчанию — не
	/// больше 50, максимум —
	/// 100). положительное число, по умолчанию 50, максимальное значение 100
	/// (Положительное число, по умолчанию 50,
	/// максимальное значение 100).
	/// </param>
	/// <param name="extended">
	/// 1 – позволяет получать поля count, photo_320, photo_160 и updated_time для
	/// каждого альбома. Если
	/// альбом пустой, то поля photo_320 и photo_160 возвращены не будут. По умолчанию
	/// – 0. флаг, может принимать значения
	/// 1 или 0 (Флаг, может принимать значения 1 или 0).
	/// </param>
	/// <param name="needSystem">
	/// 1 — возвращать системные альбомы. флаг, может принимать значения 1 или 0, по
	/// умолчанию 0
	/// (Флаг, может принимать значения 1 или 0, по умолчанию 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает общее количество альбомов с
	/// видеозаписями, и массив объектов album, каждый из
	/// которых содержит следующие поля:
	/// id — идентификатор альбома;
	/// owner_id — идентификатор владельца альбома;
	/// title — название альбома.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbums
	/// </remarks>
	Task<VkCollection<VideoAlbum>> GetAlbumsAsync(long? ownerId = null,
												long? offset = null,
												long? count = null,
												bool? extended = null,
												bool? needSystem = null,
												CancellationToken token = default);

	/// <summary>
	/// Создает пустой альбом видеозаписей.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества (если необходимо создать альбом в сообществе).
	/// положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="title"> Название альбома. строка (Строка). </param>
	/// <param name="privacy">
	/// Уровень доступа к альбому в специальном формате.
	/// Приватность доступна для альбомов с видео в профиле пользователя. список строк,
	/// разделенных через запятую (Список
	/// строк, разделенных через запятую).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает  идентификатор созданного альбома
	/// (album_id).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.addAlbum
	/// </remarks>
	Task<long> AddAlbumAsync(string title,
							long? groupId = null,
							IEnumerable<Privacy> privacy = null,
							CancellationToken token = default);

	/// <summary>
	/// Редактирует название альбома видеозаписей.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества (если нужно отредактировать альбом, принадлежащий
	/// сообществу).
	/// положительное число (Положительное число).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="title">
	/// Новое название для альбома. строка, обязательный параметр (Строка, обязательный
	/// параметр).
	/// </param>
	/// <param name="privacy">
	/// Уровень доступа к альбому в специальном формате.
	/// Приватность доступна для альбомов с видео в профиле пользователя. целое число
	/// (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.editAlbum
	/// </remarks>
	Task<bool> EditAlbumAsync(long albumId,
							string title,
							long? groupId = null,
							Privacy privacy = null,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет альбом видеозаписей.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества (если альбом, который необходимо удалить, принадлежит
	/// сообществу).
	/// положительное число (Положительное число).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома. положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.deleteAlbum
	/// </remarks>
	Task<bool> DeleteAlbumAsync(long albumId,
								long? groupId = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список комментариев к видеозаписи.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает общее количество комментариев и массив
	/// объектов comment, каждый из которых
	/// содержит следующие поля:
	/// id — идентификатор комментария;
	/// from_id — идентификатор автора комментария;
	/// date — дата добавления комментария в формате unixtime;
	/// text — текст комментария;
	/// likes — информация об отметках «Мне нравится» текущего комментария (если был
	/// задан параметр need_likes), объект с
	/// полями:
	/// count — число пользователей, которым понравился комментарий,
	/// user_likes — наличие отметки «Мне нравится» от текущего пользователя
	/// (1 — есть, 0 — нет),
	/// can_like — информация о том, может ли текущий пользователь поставить отметку
	/// «Мне нравится»
	/// (1 — может, 0 — не может).
	/// Если был передан параметр start_comment_id, будет также возвращено поле
	/// real_offset – итоговое смещение данного
	/// подмножества комментариев (оно может быть отрицательным, если был указан
	/// отрицательный offset).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getComments
	/// </remarks>
	Task<VkCollection<Comment>> GetCommentsAsync(VideoGetCommentsParams @params,
												CancellationToken token = default);

	/// <summary>
	/// Cоздает новый комментарий к видеозаписи.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданного комментария.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.createComment
	/// </remarks>
	Task<long> CreateCommentAsync(VideoCreateCommentParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Удаляет комментарий к видеозаписи.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// целое число, по
	/// умолчанию идентификатор текущего пользователя (Целое число, по умолчанию
	/// идентификатор текущего пользователя).
	/// </param>
	/// <param name="commentId">
	/// Идентификатор комментария. целое число, обязательный параметр (Целое число,
	/// обязательный
	/// параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.deleteComment
	/// </remarks>
	Task<bool> DeleteCommentAsync(long commentId,
								long? ownerId,
								CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удаленный комментарий к видеозаписи.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="commentId">
	/// Идентификатор удаленного комментария. целое число, обязательный параметр (Целое
	/// число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c> (0, если комментарий с
	/// таким идентификатором не является
	/// удаленным).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.restoreComment
	/// </remarks>
	Task<bool> RestoreCommentAsync(long commentId,
									long? ownerId,
									CancellationToken token = default);

	/// <summary>
	/// Изменяет текст комментария к видеозаписи.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="commentId">
	/// Идентификатор комментария. целое число, обязательный параметр (Целое число,
	/// обязательный
	/// параметр).
	/// </param>
	/// <param name="message">
	/// Новый текст комментария (является обязательным, если не задан параметр
	/// attachments). строка
	/// (Строка).
	/// </param>
	/// <param name="attachments">
	/// Новый список объектов, приложенных к комментарию и разделённых символом ",".
	/// Поле attachments представляется в
	/// формате:
	/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;
	/// media_id&gt;
	/// &lt;type&gt; — тип медиа-вложения:
	/// photo — фотография
	/// video — видеозапись
	/// audio — аудиозапись
	/// doc — документ
	/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения
	/// &lt;media_id&gt; — идентификатор медиа-вложения.
	/// Например:
	/// photo100172_166443618,photo66748_265827614
	/// Параметр является обязательным, если не задан параметр message. список строк,
	/// разделенных через запятую (Список
	/// строк, разделенных через запятую).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.editComment
	/// </remarks>
	Task<bool> EditCommentAsync(long commentId,
								string message,
								long? ownerId = null,
								IEnumerable<MediaAttachment> attachments = null,
								CancellationToken token = default);

	/// <summary>
	/// Позволяет пожаловаться на видеозапись.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
	/// целое число,
	/// обязательный параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="reason">
	/// Тип жалобы:
	/// 0 – это спам
	/// 1 – детская порнография
	/// 2 – экстремизм
	/// 3 – насилие
	/// 4 – пропаганда наркотиков
	/// 5 – материал для взрослых
	/// 6 – оскорбление положительное число (Положительное число).
	/// </param>
	/// <param name="comment"> Комментарий для жалобы. строка (Строка). </param>
	/// <param name="searchQuery">
	/// Поисковой запрос, если видеозапись была найдена
	/// через поиск. строка (Строка).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.report
	/// </remarks>
	Task<bool> ReportAsync(long videoId,
							ReportReason reason,
							long? ownerId,
							string comment = null,
							string searchQuery = null,
							CancellationToken token = default);

	/// <summary>
	/// Позволяет пожаловаться на комментарий к видеозаписи.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца видеозаписи, к которой оставлен комментарий. целое
	/// число, обязательный
	/// параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="commentId">
	/// Идентификатор комментария. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="reason">
	/// Тип жалобы:
	/// 0 – это спам
	/// 1 – детская порнография
	/// 2 – экстремизм
	/// 3 – насилие
	/// 4 – пропаганда наркотиков
	/// 5 – материал для взрослых
	/// 6 – оскорбление положительное число (Положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.reportComment
	/// </remarks>
	Task<bool> ReportCommentAsync(long commentId,
								long ownerId,
								ReportReason reason,
								CancellationToken token = default);

	/// <summary>
	/// Позволяет получить информацию об альбоме с видео.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит альбом. целое
	/// число, по умолчанию
	/// идентификатор текущего пользователя (Целое число, по умолчанию идентификатор
	/// текущего пользователя).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома. целое число, обязательный параметр (Целое число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект, который содержит следующие поля:
	/// id — идентификатор альбома;
	/// owner_id — идентификатор владельца альбома;
	/// title — название альбома;
	/// count — число видеозаписей в альбоме;
	/// photo_320 — url обложки альбома с шириной 320px;
	/// photo_160 — url обложки альбома с шириной 160px;
	/// updated_time — время последнего обновления в формате unixtime.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbumById
	/// </remarks>
	Task<VideoAlbum> GetAlbumByIdAsync(long albumId,
										long? ownerId = null,
										CancellationToken token = default);

	/// <summary>
	/// Позволяет изменить порядок альбомов с видео.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит альбом.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома, который нужно переместить. положительное число,
	/// обязательный параметр
	/// (Положительное число, обязательный параметр).
	/// </param>
	/// <param name="before">
	/// Идентификатор альбома, перед которым нужно поместить текущий. положительное
	/// число (Положительное
	/// число).
	/// </param>
	/// <param name="after">
	/// Идентификатор альбома, после которого нужно поместить текущий. положительное
	/// число (Положительное
	/// число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.reorderAlbums
	/// </remarks>
	Task<bool> ReorderAlbumsAsync(long albumId,
								long? ownerId,
								long? before,
								long? after,
								CancellationToken token = default);

	/// <summary>
	/// Позволяет переместить видеозапись в альбоме.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.reorderVideos
	/// </remarks>
	Task<bool> ReorderVideosAsync(VideoReorderVideosParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Позволяет добавить видеозапись в альбом.
	/// </summary>
	/// <param name="targetId">
	/// Идентификатор владельца альбома, в который нужно добавить видео.
	/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
	/// указывать со знаком "-" — например,
	/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число, по умолчанию идентификатор
	/// текущего пользователя (Целое число, по умолчанию идентификатор текущего
	/// пользователя).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома, в который нужно добавить видео (0 соответствует  общему
	/// списку
	/// видеозаписей «без альбома»). целое число (Целое число).
	/// </param>
	/// <param name="albumIds">
	/// Идентификаторы альбомов, в которые нужно добавить видео. список целых чисел,
	/// разделенных
	/// запятыми (Список целых чисел, разделенных запятыми).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца видеозаписи.
	/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо
	/// указывать со знаком "-" — например,
	/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число, обязательный параметр
	/// (Целое число, обязательный параметр).
	/// </param>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.addToAlbum
	/// </remarks>
	Task<VkCollection<ulong>> AddToAlbumAsync(long ownerId,
											long videoId,
											IEnumerable<string> albumIds,
											long? targetId = null,
											long? albumId = null,
											CancellationToken token = default);

	/// <summary>
	/// Позволяет убрать видеозапись из альбома.
	/// </summary>
	/// <param name="targetId">
	/// Идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в
	/// параметре
	/// target_id необходимо указывать со знаком "-" — например, target_id=-1
	/// соответствует идентификатору сообщества
	/// ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию
	/// идентификатор текущего пользователя).
	/// </param>
	/// <param name="albumId">
	/// Идентификатор альбома, из которого нужно убрать видео. целое число (Целое
	/// число).
	/// </param>
	/// <param name="albumIds">
	/// Идентификаторы альбомов, из которых нужно убрать видео. список целых чисел,
	/// разделенных запятыми
	/// (Список целых чисел, разделенных запятыми).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца видеозаписи. Обратите внимание, идентификатор
	/// сообщества в параметре
	/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества
	/// ВКонтакте API (club1)  целое число, обязательный параметр (Целое число,
	/// обязательный параметр).
	/// </param>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.removeFromAlbum
	/// </remarks>
	Task<bool> RemoveFromAlbumAsync(long ownerId,
									long videoId,
									IEnumerable<string> albumIds,
									long? targetId = null,
									long? albumId = null,
									CancellationToken token = default);

	/// <summary>
	/// Возвращает список альбомов, в которых находится видеозапись.
	/// </summary>
	/// <param name="targetId">
	/// Идентификатор пользователя или сообщества, для которого нужно получить список
	/// альбомов, содержащих видеозапись.
	/// Обратите внимание, идентификатор сообщества в параметре target_id необходимо
	/// указывать со знаком "-" — например,
	/// target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число, по умолчанию идентификатор
	/// текущего пользователя (Целое число, по умолчанию идентификатор текущего
	/// пользователя).
	/// </param>
	/// <param name="ownerId">
	/// Идентификатор владельца видеозаписи.
	/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо
	/// указывать со знаком "-" — например,
	/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)
	/// целое число, обязательный параметр
	/// (Целое число, обязательный параметр).
	/// </param>
	/// <param name="videoId">
	/// Идентификатор видеозаписи. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="extended">
	/// 1 — возвращать расширенную информацию об альбомах. флаг, может принимать
	/// значения 1 или 0, по
	/// умолчанию 0 (Флаг, может принимать значения 1 или 0, по умолчанию 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает список идентификаторов альбомов, в которых видеозапись находится у
	/// пользователя или сообщества с
	/// идентификатором target_id. Если был передан параметр extended=1, возвращается
	/// список объектов альбомов с
	/// дополнительной информацией о каждом из них.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getAlbumsByVideo
	/// </remarks>
	Task<VkCollection<VideoAlbum>> GetAlbumsByVideoAsync(long? targetId,
														long ownerId,
														long videoId,
														bool? extended,
														CancellationToken token = default);

	/// <summary>
	/// Позволяет получить представление каталога видео.
	/// </summary>
	/// <param name="params">Параметры запроса.</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов — блоков видеокаталога.
	/// Каждый из объектов содержит массив
	/// объектов — элементов блока и дополнительную информацию для отображения блока.
	/// Данные для отображения блока видеокаталога
	/// name заголовок блока.
	/// строка id идентификатор блока. Возвращается строка для предопределенных блоков.
	/// Для других возвращается число.
	/// Предопределенные блоки:
	/// my — видеозаписи пользователя;
	/// feed — записи сообществ и друзей, содержащие видеозаписи, а также новые
	/// видеозаписи, добавленные ими;
	/// ugc — популярные видеозаписи;
	/// series — сериалы и телешоу.
	/// строка или число can_hide наличие возможности скрыть блок.
	/// флаг, может принимать значения 1 или 0 type тип блока. Может принимать
	/// значения:
	/// channel — видеозаписи сообщества;
	/// category — подборки видеозаписей.
	/// строка next параметр для получения следующей страницы результатов. Необходимо
	/// передать его значение в from в
	/// следующем вызове, чтобы получить содержимое каталога, следующее за полученным в
	/// текущем вызове.
	/// строка
	/// Элемент блока видеокаталога
	/// id идентификатор элемента.
	/// положительное число owner_id идентификатор владельца элемента.
	/// int (числовое значение) title заголовок.
	/// строка type тип элемента. Может принимать значения:
	/// video — видеоролик;
	/// album — альбом.
	/// строка
	/// type=video. Дополнительные поля для элемента-видеоролика
	/// duration длительность в секундах.
	/// положительное число description описание.
	/// строка date дата добавления.
	/// положительное число views число просмотров.
	/// положительное число comments число комментариев.
	/// положительное число photo_130 URL изображения-обложки видео с размером
	/// 130x98px.
	/// строка photo_320 URL изображения-обложки видео с размером 320x240px.
	/// строка photo_640 URL изображения-обложки видео с размером 640x480px (если
	/// размер есть).
	/// строка can_add наличие возможности добавить видео в свой список.
	/// флаг, может принимать значения 1 или 0 can_edit наличие возможности
	/// редактировать видео.
	/// флаг, может принимать значения 1 или 0
	/// type=album. Дополнительные поля для элемента-альбома
	/// count число видеозаписей в альбоме.
	/// положительное число photo_320 URL изображения-обложки альбома с размером
	/// 544x300px.
	/// строка photo_160 URL изображения-обложки альбома с размером 272x150px.
	/// строка updated_time время последнего обновления альбома.
	/// положительное число
	/// Если был передан параметр extended=1, возвращаются дополнительные объекты
	/// profiles и groups, содержащие информацию
	/// о пользователях и сообществах.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getCatalog
	/// </remarks>
	Task<ReadOnlyCollection<VideoCatalog>> GetCatalogAsync(VideoGetCatalogParams @params,
															CancellationToken token = default);

	/// <summary>
	/// Позволяет получить отдельный блок видеокаталога.
	/// </summary>
	/// <param name="sectionId">
	/// Значение id, полученное с блоком в методе video.getCatalog. строка,
	/// обязательный параметр
	/// (Строка, обязательный параметр).
	/// </param>
	/// <param name="from">
	/// Значение next, полученное с блоком в методе video.getCatalog строка,
	/// обязательный параметр (Строка,
	/// обязательный параметр).
	/// </param>
	/// <param name="count">
	/// Число элементов блока, которое нужно вернуть. положительное число, по умолчанию
	/// 10, максимальное
	/// значение 16 (Положительное число, по умолчанию 10, максимальное значение 16).
	/// </param>
	/// <param name="extended">
	/// 1 — возвращать дополнительную информацию о пользователях и сообществах в полях
	/// profiles и
	/// groups. флаг, может принимать значения 1 или 0, по умолчанию 0 (Флаг, может
	/// принимать значения 1 или 0, по
	/// умолчанию 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив элементов блока видеокаталога и
	/// поле next для текущего блока.
	/// Элемент блока видеокаталога
	/// id идентификатор элемента.
	/// положительное число owner_id идентификатор владельца элемента.
	/// int (числовое значение) title заголовок.
	/// строка type тип элемента. Может принимать значения:
	/// video — видеоролик;
	/// album — альбом.
	/// строка
	/// type=video. Дополнительные поля для элемента-видеоролика
	/// duration длительность в секундах.
	/// положительное число description описание.
	/// строка date дата добавления.
	/// положительное число views число просмотров.
	/// положительное число comments число комментариев.
	/// положительное число photo_130 URL изображения-обложки видео с размером
	/// 130x98px.
	/// строка photo_320 URL изображения-обложки видео с размером 320x240px.
	/// строка photo_640 URL изображения-обложки видео с размером 640x480px (если
	/// размер есть).
	/// строка can_add наличие возможности добавить видео в свой список.
	/// флаг, может принимать значения 1 или 0 can_edit наличие возможности
	/// редактировать видео.
	/// флаг, может принимать значения 1 или 0
	/// type=album. Дополнительные поля для элемента-альбома
	/// count число видеозаписей в альбоме.
	/// положительное число photo_320 URL изображения-обложки альбома с размером
	/// 544x300px.
	/// строка photo_160 URL изображения-обложки альбома с размером 272x150px.
	/// строка updated_time время последнего обновления альбома.
	/// положительное число
	/// Если был передан параметр extended=1, возвращаются дополнительные объекты
	/// profiles и groups, содержащие информацию
	/// о пользователях и сообществах.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.getCatalogSection
	/// </remarks>
	Task<ReadOnlyCollection<VideoCatalogItem>> GetCatalogSectionAsync(string sectionId,
																	string from,
																	long? count = null,
																	bool? extended = null,
																	CancellationToken token = default);

	/// <summary>
	/// Скрывает для пользователя раздел видеокаталога.
	/// </summary>
	/// <param name="sectionId">
	/// Значение id, полученное с блоком, который необходимо скрыть, в методе
	/// video.getCatalog
	/// обязательный параметр, целое число (Обязательный параметр, целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/video.hideCatalogSection
	/// </remarks>
	Task<bool> HideCatalogSectionAsync(long sectionId,
										CancellationToken token = default);
}