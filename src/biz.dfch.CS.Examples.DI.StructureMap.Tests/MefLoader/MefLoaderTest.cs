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
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Examples.DI.StructureMap.MefLoader;
using biz.dfch.CS.Examples.DI.StructureMap.Public.MefLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.MefLoader
{
    [TestClass]
    public class MefLoaderTest
    {
        [TestMethod]
        public void ResolvingTypeSucceeds()
        {
            Assert.IsNotNull(typeof(SomeMefPlugin));

            var sut = new StructureMap.MefLoader.MefLoader();

            var instance = sut.GetInstance<IMefPlugin>();
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ResolvingTypeMultipleTimesIsSingleton()
        {
            var sut = new StructureMap.MefLoader.MefLoader();

            var instance1 = sut.GetInstance<IMefPlugin>();
            Assert.IsNotNull(instance1);

            var instance2 = sut.GetInstance<IMefPlugin>();
            Assert.IsNotNull(instance2);

            Assert.AreSame(instance1, instance2);
        }

        [TestMethod]
        public void ResolvingMultipleTypesSucceeds()
        {
            var settings = new MefLoaderSettings();
            settings.SetExtensionsFolderToExecutingAssembly();

            var sut = new StructureMap.MefLoader.MefLoader(settings);

            var instances = sut.GetInstances<IMefPlugin>();
            Assert.IsNotNull(instances);
            Assert.AreEqual(2, instances.Count());
        }
    }
}
