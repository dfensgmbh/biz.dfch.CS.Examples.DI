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

using System.Configuration;
using biz.dfch.CS.Examples.DI.StructureMap.InjectionDependingOnAppConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap.AutoMocking;
using Telerik.JustMock;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.InjectionDependingOnAppConfig
{
    [TestClass]
    public class PluginHostTest
    {
        [TestMethod]
        public void InjectionWithDefaultsSucceeds()
        {
            var container = StructureMap.IoC.IoC.CreateContainerForPluginSelection();
            var sut = container.GetInstance<PluginHost>();

            var result = sut.Invoke(42);

            Assert.AreEqual("42", result);
        }

        [TestMethod]
        public void InjectionWithAlphaPluginSucceeds()
        {
            var pluginConfiguration = new PluginConfigurationSection
            {
                Type = typeof(AlphaPlugin).ToString()
            };

            Mock.SetupStatic(typeof(ConfigurationManager));
            Mock.Arrange(() => ConfigurationManager.GetSection(Arg.Is<string>(PluginConfigurationSection.SECTION_NAME)))
                .Returns(pluginConfiguration)
                .MustBeCalled();

            var container = StructureMap.IoC.IoC.CreateContainerForPluginSelection();
            var sut = container.GetInstance<PluginHost>();

            var result = sut.Invoke(0);

            Assert.AreEqual(AlphaPluginSettings.PROPERTY_TEXT_DEFAULT, result);
        }
    }
}
