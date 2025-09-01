using System;

namespace AdapterPattern
{
    public interface IPayPalPayment
    {
        void PayPalPayment();
        void PayPalReceive();
    }

    public class PayPal : IPayPalPayment
    {
        public void PayPalPayment()
        {
            Console.WriteLine("Pagamento vai PayPal realizado!!!");
        }

        public void PayPalReceive()
        {
            Console.WriteLine("Recebimento via PayPal realizado!");
        }
    }

    public class Payoneer
    {
        public void SendPayment()
        {
            Console.WriteLine("Pagamento via Payoner realizado!");
        }

        public void ReceivePayment()
        {
            Console.WriteLine("Recebimento via Payoner realizado!");
        }
    }

    public class PayoneerAdapter : IPayPalPayment
    {
        private readonly Payoneer _payoneer;

        public PayoneerAdapter(Payoneer payoneer)
        {
            _payoneer = payoneer;
        }

        public void PayPalPayment()
        {
            _payoneer.SendPayment();
        }

        public void PayPalReceive()
        {
            _payoneer.ReceivePayment();
        }
    }

    public class MercadoPago
    {
        public void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento via Mercado Pago realizado");
        }

        public void ReceberPagamento()
        {
            Console.WriteLine("Recebimento via Mercado Pago realizado");
        }
    }

    public class MercadoPagoAdapter : IPayPalPayment
    {
        private readonly MercadoPago _mercadoPago;

        public MercadoPagoAdapter(MercadoPago mercadoPago)
        {
            _mercadoPago = mercadoPago;
        }

        public void PayPalPayment()
        {
            _mercadoPago.EfetuarPagamento();
        }

        public void PayPalReceive()
        {
            _mercadoPago.ReceberPagamento();
        }
    }
    public class Client
    {
        public void RealizarOperacao(IPayPalPayment pagamento)
        {
            pagamento.PayPalPayment();
            pagamento.PayPalReceive();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Client();

            Console.WriteLine("Usando PayPal:");
            cliente.RealizarOperacao(new PayPal());

            Console.WriteLine("\nUsando Payoneer com Adapter:");
            cliente.RealizarOperacao(new PayoneerAdapter(new Payoneer()));

            Console.WriteLine("\nUsando MercadoPago com Adapter:");
            cliente.RealizarOperacao(new MercadoPagoAdapter(new MercadoPago()));
        }
    }
}
