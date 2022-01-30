using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Tests
{
    [TestClass]
    public class Test_CompilationProperties
    {
        [TestMethod]
        public void ctor()
        {
            {
                var compilationProperties = new CompilationProperties();
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_BRANCH);
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_COMMIT);
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                Assert.AreEqual(
                    expected: CompilationProperties.gitBranch,
                    actual: compilationProperties.GIT_BRANCH);
                Assert.AreEqual(
                    expected: CompilationProperties.gitCommit,
                    actual: compilationProperties.GIT_COMMIT);
                Assert.AreEqual(
                    expected: CompilationProperties.buildConfiguration,
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }
        }

        [TestMethod]
        public void GIT_BRANCH()
        {
            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_BRANCH = default;
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_BRANCH = "";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_BRANCH = " ";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_BRANCH = "x";
                Assert.AreEqual(
                    expected: "x",
                    actual: compilationProperties.GIT_BRANCH);
            }
        }

        [TestMethod]
        public void GIT_COMMIT()
        {
            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_COMMIT = default;
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_COMMIT = "";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_COMMIT = " ";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.GIT_COMMIT = "x";
                Assert.AreEqual(
                    expected: "x",
                    actual: compilationProperties.GIT_COMMIT);
            }
        }

        [TestMethod]
        public void BUILD_CONFIGURATION()
        {
            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.BUILD_CONFIGURATION = default;
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.BUILD_CONFIGURATION = "";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.BUILD_CONFIGURATION = " ";
                Assert.AreEqual(
                    expected: CompilationProperties.Unknown,
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    CompilationProperties.gitBranch,
                    CompilationProperties.gitCommit,
                    CompilationProperties.buildConfiguration);
                compilationProperties.BUILD_CONFIGURATION = "x";
                Assert.AreEqual(
                    expected: "x",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }
        }

    }
}
