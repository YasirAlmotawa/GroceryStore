namespace Cart
{
    public class CartAccessor : ICartAccessor
    {
        private readonly ICartRepository _cartRepository;

        public CartAccessor(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart getUserCart(int ucartId)
        {
            return _cartRepository.getUserCart(cartId);
        }

        bool addToCart(int cartId, Product product, int amount)
        {
            var cart = _cartRepository.getCartIdCart(cartId);
            if (cart == null)
            {
                throw new ArgumentException($"No cart found with ID {cartId}");
            }

            return _cartRepository.addToCart(cartId, product, amount);
        }

        bool removeFromCart(int cartId, Product product)
        {
            var cart = _cartRepository.getCartIdCart(cartId);
            if (cart == null)
            {
                throw new ArgumentException($"No cart found with ID {cartId}");
            }

            return _cartRepository.removeFromCart(cartId, product);
        }

        bool updateAmount(int cartId, Product product, int amount)
        {
            var cart = _cartRepository.getCartIdCart(cartId);
            if (cart == null)
            {
                throw new ArgumentException($"No cart found with ID {cartId}");
            }

            return _cartRepository.updateAmount(cartId, product, amount);
        }

        bool initiateCart(Cart cart)
        {
            return _cartRepository.initiateCart(cart);
        }

        bool clearCart(int cartId)
        {
            var cart = _cartRepository.getCartIdCart(cartId);
            if (cart == null)
            {
                throw new ArgumentException($"No cart found with ID {cartId}");
            }

            return _cartRepository.clearCart(cartId);
            
        }
    }
}