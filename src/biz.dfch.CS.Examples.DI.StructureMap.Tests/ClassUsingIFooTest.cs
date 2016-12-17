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

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests
{
    [TestClass]
    public class ClassUsingIFooTest
    {
        [TestMethod]
        [ExpectedException(typeof(StructureMapConfigurationException))]
        public void TestRegistrationManually()
        {
            var container = StructureMap.IoC.IoC.CreateContainerManually();

            var sut = container.GetInstance<ClassUsingIFoo>();

            var result = sut.TestString("tralala");
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestRegistrationViaScan()
        {
            var container = StructureMap.IoC.IoC.CreateContainerViaScan();

            var sut = container.GetInstance<ClassUsingIFoo>();

            var result = sut.TestString("arbitrary-string");
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void TestRegistrationViaRegistry()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithDefaultRegistry();

            var sut = container.GetInstance<ClassUsingIFoo>();

            var result = sut.TestString("arbitrary-string");
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TestRegistrationViaRegistryWithCustomMappingFromAppSettings()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithRegistryFromConfigSection();

            var sut = container.GetInstance<ClassUsingIFoo>();

            var result = sut.TestString("arbitrary-string");
            Assert.IsFalse(result);

        }

        [TestMethod]
        [ExpectContractFailure(MessagePattern = "Assertion.+null.+foo")]
        public void TestRegistrationViaNew()
        {
            var sut = new ClassUsingIFoo();

            var result = sut.TestString("tralala");
            Assert.IsTrue(result);

        }
    }
}
