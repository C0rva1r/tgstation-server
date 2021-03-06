﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tgstation.Server.Host.Components.StaticFiles;
using Tgstation.Server.Host.Components.Watchdog;

namespace Tgstation.Server.Host.Components
{
	/// <inheritdoc />
	sealed class EventConsumer : IEventConsumer
	{
		/// <summary>
		/// The <see cref="IConfiguration"/> for the <see cref="EventConsumer"/>
		/// </summary>
		readonly IConfiguration configuration;

		/// <summary>
		/// The <see cref="IWatchdog"/> for the 
		/// </summary>
		IWatchdog watchdog;

		/// <summary>
		/// Construct an <see cref="IEventConsumer"/>
		/// </summary>
		/// <param name="configuration">The value of <see cref="configuration"/></param>
		public EventConsumer(IConfiguration configuration)
		{
			this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		/// <inheritdoc />
		public async Task<bool> HandleEvent(EventType eventType, IEnumerable<string> parameters, CancellationToken cancellationToken)
		{
			if (watchdog == null)
				throw new InvalidOperationException("EventConsumer used without watchdog set!");

			if (!await configuration.HandleEvent(eventType, parameters, cancellationToken).ConfigureAwait(false))
				return false;
			return await watchdog.HandleEvent(eventType, parameters, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Set the <paramref name="watchdog"/> for the <see cref="EventConsumer"/>
		/// </summary>
		/// <param name="watchdog">The value of <see cref="watchdog"/></param>
		public void SetWatchdog(IWatchdog watchdog)
		{
			if (watchdog == null)
				throw new ArgumentNullException(nameof(watchdog));
			if (this.watchdog != null)
				throw new InvalidOperationException("watchdog already set!");
			this.watchdog = watchdog;
		}
	}
}
