namespace UtilitiesTest
{
    using Utilities;

    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldCreateRobertJohnGarnerFromRober_John_Garner_Inputs()
        {
            Name name = new Name();
            name.First = "Robert";
            name.Last = "Garner";
            name.Middle = "John";
            string actual = name.Full;
            string expected = "Robert John Garner";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldUseNMIIfNoMiddleName()
        {
            Name name = new Name();
            name.First = "Robert";
            name.Last = "Garner";
            string actual = name.Full;
            string expected = "Robert (NMI) Garner";
            Assert.AreEqual(expected, actual);
        }
    }
}