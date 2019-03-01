// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Foundation Medicine Inc." file="App.cs">
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
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Service.Interfaces;

namespace $safeprojectname$.Code
{
    public class App : IRun
    {
        private readonly ILogger _logger;

        public App(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> Run(string input, ILambdaContext context)
        {
            try
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return string.Empty;
            }
        }
    }
}