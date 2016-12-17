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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Examples.DI.StructureMap.Public;
using biz.dfch.CS.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.MultipleAssemblies
{
    [TestClass]
    public class ExtenderHostTest
    {
        [TestMethod]
        public void ContainerHasValidConfiguration()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithIExtendSomethingFromMultipleAssemblies();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectException(typeof(StructureMapConfigurationException), "IExtendSomething")]
        public void ContainerWithDefaultRegistryFails()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithDefaultRegistry();

            Trace.WriteLine(container.WhatDidIScan());
            Trace.WriteLine(container.WhatDoIHave());

            var sut = container.GetInstance<IExtendSomething>();
        }

        [TestMethod]
        public void ContainerWithMultipleAssemblyRegistrySucceeds()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithIExtendSomethingFromMultipleAssemblies();

            Trace.WriteLine(container.WhatDidIScan());
            Trace.WriteLine(container.WhatDoIHave());

            var sut = container.GetInstance<IExtendSomething>();

            var result = sut.CompareWithProperty("tralala");
            Assert.IsFalse(result);
        }
    }
}
