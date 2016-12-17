/**
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

using System;
using System.Diagnostics.Contracts;
using System.Linq;
using biz.dfch.CS.Examples.DI.StructureMap.Message;
using biz.dfch.CS.Examples.DI.StructureMap.SetterInjection;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;

namespace biz.dfch.CS.Examples.DI.StructureMap.IoC.Conventions
{
    public class PropertySetterRegistrationConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            Contract.Requires(null != types);
            Contract.Requires(null != registry);

            types
                .FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                // we are only interested in types that reside in namespace "SetterInjection" 
                // and also derive from IMessageSettingsSetterInjection
                .Where(TypeFilter)
                .ToList()
                .ForEach(type =>
                {
                    registry.For(type).Use(type)
                        .Setter<IMessageSettings>().Is<MessageSettings>();
                });
        }

        public static Func<Type, bool> TypeFilter = 
            t => !string.IsNullOrWhiteSpace(t.Namespace)
                && t.Namespace.Contains("SetterInjection")
                && typeof(IMessageSettingsSetterInjection).IsAssignableFrom(t);
    }
}
