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

using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.IoC
{
    public static class IoC
    {
        public static Container CreateContainerManually()
        {
            var result = new Container(map =>
            {
                map.For<IFoo>().Use<Foo>();
            });

            return result;
        }

        public static Container CreateContainerViaScan()
        {
            var result = new Container(map =>
            {
                map.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
            });

            return result;
        }

        public static Container CreateContainerWithDefaultRegistry()
        {
            var registry = new Registry();
            registry.IncludeRegistry<DefaultRegistry>();

            var result = new Container(registry);
            return result;
        }

        public static Container CreateContainerWithRegistryFromConfigSection()
        {
            var registry = new Registry();
            registry.IncludeRegistry<MessageSettingsFromConfigurationSectionRegistry>();
            registry.IncludeRegistry<DefaultRegistry>();

            var result = new Container(registry);
            return result;
        }

        public static Container CreateContainerWithControllerRegistry()
        {
            var registry = new Registry();
            registry.IncludeRegistry<ControllerRegistry>();

            var result = new Container(registry);
            return result;
        }

       public static Container CreateContainerWithInlineSetter()
        {
            var registry = new Registry();
            registry.IncludeRegistry<InlineSetterRegistry>();

            var result = new Container(registry);
            return result;
        }

    }
}
