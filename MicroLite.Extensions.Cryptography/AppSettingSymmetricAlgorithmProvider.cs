﻿// -----------------------------------------------------------------------
// <copyright file="AppSettingSymmetricAlgorithmProvider.cs" company="Project Contributors">
// Copyright Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
using System.Configuration;
using System.Text;
using MicroLite.Extensions.Cryptography;

namespace MicroLite.Infrastructure
{
    /// <summary>
    /// An implementation of <see cref="ISymmetricAlgorithmProvider"/> which reads the values to use from the app.config.
    /// </summary>
    public sealed class AppSettingSymmetricAlgorithmProvider : SymmetricAlgorithmProvider
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AppSettingSymmetricAlgorithmProvider"/> class.
        /// </summary>
        /// <exception cref="MicroLiteException">Thrown if the expected configuration values are missing in the app.config.</exception>
        public AppSettingSymmetricAlgorithmProvider()
        {
            string key = ConfigurationManager.AppSettings["MicroLite.DbEncryptedString.EncryptionKey"];
            string algorithm = ConfigurationManager.AppSettings["MicroLite.DbEncryptedString.SymmetricAlgorithm"];

            if (string.IsNullOrEmpty(key))
            {
                throw new MicroLiteException(ExceptionMessages.AppSettingSymmetricAlgorithmProvider_MissingKey);
            }

            if (string.IsNullOrEmpty(algorithm))
            {
                throw new MicroLiteException(ExceptionMessages.AppSettingSymmetricAlgorithmProvider_MissingAlgorithm);
            }

            Configure(algorithm, Encoding.ASCII.GetBytes(key));
        }
    }
}
