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

using biz.dfch.CS.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.IoC
{
    [TestClass]
    public class IoCTest
    {
        [TestMethod]
        public void AssertIsValidForCreateContainerWithDefaultRegistry()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithDefaultRegistry();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectException(typeof(StructureMapConfigurationException), "no.configuration.specified.for.+IMessage")]
        public void AssertIsValidForCreateContainerManually()
        {
            var container = StructureMap.IoC.IoC.CreateContainerManually();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertIsValidForCreateContainerWithInlineSetterBasedOnType()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithInlineSetterBasedOnType();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertIsValidForCreateContainerViaScan()
        {
            var container = StructureMap.IoC.IoC.CreateContainerViaScan();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertIsValidForCreateContainerWithControllerRegistry()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithControllerRegistry();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertIsValidForCreateContainerWithInlineSetter()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithInlineSetter();

            container.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AssertIsValidForCreateContainerWithRegistryFromConfigSection()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithRegistryFromConfigSection();

            container.AssertConfigurationIsValid();
        }
    }
}
