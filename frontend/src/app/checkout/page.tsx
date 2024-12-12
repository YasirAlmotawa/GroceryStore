import React from "react";
import Navbar from "../../components/header/Navbar";
import CheckoutPage from "./Checkout";

const Checkout = () => {
  return (
    <main className="min-h-screen">
      <Navbar />
      <section className="p-20">
        <div className="flex flex-col justify-center"></div>
        <CheckoutPage />
      </section>
    </main>
  );
};

export default Checkout;
