import Navbar from "../../components/header/Navbar";
import CartPage from "./Cart";

const Cart = () => {
  return (
    <main className="min-h-screen">
      <Navbar />
      <section className="p-20">
        <div className="flex flex-col justify-center"></div>
        <CartPage />
      </section>
    </main>
  );
};

export default Cart;
