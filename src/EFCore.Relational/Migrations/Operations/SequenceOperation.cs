// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;

namespace Microsoft.EntityFrameworkCore.Migrations.Operations
{
    /// <summary>
    ///     A <see cref="MigrationOperation" /> for operations on sequences.
    ///     See also <see cref="CreateSequenceOperation" /> and <see cref="AlterSequenceOperation" />.
    /// </summary>
    public class SequenceOperation : MigrationOperation
    {
        /// <summary>
        ///     The amount to increment by when generating the next value in the sequence, defaulting to 1.
        /// </summary>
        public virtual int IncrementBy { get; set; } = 1;

        /// <summary>
        ///     The maximum value of the sequence, or <c>null</c> if not specified.
        /// </summary>
        public virtual long? MaxValue { get; [param: CanBeNull] set; }

        /// <summary>
        ///     The minimum value of the sequence, or <c>null</c> if not specified.
        /// </summary>
        public virtual long? MinValue { get; [param: CanBeNull] set; }

        /// <summary>
        ///     Indicates whether or not the sequence will re-start when the maximum value is reached.
        /// </summary>
        public virtual bool IsCyclic { get; set; }
    }
}
