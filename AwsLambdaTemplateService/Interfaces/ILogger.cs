// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Foundation Medicine Inc." file="ILogger.cs">
// //
// // Copyright Notice!
// // This document is protected under the trade secret and copyright
// // laws as the property of Foundation Medicine, Inc.
// // Copying, reproduction or distribution should be limited and only to
// // personnel with a “need to know” to do their job.
// // Any disclosure of this document to third parties is strictly prohibited.
// //
// // © 2019 Foundation Medicine Inc.
// // All rights reserved worldwide.
// // </copyright>
// // <summary>
// //
// // </summary>
// //
// // --------------------------------------------------------------------------------------------------------------------

using System;

namespace $safeprojectname$.Interfaces
{
    public interface ILogger
    {
        string LogException(Exception ex);
    }
}