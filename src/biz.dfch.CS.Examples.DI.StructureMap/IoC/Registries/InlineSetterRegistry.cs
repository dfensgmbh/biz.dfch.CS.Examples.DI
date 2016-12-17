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

using biz.dfch.CS.Examples.DI.StructureMap.Message;
using biz.dfch.CS.Examples.DI.StructureMap.SetterInjection;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.IoC.Registries
{
    public class InlineSetterRegistry : Registry
    {
        public InlineSetterRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
            });

            For<ClassWithAnnotatedSetterProperties>().Use<ClassWithAnnotatedSetterProperties>()
                .Setter<IMessageSettings>().Is<MessageSettings>();
        }
    }
}
