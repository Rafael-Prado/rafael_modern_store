using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModerStore.Domain.Teste
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Order - New Order")]
        public void DadoUmProdutoForaDeEstoqueAdicioneUmaNotificacao()
        {
            var user = new User("rafael", "prado");
            var customer = new Customer("Rafael", "prado", "rafael@hotmail.com", user);
            var mouse = new Product("Mouse", 299, 0);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void DadoUmProdutEmeEstoqueDeveAtualizarPrdutoEmMaos()
        {
            var user = new User("rafael", "prado");
            var customer = new Customer("Rafael", "prado", "rafael@hotmail.com", user);
            var mouse = new Product("Mouse", 299, 20);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }
    }
}
