using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с фотографиями.
/// </summary>
public interface IPhotoCategoryAsync
{
	/// <summary>
	/// Создает пустой альбом для фотографий.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект PhotoAlbum
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.createAlbum
	/// </remarks>
	Task<PhotoAlbum> CreateAlbumAsync(PhotoCreateAlbumParams @params,
									CancellationToken token = default);

	/// <summary>
	/// Редактирует данные альбома для фотографий пользователя.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.editAlbum
	/// </remarks>
	Task<bool> EditAlbumAsync(PhotoEditAlbumParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает список альбомов пользователя или сообщества.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает список объектов PhotoAlbum
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getAlbums
	/// </remarks>
	Task<VkCollection<PhotoAlbum>> GetAlbumsAsync(PhotoGetAlbumsParams @params,
												bool skipAuthorization = false,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает список фотографий в альбоме.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Photo
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.get
	/// </remarks>
	Task<VkCollection<Photo>> GetAsync(PhotoGetParams @params,
										bool skipAuthorization = false,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает количество доступных альбомов пользователя или сообщества.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя, количество альбомов которого необходимо получить.
	/// целое число, по
	/// умолчанию идентификатор текущего пользователя (Целое число, по умолчанию
	/// идентификатор текущего пользователя).
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, количество альбомов которого необходимо получить.
	/// целое число (Целое
	/// число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает количество альбомов с учетом настроек
	/// приватности.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getAlbumsCount
	/// </remarks>
	Task<int> GetAlbumsCountAsync(long? userId = null,
								long? groupId = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию о фотографиях по их идентификаторам.
	/// </summary>
	/// <param name="photos">
	/// Перечисленные через запятую идентификаторы, которые представляют собой идущие
	/// через знак подчеркивания id
	/// пользователей, разместивших фотографии, и id самих фотографий. Чтобы получить
	/// информацию о фотографии в альбоме
	/// группы, вместо id пользователя следует указать -id группы.
	/// Пример значения photos: 1_129207899,6492_135055734,
	/// -20629724_271945303
	/// Некоторые фотографии, идентификаторы которых могут быть получены через API,
	/// закрыты приватностью, и не будут
	/// получены. В этом случае следует использовать ключ доступа фотографии
	/// (access_key) в её идентификаторе. Пример
	/// значения photos: 1_129207899_220df2876123d3542f,
	/// 6492_135055734_e0a9bcc31144f67fbd
	/// Поле access_key будет возвращено вместе с остальными данными фотографии в
	/// методах, которые возвращают фотографии,
	/// закрытые приватностью но доступные в данном контексте. Например данное поле
	/// имеют фотографии, возвращаемые методом
	/// newsfeed.get. список строк, разделенных через запятую, обязательный параметр
	/// (Список строк, разделенных через
	/// запятую, обязательный параметр).
	/// </param>
	/// <param name="extended">
	/// 1 — будут возвращены дополнительные поля likes, comments, tags, can_comment,
	/// can_repost. Поля
	/// comments и tags содержат только количество объектов. По умолчанию данные поля
	/// не возвращается. флаг, может
	/// принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).
	/// </param>
	/// <param name="photoSizes">
	/// Возвращать ли доступные размеры фотографии в специальном формате. флаг, может
	/// принимать
	/// значения 1 или 0 (Флаг, может принимать значения 1 или 0).
	/// </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов photo.
	/// Если к фотографии прикреплено местоположение, также возвращаются поля lat и
	/// long, содержащие географические
	/// координаты отметки.
	/// Если был задан параметр extended=1, возвращаются дополнительные поля:
	/// likes — количество отметок Мне нравится и информация о том, поставил ли лайк
	/// текущий пользователь;
	/// comments — количество комментариев к фотографии;
	/// tags — количество отметок на фотографии;
	/// can_comment — может ли текущий пользователь комментировать фото (1 — может, 0 —
	/// не может);
	/// can_repost — может ли текущий пользователь сделать репост фотографии (1 —
	/// может, 0 — не может).
	/// Если был задан параметр photo_sizes, вместо полей width и height возвращаются
	/// размеры копий фотографии в
	/// специальном формате.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getById
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> GetByIdAsync(IEnumerable<string> photos,
												bool? extended = null,
												bool? photoSizes = null,
												bool skipAuthorization = false,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки фотографий.
	/// </summary>
	/// <param name="albumId"> Идентификатор альбома. целое число (Целое число). </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, которому принадлежит альбом (если необходимо
	/// загрузить фотографию в
	/// альбом сообщества). целое число (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает объект UploadServerInfo </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetUploadServerAsync(long albumId,
												long? groupId = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки главной фотографии на страницу
	/// пользователя или сообщества.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор сообщества или текущего пользователя. Обратите внимание,
	/// идентификатор сообщества в
	/// параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1
	/// соответствует идентификатору
	/// сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор
	/// текущего пользователя (Целое число, по
	/// умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект с единственным полем upload_url.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// http://vk.com/dev/photos.getOwnerPhotoUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetOwnerPhotoUploadServerAsync(long? ownerId = null,
														CancellationToken token = default);

	/// <summary>
	/// Позволяет получить адрес для загрузки фотографий мультидиалогов.
	/// </summary>
	/// <param name="chatId">
	/// Идентификатор беседы, для которой нужно загрузить фотографию. положительное
	/// число, обязательный
	/// параметр (Положительное число, обязательный параметр).
	/// </param>
	/// <param name="cropX">
	/// Координата x для обрезки фотографии. положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="cropY">
	/// Координата y для обрезки фотографии. положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="cropWidth">
	/// Ширина фотографии после обрезки в px. положительное число, минимальное значение
	/// 200
	/// (Положительное число, минимальное значение 200).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект с единственным полем upload_url.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getChatUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetChatUploadServerAsync(ulong chatId,
													ulong? cropX = null,
													ulong? cropY = null,
													ulong? cropWidth = null,
													CancellationToken token = default);

	/// <summary>
	/// Позволяет сохранить главную фотографию пользователя или сообщества.
	/// </summary>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии
	/// на сервер.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект, содержащий поля photo_hash и
	/// photo_src (при работе через VK.api метод
	/// вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash
	/// необходим для подтверждения
	/// пользователем изменения его фотографии через вызов метода saveProfilePhoto
	/// Javascript API. Поле photo_src содержит
	/// путь к загруженной фотографии.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveOwnerPhoto
	/// </remarks>
	Task<Photo> SaveOwnerPhotoAsync(string response,
															CancellationToken token = default);


	/// <summary>
	/// Сохраняет фотографии после успешной загрузки на URI, полученный методом
	/// photos.getWallUploadServer.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя, на стену которого нужно
	/// сохранить фотографию
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, на стену которого нужно
	/// сохранить фотографию
	/// </param>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии
	/// на сервер
	/// </param>
	/// <param name="caption"> Описание загружаемой фотографии </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив, содержащий объект с загруженной
	/// фотографией.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveWallPhoto
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> SaveWallPhotoAsync(string response,
														ulong? userId,
														ulong? groupId = null,
														string caption = null,
														CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки фотографии на стену пользователя или
	/// сообщества.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества, на стену которого нужно загрузить фото (без знака
	/// «минус»). целое число
	/// (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект с полями upload_url, album_id,
	/// user_id.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getWallUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки фотографии в личное сообщение
	/// пользователю.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор назначения (для загрузки фотографии в
	/// сообщениях сообществ).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает объект UploadServerInfo </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// http://vk.com/dev/photos.getMessagesUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetMessagesUploadServerAsync(long? groupId,
														CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографию после успешной загрузки на URI, полученный методом
	/// GetMessagesUploadServer
	/// </summary>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии
	/// на сервер
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив с загруженной фотографией,
	/// возвращённый объект имеет поля id,
	/// pid, aid, owner_id, src, src_big, src_small, created. В случае наличия
	/// фотографий в высоком разрешении также будут
	/// возвращены адреса с названиями src_xbig и src_xxbig.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveMessagesPhoto
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> SaveMessagesPhotoAsync(string response,
															CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки обложки сообщества.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества, для которого необходимо загрузить обложку.
	/// положительное число,
	/// обязательный параметр (Положительное число, обязательный параметр).
	/// </param>
	/// <param name="cropX">
	/// Координата X верхнего левого угла для обрезки изображения. Положительное число
	/// (Положительное
	/// число).
	/// </param>
	/// <param name="cropY">
	/// Координата Y верхнего левого угла для обрезки изображения. Положительное число
	/// (Положительное
	/// число).
	/// </param>
	/// <param name="cropX2">
	/// Координата X нижнего правого угла для обрезки изображения. Положительное число
	/// (Положительное
	/// число).
	/// </param>
	/// <param name="cropY2">
	/// Координата Y нижнего правого угла для обрезки изображения. Положительное число
	/// (Положительное
	/// число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает объект UploadServerInfo </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// http://vk.com/dev/photos.getOwnerCoverPhotoUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetOwnerCoverPhotoUploadServerAsync(long groupId,
																long? cropX = null,
																long? cropY = null,
																long? cropX2 = 795L,
																long? cropY2 = 200L,
																CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографию после успешной загрузки на URI, полученный методом
	/// GetOwnerCoverPhotoUploadServer
	/// </summary>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии
	/// на сервер
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив, содержащий объект с загруженной
	/// фотографией.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveOwnerCoverPhoto
	/// </remarks>
	Task<GroupCover> SaveOwnerCoverPhotoAsync(string response,
											CancellationToken token = default);

	/// <summary>
	/// Позволяет пожаловаться на фотографию.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// целое число,
	/// обязательный параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="reason">
	/// Причина жалобы:
	/// 0 — спам;
	/// 1 — детская порнография;
	/// 2 — экстремизм;
	/// 3 — насилие;
	/// 4 — пропаганда наркотиков;
	/// 5 — материал для взрослых;
	/// 6 — оскорбление.
	/// положительное число (Положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.report
	/// </remarks>
	Task<bool> ReportAsync(long ownerId,
							ulong photoId,
							ReportReason reason,
							CancellationToken token = default);

	/// <summary>
	/// Позволяет пожаловаться на комментарий к фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца фотографии к которой оставлен комментарий. целое число,
	/// обязательный
	/// параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="commentId">
	/// Идентификатор комментария. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="reason">
	/// Причина жалобы:
	/// 0 — спам;
	/// 1 — детская порнография;
	/// 2 — экстремизм;
	/// 3 — насилие;
	/// 4 — пропаганда наркотиков;
	/// 5 — материал для взрослых;
	/// 6 — оскорбление.
	/// положительное число (Положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.reportComment
	/// </remarks>
	Task<bool> ReportCommentAsync(long ownerId,
								ulong commentId,
								ReportReason reason,
								CancellationToken token = default);

	/// <summary>
	/// Осуществляет поиск изображений по местоположению или описанию.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов фотографий.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.search
	/// </remarks>
	Task<VkCollection<Photo>> SearchAsync(PhotoSearchParams @params,
										bool skipAuthorization = false,
										CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографии после успешной загрузки.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Photo
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.save
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> SaveAsync(PhotoSaveParams @params,
											CancellationToken token = default);

	/// <summary>
	/// Позволяет скопировать фотографию в альбом "Сохраненные фотографии".
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор владельца фотографии целое число, обязательный параметр (Целое
	/// число, обязательный
	/// параметр).
	/// </param>
	/// <param name="photoId">
	/// Индентификатор фотографии положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="accessKey">
	/// Специальный код доступа для приватных фотографий
	/// строка (Строка).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает идентификатор созданной фотографии.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.copy
	/// </remarks>
	Task<long> CopyAsync(long ownerId,
						ulong photoId,
						string accessKey = null,
						CancellationToken token = default);

	/// <summary>
	/// Изменяет описание у выбранной фотографии.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.edit
	/// </remarks>
	Task<bool> EditAsync(PhotoEditParams @params,
						CancellationToken token = default);

	/// <summary>
	/// Переносит фотографию из одного альбома в другой.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="targetAlbumId">
	/// Идентификатор альбома, в который нужно переместить фотографию. целое число,
	/// обязательный
	/// параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии, которую нужно перенести. целое число, обязательный
	/// параметр (Целое
	/// число, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.move
	/// </remarks>
	Task<bool> MoveAsync(long targetAlbumId,
						ulong photoId,
						long? ownerId = null,
						CancellationToken token = default);

	/// <summary>
	/// Делает фотографию обложкой альбома.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. Фотография должна находиться в альбоме album_id.
	/// целое число,
	/// обязательный параметр (Целое число, обязательный параметр).
	/// </param>
	/// <param name="albumId"> Идентификатор альбома. целое число (Целое число). </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.makeCover
	/// </remarks>
	Task<bool> MakeCoverAsync(ulong photoId,
							long? ownerId = null,
							long? albumId = null,
							CancellationToken token = default);

	/// <summary>
	/// Меняет порядок альбома в списке альбомов пользователя.
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
	/// Идентификатор альбома. целое число, обязательный параметр (Целое число,
	/// обязательный параметр).
	/// </param>
	/// <param name="before">
	/// Идентификатор альбома, перед которым следует поместить альбом. целое число
	/// (Целое число).
	/// </param>
	/// <param name="after">
	/// Идентификатор альбома, после которого следует поместить альбом. целое число
	/// (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.reorderAlbums
	/// </remarks>
	Task<bool> ReorderAlbumsAsync(long albumId,
								long? ownerId = null,
								long? before = null,
								long? after = null,
								CancellationToken token = default);

	/// <summary>
	/// Меняет порядок фотографии в списке фотографий альбома пользователя.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. целое число, обязательный параметр (Целое число,
	/// обязательный
	/// параметр).
	/// </param>
	/// <param name="before">
	/// Идентификатор фотографии, перед которой следует поместить фотографию. Если
	/// параметр не указан,
	/// фотография будет помещена последней. целое число (Целое число).
	/// </param>
	/// <param name="after">
	/// Идентификатор фотографии, после которой следует поместить фотографию. Если
	/// параметр не указан,
	/// фотография будет помещена первой. целое число (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.reorderPhotos
	/// </remarks>
	Task<bool> ReorderPhotosAsync(ulong photoId,
								long? ownerId = null,
								long? before = null,
								long? after = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает все фотографии пользователя или сообщества в антихронологическом
	/// порядке.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Photo
	/// <remarks>
	/// Если был задан параметр extended — будет возвращено поле likes:
	/// user_likes: 1 — текущему пользователю нравится данная фотография, 0 - не
	/// указано.
	/// count — количество пользователей, которым нравится текущая фотография.
	/// Если был задан параметр photo_sizes=1, вместо полей width и height возвращаются
	/// размеры копий фотографии в
	/// специальном формате.
	/// </remarks>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getAll
	/// </remarks>
	Task<VkCollection<Photo>> GetAllAsync(PhotoGetAllParams @params,
										CancellationToken token = default);

	/// <summary>
	/// Возвращает список фотографий, на которых отмечен пользователь.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов photo.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getUserPhotos
	/// </remarks>
	Task<VkCollection<Photo>> GetUserPhotosAsync(PhotoGetUserPhotosParams @params,
												CancellationToken token = default);

	/// <summary>
	/// Удаляет указанный альбом для фотографий у текущего пользователя.
	/// </summary>
	/// <param name="albumId">
	/// Идентификатор альбома. целое число, положительное число, обязательный параметр
	/// (Целое число,
	/// положительное число, обязательный параметр).
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, в котором размещен альбом. целое число, положительное
	/// число (Целое
	/// число, положительное число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.deleteAlbum
	/// </remarks>
	Task<bool> DeleteAlbumAsync(long albumId,
								long? groupId = null,
								CancellationToken token = default);

	/// <summary>
	/// Удаление фотографии на сайте.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.delete
	/// </remarks>
	Task<bool> DeleteAsync(ulong photoId,
							long? ownerId = null,
							CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удаленную фотографию.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.restore
	/// </remarks>
	Task<bool> RestoreAsync(ulong photoId,
							long? ownerId = null,
							CancellationToken token = default);

	/// <summary>
	/// Подтверждает отметку на фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. обязательный параметр
	/// (Обязательный параметр).
	/// </param>
	/// <param name="tagId">
	/// Идентификатор отметки на фотографии. целое число, обязательный параметр (Целое
	/// число, обязательный
	/// параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.confirmTag
	/// </remarks>
	Task<bool> ConfirmTagAsync(ulong photoId,
								ulong tagId,
								long? ownerId = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список комментариев к фотографии.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Comment
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getComments
	/// </remarks>
	Task<VkCollection<Comment>> GetCommentsAsync(PhotoGetCommentsParams @params,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает отсортированный в антихронологическом порядке список всех
	/// комментариев к конкретному альбому или ко всем
	/// альбомам пользователя.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Comment
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getAllComments
	/// </remarks>
	Task<VkCollection<Comment>> GetAllCommentsAsync(PhotoGetAllCommentsParams @params,
													CancellationToken token = default);

	/// <summary>
	/// Создает новый комментарий к фотографии.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданного комментария.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.createComment
	/// </remarks>
	Task<long> CreateCommentAsync(PhotoCreateCommentParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Удаляет комментарий к фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
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
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c> (0, если комментарий не
	/// найден).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.deleteComment
	/// </remarks>
	Task<bool> DeleteCommentAsync(ulong commentId,
								long? ownerId = null,
								CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удаленный комментарий к фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
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
	/// Страница документации ВКонтакте http://vk.com/dev/photos.restoreComment
	/// </remarks>
	Task<long> RestoreCommentAsync(ulong commentId,
									long? ownerId = null,
									CancellationToken token = default);

	/// <summary>
	/// Изменяет текст комментария к фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)
	/// </param>
	/// <param name="commentId"> Идентификатор комментария </param>
	/// <param name="message">
	/// Новый текст комментария (является обязательным, если не задан параметр
	/// attachments)
	/// </param>
	/// <param name="attachments">
	/// Новый список объектов, приложенных к комментарию и разделённых символом ",".
	/// Поле attachments представляется в
	/// формате: &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id
	/// &gt;_&lt;media_id&gt; &lt;type&gt; —
	/// тип медиа-вложения:
	/// photo — фотография
	/// video — видеозапись
	/// audio — аудиозапись
	/// doc — документ
	/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения
	/// &lt;media_id&gt; — идентификатор медиа-вложения.
	/// <example>
	/// Например:
	/// photo100172_166443618,photo66748_265827614
	/// </example>
	/// Параметр является обязательным, если не задан параметр message. список строк,
	/// разделенных через запятую
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns> После успешного выполнения возвращает true. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.editComment
	/// </remarks>
	Task<bool> EditCommentAsync(ulong commentId,
								string message,
								long? ownerId = null,
								IEnumerable<MediaAttachment> attachments = null,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список отметок на фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. целое число, обязательный параметр (Целое число,
	/// обязательный
	/// параметр).
	/// </param>
	/// <param name="accessKey">
	/// Строковой ключ доступа, который може быть получен при получении объекта
	/// фотографии. строка
	/// (Строка).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов tag, каждый из которых
	/// содержит следующие поля:
	/// user_id — идентификатор пользователя, которому соответствует отметка;
	/// id — идентификатор отметки;
	/// placer_id — идентификатор пользователя, сделавшего отметку;
	/// tagged_name — название отметки;
	/// date — дата добавления отметки в формате unixtime;
	/// x, y, x2, y2 — координаты прямоугольной области, на которой сделана отметка
	/// (верхний левый угол и нижний правый
	/// угол) в процентах;
	/// viewed — статус отметки (1 — подтвержденная, 0 — неподтвержденная).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getTags
	/// </remarks>
	Task<ReadOnlyCollection<Tag>> GetTagsAsync(ulong photoId,
												long? ownerId = null,
												string accessKey = null,
												CancellationToken token = default);

	/// <summary>
	/// Добавляет отметку на фотографию.
	/// </summary>
	/// <param name="params"> Параметры запроса. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданной отметки (tag id).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.putTag
	/// </remarks>
	Task<ulong> PutTagAsync(PhotoPutTagParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет отметку с фотографии.
	/// </summary>
	/// <param name="ownerId">
	/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
	/// Обратите внимание,
	/// идентификатор сообщества в параметре owner_id необходимо указывать со знаком
	/// "-" — например, owner_id=-1
	/// соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по
	/// умолчанию идентификатор текущего
	/// пользователя (Целое число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="photoId">
	/// Идентификатор фотографии. целое число, обязательный параметр (Целое число,
	/// обязательный
	/// параметр).
	/// </param>
	/// <param name="tagId">
	/// Идентификатор отметки. целое число, обязательный параметр (Целое число,
	/// обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает <c> true </c>.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.removeTag
	/// </remarks>
	Task<bool> RemoveTagAsync(ulong tagId,
							ulong photoId,
							long? ownerId = null,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает список фотографий, на которых есть непросмотренные отметки.
	/// </summary>
	/// <param name="offset">
	/// Смещение, необходимое для получения определённого подмножества фотографий.
	/// целое число (Целое
	/// число).
	/// </param>
	/// <param name="count">
	/// Количество фотографий, которые необходимо вернуть. положительное число,
	/// максимальное значение 100,
	/// по умолчанию 20 (Положительное число, максимальное значение 100, по умолчанию
	/// 20).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов Photo
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getNewTags
	/// </remarks>
	Task<VkCollection<Photo>> GetNewTagsAsync(uint? offset = null,
											uint? count = null,
											CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки фотографии товаров сообщества.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества, для которого необходимо загрузить фотографию товара.
	/// положительное
	/// число, обязательный параметр (Положительное число, обязательный параметр).
	/// </param>
	/// <param name="mainPhoto">
	/// Является ли фотография обложкой товара  (1 — фотография для обложки, 0 —
	/// дополнительная
	/// фотография) флаг, может принимать значения 1 или 0 (Флаг, может принимать
	/// значения 1 или 0).
	/// </param>
	/// <param name="cropX">
	/// Координата x для обрезки фотографии. положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="cropY">
	/// Координата y для обрезки фотографии. положительное число
	/// (Положительное число).
	/// </param>
	/// <param name="cropWidth">
	/// Ширина фотографии после обрезки в px. положительное число, минимальное значение
	/// 200
	/// (Положительное число, минимальное значение 200).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает объект с единственным полем upload_url.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.getMarketUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetMarketUploadServerAsync(long groupId,
													bool? mainPhoto = null,
													long? cropX = null,
													long? cropY = null,
													long? cropWidth = null,
													CancellationToken token = default);

	/// <summary>
	/// Возвращает адрес сервера для загрузки фотографии подборки товаров в сообществе.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор сообщества, для которого необходимо загрузить фотографию подборки
	/// товаров. целое
	/// число (Целое число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// .
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// http://vk.com/dev/photos.getMarketAlbumUploadServer
	/// </remarks>
	Task<UploadServerInfo> GetMarketAlbumUploadServerAsync(long groupId,
															CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографии после успешной загрузки на URI, полученный методом
	/// photos.getMarketUploadServer.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор группы, для которой нужно загрузить фотографию. положительное
	/// число (положительное
	/// число).
	/// </param>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии на сервер. строка,
	/// обязательный параметр
	/// (строка, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив, содержащий объект с загруженной
	/// фотографией.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveMarketPhoto
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> SaveMarketPhotoAsync(long groupId,
														string response,
														CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографии после успешной загрузки на URI, полученный методом
	/// photos.getMarketAlbumUploadServer.
	/// </summary>
	/// <param name="groupId">
	/// Идентификатор группы, для которой нужно загрузить фотографию. положительное
	/// число, обязательный
	/// параметр (положительное число, обязательный параметр).
	/// </param>
	/// <param name="response">
	/// Параметр, возвращаемый в результате загрузки фотографии на сервер. строка,
	/// обязательный параметр
	/// (строка, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив, содержащий объект с загруженной
	/// фотографией.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/photos.saveMarketAlbumPhoto
	/// </remarks>
	Task<ReadOnlyCollection<Photo>> SaveMarketAlbumPhotoAsync(long groupId,
															string response,
															CancellationToken token = default);
}