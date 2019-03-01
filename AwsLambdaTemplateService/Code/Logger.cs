// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Foundation Medicine Inc." file="Logger.cs">
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
using $safeprojectname$.Helpers;
using $safeprojectname$.Interfaces;

namespace $safeprojectname$.Code
{
    public class Logger: ILogger
    {
        public string LogException(Exception ex)
        {
            var errorId = Guid.NewGuid();
            var body = ex is FmiException exception ? $"Body : {exception.Body} \r\n" : string.Empty;
            var date = $"{DateTime.Now: yyyy MMMM dd HH:mm:ss.fff tt zz}";
            Console.WriteLine($"Message: {ex.Message} \r\n Date: {date} \r\n Error ID: {errorId} \r\n {body} StackTrace: {ex.StackTrace}");

            var message = ex is FmiException ? ex.Message : Const.Messages.InternalError;
            return $"Message: {message};  Date: {date};  Error ID: {errorId}";
        }
    }
}