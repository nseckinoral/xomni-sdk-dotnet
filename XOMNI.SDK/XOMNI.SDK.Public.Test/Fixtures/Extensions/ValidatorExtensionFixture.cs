using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Extensions;
using XOMNI.SDK.Public.Test.Helpers;

namespace XOMNI.SDK.Public.Test.Fixtures.Extensions
{
    [TestClass]
    public class ValidatorExtensionFixture
    {
        #region NotNull
        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("NotNull")]
        public void NotNullThrowExceptionTest()
        {
            object sampleNullObject = null;
            try
            {
                Validator.For(sampleNullObject, "sampleNullObject").IsNotNull();
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentNullException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentNullException("sampleNullObject can not be null."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("NotNull")]
        public void NotNullDoesNotThrowExceptionTest()
        {
            string sampleParameter = "";
            Validator.For(sampleParameter, "sampleParameter").IsNotNull();
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("NotNull")]
        public void NotNullArgumentNameMalformedTest()
        {
            string sampleParameter = "Test";
            try
            {
                string argumentName = Validator.For(sampleParameter, "sampleParameter").IsNotNull().ArgName;
                Assert.AreEqual("sampleParameter", argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("NotNull")]
        public void NotNullParameterValueMalformedTest()
        {
            string sampleParameter = "Test";
            try
            {
                string value = Validator.For(sampleParameter, "sampleParameter").IsNotNull().Value;
                Assert.AreEqual(value, sampleParameter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }
        #endregion

        #region IsNullOrEmpty
        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void IsNullOrEmptyParameterNullTest()
        {
            string sampleParameter = null;
            try
            {
                Validator.For(sampleParameter, "sampleParameter").IsNotNull().IsNotNullOrEmpty();
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentNullException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentNullException("sampleParameter can not be null."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void IsNullOrEmptyParameterEmptyTest()
        {
            string sampleParameter = "";
            try
            {
                Validator.For(sampleParameter, "sampleParameter").IsNotNullOrEmpty();
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentException("sampleParameter can not be empty or null."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void IsNullOrEmptyArgumentNameMalformedTest()
        {
            string sampleParameter = "Test";
            try
            {
                string argumentName = Validator.For(sampleParameter, "sampleParameter").IsNotNullOrEmpty().ArgName;
                Assert.AreEqual("sampleParameter", argumentName);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void IsNullOrEmptyParameterValueMalformedTest()
        {
            string sampleParameter = "Test";
            try
            {
                string value = Validator.For(sampleParameter, "sampleParameter").Value;
                Assert.AreEqual(value, sampleParameter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }
        #endregion

        #region Contains

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("Contains")]
        public void ContainsThrowExceptionTest()
        {
            string sampleParameter = "Test";
            try
            {
                Validator.For(sampleParameter, "sampleParameter").Contains(';');
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentException("sampleParameter must be include ';' character."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void ContainsParameterEmptyTest()
        {
            string sampleParameter = "";
            try
            {
                Validator.For(sampleParameter, "sampleParameter").Contains(';');
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentException("sampleParameter can not be empty or null."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsNullOrEmpty")]
        public void ContainsParameterNullTest()
        {
            string sampleParameter = null;
            try
            {
                Validator.For(sampleParameter, "sampleParameter").Contains(';');
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentException("sampleParameter can not be empty or null."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("Contains")]
        public void ContainsDoesNotThrowExceptionTest()
        {
            string sampleParameter = "Test;";
            try
            {
                Parameter<string> parameter = Validator.For(sampleParameter, "sampleParameter").Contains(';');
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("Contains")]
        public void ContainsArgumentNameMalformedTest()
        {
            string sampleParameter = "Test;";
            try
            {
                string argumentName = Validator.For(sampleParameter, "sampleParameter").Contains(';').ArgName;
                Assert.AreEqual("sampleParameter", argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("Contains")]
        public void ContainsParameterValueMalformedTest()
        {
            string sampleParameter = "Test;";
            try
            {
                string value = Validator.For(sampleParameter, "sampleParameter").Contains(';').Value;
                Assert.AreEqual(value, sampleParameter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }
        #endregion

        #region InRange

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("InRange")]
        public void InRangeThrowExceptionTest()
        {
            int sampleParameter = 5;
            try
            {
                Validator.For(sampleParameter, "sampleParameter").InRange(6, 10);
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentOutOfRangeException("sampleParameter must be in range (6 - 10)."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("InRange")]
        public void InRangeDoesNotThrowExceptionTest()
        {
            int sampleParameter = 5;
            try
            {
                Parameter<int> parameter = Validator.For(sampleParameter, "sampleParameter").InRange(1, 5);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("InRange")]
        public void InRangeArgumentNameMalformedTest()
        {
            int sampleParameter = 5;
            try
            {
                string argumentName = Validator.For(sampleParameter, "sampleParameter").InRange(1, 10).ArgName;
                Assert.AreEqual("sampleParameter", argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("InRange")]
        public void InRangeParameterValueMalformedTest()
        {
            int sampleParameter = 5;
            try
            {
                int value = Validator.For(sampleParameter, "sampleParameter").InRange(1, 10).Value;
                Assert.AreEqual(value, sampleParameter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }
        #endregion

        #region IsGreaterThanOrEqual

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsGreaterThanOrEqual")]
        public void IsGreaterThanOrEqualThrowExceptionTest()
        {
            int sampleParameter = 5;
            try
            {
                Validator.For(sampleParameter, "sampleParameter").IsGreaterThanOrEqual(6);
                Assert.Fail("Expected exception is not raised.");
            }
            catch (ArgumentException ex)
            {
                AssertExtensions.AreDeeplyEqual(new ArgumentException("sampleParameter must be greater than or equal to 6."), ex);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsGreaterThanOrEqual")]
        public void IsGreaterThanOrEqualDoesNotThrowExceptionTest()
        {
            int sampleParameter = 5;
            try
            {
                Parameter<int> parameter = Validator.For(sampleParameter, "sampleParameter").IsGreaterThanOrEqual(4);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsGreaterThanOrEqual")]
        public void IsGreaterThanOrEqualArgumentNameMalformedTest()
        {
            int sampleParameter = 7;
            try
            {
                string argumentName = Validator.For(sampleParameter, "sampleParameter").IsGreaterThanOrEqual(6).ArgName;
                Assert.AreEqual("sampleParameter", argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }

        [TestMethod, TestCategory("ValidatorExtension"), TestCategory("IsGreaterThanOrEqual")]
        public void IsGreaterThanOrEqualParameterValueMalformedTest()
        {
            int sampleParameter = 7;
            try
            {
                int value = Validator.For(sampleParameter, "sampleParameter").IsGreaterThanOrEqual(6).Value;
                Assert.AreEqual(value, sampleParameter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected error occured. " + ex.Message);
            }
        }
        #endregion
    }
}
