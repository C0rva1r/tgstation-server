﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tgstation.Server.Api.Models;

namespace Tgstation.Server.Client.Components
{
	/// <summary>
	/// For managing the compiler
	/// </summary>
	public interface IDreamMakerClient
	{
		/// <summary>
		/// Get the <see cref="DreamMaker"/> information
		/// </summary>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="DreamMaker"/> information</returns>
		Task<DreamMaker> Read(CancellationToken cancellationToken);

		/// <summary>
		/// Updates the <see cref="DreamMaker"/> setttings
		/// </summary>
		/// <param name="dreamMaker">The <see cref="DreamMaker"/> to update</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task<DreamMaker> Update(DreamMaker dreamMaker, CancellationToken cancellationToken);

		/// <summary>
		/// Compile the current repository revision
		/// </summary>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="Job"/> for the compile</returns>
		Task<Job> Compile(CancellationToken cancellationToken);

		/// <summary>
		/// Gets the <see cref="Api.Models.Internal.CompileJob.Id"/>s of all <see cref="CompileJob"/>s for the instance
		/// </summary>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in a <see cref="IReadOnlyList{T}"/> of <see cref="CompileJob"/>s with only the <see cref="Api.Models.Internal.CompileJob.Id"/> field populated</returns>
		Task<IReadOnlyList<CompileJob>> GetJobIds(CancellationToken cancellationToken);

		/// <summary>
		/// Get a <paramref name="compileJob"/>
		/// </summary>
		/// <param name="compileJob">The <see cref="CompileJob"/> to get</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="CompileJob"/></returns>
		Task<CompileJob> GetCompileJob(CompileJob compileJob, CancellationToken cancellationToken);
	}
}
