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

using System.Linq;
using biz.dfch.CS.Examples.DI.StructureMap.SetterInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.SetterInjection
{
    [TestClass]
    public class AnotherClassWithSetterPropertyTest
    {
        [TestMethod]
        public void WithoutInjectionMessageSettingsIsNull()
        {
            var sut = new AnotherClassWithSetterProperty();
            Assert.IsFalse(sut.IsValid());
            var errorMessages = sut.GetErrorMessages();
            Assert.IsTrue(errorMessages.Any(e => e.Contains("MessageSettings")));
        }

        [TestMethod]
        public void WithDefaultRegistryMessageSettingsIsNull()
        {
            var container = StructureMap.IoC.IoC.CreateContainerWithDefaultRegistry();

            var sut = container.GetInstance<AnotherClassWithSetterProperty>();

            Assert.IsFalse(sut.IsValid());
            var errorMessages = sut.GetErrorMessages();
            Assert.IsTrue(errorMessages.Any(e => e.Contains("MessageSettings")));
        }

        [TestMethod]
        public void WithInlineSetterBasedOnTypeRegistryMessageSettingsIsNotNull()
        {
            Assert.IsTrue(typeof(IMessageSettingsSetterInjection).IsAssignableFrom(typeof(AnotherClassWithSetterProperty)));

            var container = StructureMap.IoC.IoC.CreateContainerWithInlineSetterBasedOnType();

            var sut = container.GetInstance<AnotherClassWithSetterProperty>();

            Assert.IsTrue(sut.IsValid());
        }
    }
}
