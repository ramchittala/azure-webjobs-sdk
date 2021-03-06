﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FakeStorage
{
    public class FakeTableClient : CloudTableClient
    {

        public static Uri FakeUri = new Uri("http://localhost:10000/fakeaccount/");

        internal FakeAccount _account;

        public FakeTableClient(FakeAccount account) :
            base(FakeUri, account._creds)
        {
            _account = account;
        }



        public override CloudTable GetTableReference(string tableName)
        {
            return new FakeTable(this, tableName);
        }
    }
}