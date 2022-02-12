using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
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
                    expected: "?",
                    actual: compilationProperties.GIT_BRANCH);
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_COMMIT);
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                Assert.AreEqual(
                    expected: "gitBranch",
                    actual: compilationProperties.GIT_BRANCH);
                Assert.AreEqual(
                    expected: "gitCommit",
                    actual: compilationProperties.GIT_COMMIT);
                Assert.AreEqual(
                    expected: "buildConfiguration",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }
        }

        [TestMethod]
        public void GIT_BRANCH()
        {
            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_BRANCH = default;
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_BRANCH = "";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_BRANCH = " ";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_BRANCH);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
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
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_COMMIT = default;
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_COMMIT = "";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.GIT_COMMIT = " ";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.GIT_COMMIT);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
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
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.BUILD_CONFIGURATION = default;
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.BUILD_CONFIGURATION = "";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.BUILD_CONFIGURATION = " ";
                Assert.AreEqual(
                    expected: "?",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }

            {
                var compilationProperties = new CompilationProperties(
                    "gitBranch",
                    "gitCommit",
                    "buildConfiguration");
                compilationProperties.BUILD_CONFIGURATION = "x";
                Assert.AreEqual(
                    expected: "x",
                    actual: compilationProperties.BUILD_CONFIGURATION);
            }
        }

    }
}
