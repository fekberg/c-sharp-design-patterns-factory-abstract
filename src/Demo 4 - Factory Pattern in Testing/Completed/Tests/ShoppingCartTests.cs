using Factory_Pattern_in_Testing.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FinalizeOrderWithoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var cart = new ShoppingCart(order, null);

            var label = cart.Finalize();
        }

        [TestMethod]
        public void FinalizeOrderWithSwedenPurchaseProvider_GeneratesShippingLabel()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var purchaseProviderFactory = new SwedenPurchaseProviderFactory();

            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FinalizeAlreadyFinalizedOrder_ThrowsInvalidOperationException()
        {
            var cart = CreateShoppingCart();

            cart.Finalize();

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }

        private ShoppingCart CreateShoppingCart(IPurchaseProviderFactory purchaseProviderFactory = null)
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var provider = purchaseProviderFactory ?? new SwedenPurchaseProviderFactory();

            var cart = new ShoppingCart(order, provider);

            return cart;

        }
    }
}