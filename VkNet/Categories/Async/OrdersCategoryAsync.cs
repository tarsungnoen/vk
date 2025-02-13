using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class OrdersCategory
{
	/// <inheritdoc/>
	public Task<bool> CancelSubscriptionAsync(ulong userId,
											ulong subscriptionId,
											bool? pendingCancel = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CancelSubscription(userId, subscriptionId, pendingCancel), token);

	/// <inheritdoc/>
	public Task<OrderState> ChangeStateAsync(ulong orderId,
											OrderStateAction action,
											ulong? appOrderId = null,
											bool? testMode = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ChangeState(orderId, action, appOrderId, testMode), token);

	/// <inheritdoc/>
	public Task<IEnumerable<Order>> GetAsync(ulong? offset = null,
											ulong? count = null,
											bool? testMode = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(offset, count, testMode), token);

	/// <inheritdoc/>
	public Task<IEnumerable<VotesAmount>> GetAmountAsync(ulong userId,
														IEnumerable<string> votes,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAmount(userId, votes), token);

	/// <inheritdoc/>
	public Task<IEnumerable<Order>> GetByIdAsync(IEnumerable<ulong> orderIds = null,
												bool? testMode = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(orderIds, testMode), token);

	/// <inheritdoc/>
	public Task<SubscriptionItem> GetUserSubscriptionByIdAsync(ulong userId,
																ulong subscriptionId,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUserSubscriptionById(userId, subscriptionId), token);

	/// <inheritdoc/>
	public Task<IEnumerable<SubscriptionItem>> GetUserSubscriptionsAsync(ulong userId,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUserSubscriptions(userId), token);

	/// <inheritdoc/>
	public Task<bool> UpdateSubscriptionAsync(ulong userId,
											ulong subscriptionId,
											ulong price,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateSubscription(userId, subscriptionId, price), token);
}