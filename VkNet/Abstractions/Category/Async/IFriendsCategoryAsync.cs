﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с друзьями.
/// </summary>
public interface IFriendsCategoryAsync
{
	/// <summary>
	/// Возвращает список идентификаторов друзей пользователя или расширенную
	/// информацию о друзьях пользователя (при
	/// использовании параметра fields).
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список идентификаторов (id) друзей
	/// пользователя, если параметр fields не
	/// использовался.
	/// При использовании параметра fields  возвращает список объектов пользователей,
	/// но не более 5000.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.get
	/// </remarks>
	Task<VkCollection<User>> GetAsync(FriendsGetParams @params,
									bool skipAuthorization = false,
									CancellationToken token = default);

	/// <summary>
	/// Возвращает список идентификаторов друзей текущего пользователя, которые
	/// установили данное приложение.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список идентификаторов (id) друзей
	/// текущего пользователя, установивших
	/// приложение.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getAppUsers
	/// </remarks>
	Task<ReadOnlyCollection<long>> GetAppUsersAsync(CancellationToken token = default);

	/// <summary>
	/// Возвращает список идентификаторов друзей пользователя, находящихся на сайте.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список идентификаторов (id) друзей,
	/// находящихся сейчас на сайте, у
	/// пользователя с идентификатором uid и входящих в список с идентификатором lid.
	/// При использовании параметра online_mobile=1 также возвращается поле
	/// online_mobile, содержащее список идентификатор
	/// друзей, находящихся на сайте с мобильного устройства.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getOnline
	/// </remarks>
	Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params,
									CancellationToken token = default);

	/// <summary>
	/// Возвращает список идентификаторов общих друзей между парой пользователей.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список идентификаторов (id) общих друзей
	/// между пользователями с
	/// идентификаторами source_uid и target_uid.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getMutual
	/// </remarks>
	Task<ReadOnlyCollection<MutualFriend>> GetMutualAsync(FriendsGetMutualParams @params,
														CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию о том, добавлен ли текущий пользователь в друзья у
	/// указанных пользователей.
	/// </summary>
	/// <param name="userIds">
	/// Идентификаторы пользователей, статус дружбы с которыми нужно проверить. список
	/// целых чисел,
	/// разделенных запятыми, обязательный параметр (Список целых чисел, разделенных
	/// запятыми, обязательный параметр).
	/// </param>
	/// <param name="needSign">
	/// 1 – необходимо вернуть поле sign которое равно:
	/// md5Async("{id}_{user_id}_{friends_status}_{application_secret}"), где id - это
	/// идентификатор пользователя, для
	/// которого выполняется запрос.
	/// и позволяет на сервере убедиться что данные не были подделаны на клиенте.
	/// 0 – поле sign возвращать не нужно. флаг, может принимать значения 1 или 0
	/// (Флаг, может принимать значения 1 или 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов status, каждый из которых
	/// содержит следующие поля:
	/// user_id — идентификатор пользователя (из числа переданных в параметре
	/// user_ids);
	/// friend_status — статус дружбы с пользователем:
	/// 0 – пользователь не является другом,
	/// 1 – отправлена заявка/подписка пользователю,
	/// 2 – имеется входящая заявка/подписка от пользователя,
	/// 3 – пользователь является другом;
	/// request_message — текст сообщения, прикрепленного к заявке в друзья (если
	/// есть).
	/// read_state — статус заявки (0 — не просмотрена, 1 — просмотрена), возвращается
	/// только если friend_status = 2;.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.areFriends
	/// </remarks>
	Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync([NotNull] IEnumerable<long> userIds,
																bool? needSign = null,
																CancellationToken token = default);

	/// <summary>
	/// Создает новый список друзей у текущего пользователя.
	/// </summary>
	/// <param name="name">
	/// Название создаваемого списка друзей. строка, обязательный параметр (Строка,
	/// обязательный параметр).
	/// </param>
	/// <param name="userIds">
	/// Идентификаторы пользователей, которых необходимо поместить в созданный список.
	/// список
	/// положительных чисел, разделенных запятыми (Список положительных чисел,
	/// разделенных запятыми).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор (list_id) созданного списка
	/// друзей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.addList
	/// </remarks>
	Task<long> AddListAsync(string name,
							IEnumerable<long> userIds,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет существующий список друзей текущего пользователя.
	/// </summary>
	/// <param name="listId">
	/// Идентификатор списка друзей, который необходимо удалить. положительное число,
	/// обязательный
	/// параметр (Положительное число, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает 1.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.deleteList
	/// </remarks>
	Task<bool> DeleteListAsync(long listId,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список меток друзей текущего пользователя.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя. положительное число, по умолчанию идентификатор
	/// текущего пользователя
	/// (Положительное число, по умолчанию идентификатор текущего пользователя).
	/// </param>
	/// <param name="returnSystem">
	/// Возвращать ли системный список публичных меток друзей пользователя. флаг, может
	/// принимать
	/// значения 1 или 0 (Флаг, может принимать значения 1 или 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов, каждый из которых
	/// содержит следующие поля:
	/// name — название списка друзей;
	/// id — идентификатор списка друзей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getLists
	/// </remarks>
	Task<VkCollection<FriendList>> GetListsAsync(long? userId = null,
												bool? returnSystem = null,
												CancellationToken token = default);

	/// <summary>
	/// Редактирует существующий список друзей текущего пользователя.
	/// </summary>
	/// <param name="name"> Название списка друзей. строка (Строка). </param>
	/// <param name="listId">
	/// Идентификатор списка друзей. положительное число, обязательный параметр
	/// (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="userIds">
	/// Идентификаторы пользователей, включенных в список. список положительных чисел,
	/// разделенных
	/// запятыми (Список положительных чисел, разделенных запятыми).
	/// </param>
	/// <param name="addUserIds">
	/// Идентификаторы пользователей, которых необходимо добавить в список. (в случае
	/// если не передан
	/// user_ids) список положительных чисел, разделенных запятыми (Список
	/// положительных чисел, разделенных запятыми).
	/// </param>
	/// <param name="deleteUserIds">
	/// Идентификаторы пользователей, которых необходимо изъять из списка. (в случае
	/// если не
	/// передан user_ids) список положительных чисел, разделенных запятыми (Список
	/// положительных чисел, разделенных
	/// запятыми).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает 1.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.editList
	/// </remarks>
	Task<bool> EditListAsync(long listId,
							string name = null,
							IEnumerable<long> userIds = null,
							IEnumerable<long> addUserIds = null,
							IEnumerable<long> deleteUserIds = null,
							CancellationToken token = default);

	/// <summary>
	/// Отмечает все входящие заявки на добавление в друзья как просмотренные.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает 1.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.deleteAllRequests
	/// </remarks>
	Task<bool> DeleteAllRequestsAsync(CancellationToken token = default);

	/// <summary>
	/// Одобряет или создает заявку на добавление в друзья.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя, которому необходимо отправить заявку, либо заявку
	/// от которого
	/// необходимо одобрить. положительное число, обязательный параметр (Положительное
	/// число, обязательный параметр).
	/// </param>
	/// <param name="text">
	/// Текст сопроводительного сообщения для заявки на добавление в друзья.
	/// Максимальная длина сообщения —
	/// 500 символов. строка (Строка).
	/// </param>
	/// <param name="follow">
	/// Флаг, может принимать значения 1 или 0 (Флаг, может
	/// принимать значения 1 или 0).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает одно из следующих значений:
	/// 1 — заявка на добавление данного пользователя в друзья отправлена;
	/// 2 — заявка на добавление в друзья от данного пользователя одобрена;
	/// 4 — повторная отправка заявки.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.add
	/// </remarks>
	Task<AddFriendStatus> AddAsync(long userId,
									string text = "",
									bool? follow = null,
									CancellationToken token = default);


	/// <summary>
	/// Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя, которого необходимо удалить из списка друзей, либо
	/// заявку от которого
	/// необходимо отклонить. положительное число, обязательный параметр (Положительное
	/// число, обязательный параметр).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения начиная с версии 5.28 возвращается объект с полями:
	/// success — удалось успешно удалить друга
	/// friend_deleted — был удален друг
	/// out_request_deleted  — отменена исходящая заявка
	/// in_request_deleted  — отклонена входящая заявка
	/// suggestion_deleted  — отклонена рекомендация друга
	/// Для версии 5.27 и более старых возвращает одно из следующих значений:
	/// 1 — пользователь удален из списка друзей;
	/// 2 — заявка на добавление в друзья данного пользователя отклонена (входящая или
	/// исходящая);
	/// 3 — рекомендация добавить в друзья данного пользователя удалена.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.delete
	/// </remarks>
	Task<FriendsDeleteResult> DeleteAsync(long userId,
										CancellationToken token = default);

	/// <summary>
	/// Редактирует списки друзей для выбранного друга.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя (из числа друзей), для которого необходимо
	/// отредактировать списки
	/// друзей. положительное число, обязательный параметр (Положительное число,
	/// обязательный параметр).
	/// </param>
	/// <param name="listIds">
	/// Идентификаторы списков друзей, в которые нужно добавить пользователя. список
	/// положительных чисел,
	/// разделенных запятыми (Список положительных чисел, разделенных запятыми).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает 1.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.edit
	/// </remarks>
	Task<bool> EditAsync(long userId,
						IEnumerable<long> listIds,
						CancellationToken token = default);

	/// <summary>
	/// Возвращает список идентификаторов недавно добавленных друзей текущего
	/// пользователя.
	/// </summary>
	/// <param name="count">
	/// Максимальное количество недавно добавленных друзей, которое необходимо
	/// получить. положительное
	/// число, по умолчанию 100, максимальное значение 1000 (Положительное число, по
	/// умолчанию 100, максимальное значение
	/// 1000).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает отсортированный в антихронологическом
	/// порядке список идентификаторов (id)
	/// недавно добавленных друзей текущего пользователя.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getRecent
	/// </remarks>
	Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию о полученных или отправленных заявках на добавление в
	/// друзья для текущего пользователя.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Если не установлен параметр need_mutual, то в случае успеха возвращает
	/// отсортированный в антихронологическом
	/// порядке по времени подачи заявки список идентификаторов (id) пользователей
	/// (кому или от кого пришла заявка).
	/// Если установлен параметр need_mutual, то в случае успеха возвращает
	/// отсортированный в антихронологическом порядке
	/// по времени подачи заявки массив объектов, содержащих информацию о заявках на
	/// добавление в друзья.
	/// Каждый из объектов содержит поле uid, являющийся идентификатором пользователя.
	/// При наличии общих друзей, в объекте будет содержаться поле mutual, в котором
	/// будет находиться список
	/// идентификаторов общих друзей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getRequests
	/// </remarks>
	Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params,
											CancellationToken token = default);

	/// <summary>
	/// Возвращает информацию о полученных или отправленных заявках на добавление в
	/// друзья для текущего пользователя.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Если не установлен параметр need_mutual, то в случае успеха возвращает
	/// отсортированный в антихронологическом
	/// порядке по времени подачи заявки список идентификаторов (id) пользователей
	/// (кому или от кого пришла заявка).
	/// Если установлен параметр need_mutual, то в случае успеха возвращает
	/// отсортированный в антихронологическом порядке
	/// по времени подачи заявки массив объектов, содержащих информацию о заявках на
	/// добавление в друзья.
	/// Каждый из объектов содержит поле uid, являющийся идентификатором пользователя.
	/// При наличии общих друзей, в объекте будет содержаться поле mutual, в котором
	/// будет находиться список
	/// идентификаторов общих друзей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getRequests
	/// </remarks>
	Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(FriendsGetRequestsParams @params,
																		CancellationToken token = default);

	/// <summary>
	/// Возвращает список профилей пользователей, которые могут быть друзьями текущего
	/// пользователя.
	/// </summary>
	/// <param name="filter">
	/// Типы предлагаемых друзей, которые нужно вернуть,
	/// перечисленные через запятую.
	/// </param>
	/// <param name="count">
	/// Количество рекомендаций, которое необходимо вернуть. положительное число,
	/// максимальное значение
	/// 500, по умолчанию 500 (положительное число, максимальное значение 500, по
	/// умолчанию 500).
	/// </param>
	/// <param name="offset">
	/// Смещение, необходимое для выбора определённого подмножества списка.
	/// положительное число
	/// (положительное число).
	/// </param>
	/// <param name="fields">
	/// Список дополнительных полей, которые необходимо вернуть. Доступные значения:
	/// nickname,
	/// screen_name, sex, bdate, city, country, timezone, photo_50, photo_100,
	/// photo_200_orig, has_mobile, contacts,
	/// education, online, counters, relation, last_seen, status,
	/// can_write_private_message, can_see_all_posts, can_post,
	/// universities список строк, разделенных через запятую(список строк, разделенных
	/// через запятую).
	/// </param>
	/// <param name="nameCase">
	/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
	/// именительный – nom,
	/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
	/// предложный – abl. По умолчанию nom.
	/// строка (строка).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов пользователей с
	/// дополнительным полем found_with для
	/// пользователей, найденных через импорт контактов. Для некоторых пользователей,
	/// которые были найдены давно поле
	/// found_with может отсутствовать.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getSuggestions
	/// </remarks>
	Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter? filter = null,
												long? count = null,
												long? offset = null,
												UsersFields fields = null,
												NameCase? nameCase = null,
												CancellationToken token = default);

	/// <summary>
	/// Возвращает список друзей пользователя, у которых завалидированные или указанные
	/// в профиле телефонные номера входят
	/// в заданный список.
	/// </summary>
	/// <param name="phones">
	/// Список телефонных номеров в формате MSISDN, разделеннных запятыми. Например
	/// +79219876543,+79111234567
	/// Максимальное количество номеров в списке — 1000. список строк, разделенных
	/// через запятую (Список строк, разделенных
	/// через запятую).
	/// </param>
	/// <param name="fields">
	/// Список дополнительных полей, которые необходимо вернуть.
	/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone,
	/// photo_50, photo_100,
	/// photo_200_orig, has_mobile, contacts, education, online, counters, relation,
	/// last_seen, status,
	/// can_write_private_message, can_see_all_posts, can_post, universities список
	/// строк, разделенных через запятую
	/// (Список строк, разделенных через запятую).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает список объектов пользователей с
	/// дополнительным полем phone, в котором
	/// содержится номер из списка заданных для поиска номеров.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.getByPhones
	/// </remarks>
	Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones,
													ProfileFields fields,
													CancellationToken token = default);

	/// <summary>
	/// Позволяет искать по списку друзей пользователей.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения метод  возвращает список объектов пользователей.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/friends.search
	/// </remarks>
	Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params,
										CancellationToken token = default);
}