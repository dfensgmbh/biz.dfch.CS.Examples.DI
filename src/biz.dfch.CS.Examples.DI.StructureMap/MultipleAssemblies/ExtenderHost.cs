﻿/**
 * Copyright 2016 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Diagnostics.Contracts;
using biz.dfch.CS.Examples.DI.StructureMap.Public;

namespace biz.dfch.CS.Examples.DI.StructureMap.MultipleAssemblies
{
    public class ExtenderHost
    {
        private readonly IExtendSomething extendSomething;

        public ExtenderHost(IExtendSomething extendSomething)
        {
            Contract.Requires(null != extendSomething);

            this.extendSomething = extendSomething;
        }

        public bool InvokeExtension(string value)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(value));

            var result = extendSomething.CompareWithProperty(value);
            return result;
        }

        public string GetProperty()
        {
            var result = extendSomething.StringProperty;
            return result;
        }
    }
}
